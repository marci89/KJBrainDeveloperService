


using KJBrainDeveloperService.API.Extensions;
using KJBrainDeveloperService.Business.Settings;
using KJBrainDeveloperService.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//appSettings
var logSettings = new LogSettings(builder.Configuration);
var databaseSettings = new DatabaseSettings(builder.Configuration);
var securitySettings = new SecuritySettings(builder.Configuration);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerServices();
builder.Services.AddIdentityServices(securitySettings);
builder.Services.AddDatabaseServices(databaseSettings);
builder.Services.AddDependencyInjectionServices();
builder.Services.AddLoggingService(logSettings);

builder.Services.AddCors();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region If database is not exists or there is a new migration to update, this will handle it.

if (databaseSettings.AutoMigrationEnabled)
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    if (db.Database.GetPendingMigrations().Any())
    {
        db.Database.Migrate();
    }
}


#endregion

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

