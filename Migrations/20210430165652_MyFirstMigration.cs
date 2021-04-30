using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace newwebapi.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Active", "DateCreated", "LastName", "Name" },
                values: new object[] { new Guid("dcd9ed64-cb78-4c87-9b26-9204919d4249"), true, new DateTime(2021, 4, 30, 11, 56, 51, 897, DateTimeKind.Local).AddTicks(5513), "Guaman", "Vero" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Active", "DateCreated", "LastName", "Name" },
                values: new object[] { new Guid("9cabd999-c5ca-45b3-8863-a0b474f52f1b"), true, new DateTime(2021, 4, 30, 11, 56, 51, 899, DateTimeKind.Local).AddTicks(3853), "LastName 1", "User 1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Active", "DateCreated", "LastName", "Name" },
                values: new object[] { new Guid("4e175d31-82bf-404d-bc97-783e47d27b03"), true, new DateTime(2021, 4, 30, 11, 56, 51, 899, DateTimeKind.Local).AddTicks(3924), "LastName 2", "User 2" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "Active", "Role", "UserId" },
                values: new object[,]
                {
                    { new Guid("68d6dd14-6beb-4180-a112-e49c4737383e"), true, "Admin", new Guid("dcd9ed64-cb78-4c87-9b26-9204919d4249") },
                    { new Guid("865ef134-a1a9-4b61-bf61-ab203e5dbb4a"), true, "User", new Guid("dcd9ed64-cb78-4c87-9b26-9204919d4249") },
                    { new Guid("adabe337-33bf-49db-ba9a-b5e6859c9286"), true, "Support", new Guid("dcd9ed64-cb78-4c87-9b26-9204919d4249") },
                    { new Guid("0e7282d2-0f91-4f9b-8777-21c23e0ab1ee"), true, "Support", new Guid("9cabd999-c5ca-45b3-8863-a0b474f52f1b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
