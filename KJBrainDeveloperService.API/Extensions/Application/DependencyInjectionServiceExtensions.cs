using KJBrainDeveloperService.API.Helpers;
using KJBrainDeveloperService.Business;
using KJBrainDeveloperService.Business.Settings;
using KJBrainDeveloperService.Persistence.Repositories;

namespace KJBrainDeveloperService.API.Extensions
{
    public static class DependencyInjectionServiceExtensions
    {
        /// <summary>
        /// Injecting all of classes
        /// </summary>
        public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
            RegisterFactories(services);
            RegisterValidators(services);
            RegisterHelpers(services);

            return services;
        }

        /// <summary>
        /// Register repositories
        /// </summary>
        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITrainingStatisticsRepository, TrainingStatisticsRepository>();
            services.AddScoped<IMemoryCardStatisticsRepository, MemoryCardStatisticsRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        /// <summary>
        /// Register services
        /// </summary>
        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStatisticsService, StatisticsService>();

            services.AddScoped<IAuthTokenService, AuthTokenService>();
        }

        /// <summary>
        /// Register factories
        /// </summary>
        private static void RegisterFactories(this IServiceCollection services)
        {
            services.AddScoped<UserFactory>();
            services.AddScoped<StatisticsFactory>();
        }

        /// <summary>
        /// Register validators
        /// </summary>
        private static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<UserValidator>();
            services.AddScoped<StatisticsValidator>();
        }

        /// <summary>
        /// Register handlers
        /// </summary>
        private static void RegisterHelpers(this IServiceCollection services)
        {
            services.AddScoped<PasswordSecurityHandler>();
            services.AddScoped<ErrorLogger>();

            //emails
            services.AddScoped<IEmailSenderBase, EmailSenderBase>();
            services.AddScoped<IRegisterEmailSender, RegisterEmailSender>();
            services.AddScoped<IResetPasswordEmailSender, ResetPasswordEmailSender>();

            //appsettings
            services.AddSingleton<IApplicationSettings, ApplicationSettings>();
            services.AddSingleton<ISecuritySettings, SecuritySettings>();
            services.AddSingleton<ILogSettings, LogSettings>();
            services.AddSingleton<IDatabaseSettings, DatabaseSettings>();
            services.AddSingleton<IEmailSettings, EmailSettings>();
        }
    }
}
