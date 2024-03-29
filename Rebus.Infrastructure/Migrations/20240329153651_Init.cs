using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rebus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isLoggedIn = table.Column<bool>(type: "bit", nullable: false),
                    Location_locationId = table.Column<int>(type: "int", nullable: true),
                    Location_latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_postalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "GameAccessCode",
                columns: table => new
                {
                    GameAccessCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    UsageLimit = table.Column<int>(type: "int", nullable: true),
                    TimeUsed = table.Column<int>(type: "int", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAccessCode", x => x.GameAccessCodeId);
                    table.ForeignKey(
                        name: "FK_GameAccessCode_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameCreator",
                columns: table => new
                {
                    GameCreatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCreator", x => x.GameCreatorId);
                    table.ForeignKey(
                        name: "FK_GameCreator_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCreator_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCreator_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGameHistories",
                columns: table => new
                {
                    UserGameHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    AccessStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccessEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameHistories", x => x.UserGameHistoryId);
                    table.ForeignKey(
                        name: "FK_UserGameHistories_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGameHistories_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGameHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameUserAccess",
                columns: table => new
                {
                    GameUserAccessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameAccessCodeId = table.Column<int>(type: "int", nullable: false),
                    AccessTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUserAccess", x => x.GameUserAccessId);
                    table.ForeignKey(
                        name: "FK_GameUserAccess_GameAccessCode_GameAccessCodeId",
                        column: x => x.GameAccessCodeId,
                        principalTable: "GameAccessCode",
                        principalColumn: "GameAccessCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUserAccess_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameAccessCode_GameId",
                table: "GameAccessCode",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameCreator_GameId",
                table: "GameCreator",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCreator_RoleId",
                table: "GameCreator",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCreator_UserId",
                table: "GameCreator",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUserAccess_GameAccessCodeId",
                table: "GameUserAccess",
                column: "GameAccessCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUserAccess_UserId",
                table: "GameUserAccess",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameHistories_GameId",
                table: "UserGameHistories",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameHistories_RoleId",
                table: "UserGameHistories",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameHistories_UserId",
                table: "UserGameHistories",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameCreator");

            migrationBuilder.DropTable(
                name: "GameUserAccess");

            migrationBuilder.DropTable(
                name: "UserGameHistories");

            migrationBuilder.DropTable(
                name: "GameAccessCode");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
