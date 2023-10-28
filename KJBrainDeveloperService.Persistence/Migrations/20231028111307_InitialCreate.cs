using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KJBrainDeveloperService.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    AvatarId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResetToken = table.Column<string>(type: "text", nullable: true),
                    ResetTokenExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemoryCardStatistics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Moved = table.Column<long>(type: "bigint", nullable: false),
                    Difficult = table.Column<string>(type: "text", nullable: false, defaultValue: "Easy"),
                    PictureTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsPractice = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryCardStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemoryCardStatistics_UserID",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainingStatistics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Score = table.Column<long>(type: "bigint", nullable: false),
                    TrainingMode = table.Column<string>(type: "text", nullable: false, defaultValue: "MemorySound"),
                    SoundTypeId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingStatistics_UserID",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemoryCardStatistics_UserId",
                table: "MemoryCardStatistics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingStatistics_UserId",
                table: "TrainingStatistics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemoryCardStatistics");

            migrationBuilder.DropTable(
                name: "TrainingStatistics");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
