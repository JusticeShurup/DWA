using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DWAApi.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    SkinColour = table.Column<string>(type: "text", nullable: false),
                    EUSizeS = table.Column<int>(type: "integer", nullable: false),
                    EUSizeT = table.Column<int>(type: "integer", nullable: false),
                    EUSizeL = table.Column<int>(type: "integer", nullable: false),
                    CircleHip = table.Column<int>(type: "integer", nullable: false),
                    CircleChest = table.Column<int>(type: "integer", nullable: false),
                    CircleCalf = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UserInfoId = table.Column<Guid>(type: "uuid", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserInfoId",
                table: "Users",
                column: "UserInfoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserInfos");
        }
    }
}
