using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mysocietywebsite.Model.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Fullname = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gallery_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("372e9e7e-1181-464e-8721-57aae55723d6"), new Guid("372e9e7e-1181-464e-8721-57aae55723d6"), new DateTime(2022, 1, 26, 14, 4, 55, 767, DateTimeKind.Utc).AddTicks(9690), true, false, new Guid("372e9e7e-1181-464e-8721-57aae55723d6"), new DateTime(2022, 1, 26, 14, 4, 55, 768, DateTimeKind.Utc).AddTicks(222), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("4c034a10-98b9-4f8f-ae0d-e7da889b888c"), new Guid("372e9e7e-1181-464e-8721-57aae55723d6"), new DateTime(2022, 1, 26, 14, 4, 55, 768, DateTimeKind.Utc).AddTicks(538), true, false, new Guid("372e9e7e-1181-464e-8721-57aae55723d6"), new DateTime(2022, 1, 26, 14, 4, 55, 768, DateTimeKind.Utc).AddTicks(563), "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Contact", "CreatedBy", "CreatedOn", "Email", "Fullname", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Password", "RoleId", "Username" },
                values: new object[] { new Guid("d98e6c37-3bc4-4874-b71e-e500a44ab56e"), "H.No - 30 Indus Town", "9109072549", new Guid("d98e6c37-3bc4-4874-b71e-e500a44ab56e"), new DateTime(2022, 1, 26, 14, 4, 55, 785, DateTimeKind.Utc).AddTicks(459), "tarun@gmail.com", "Tarunendra", true, false, new Guid("d98e6c37-3bc4-4874-b71e-e500a44ab56e"), new DateTime(2022, 1, 26, 14, 4, 55, 785, DateTimeKind.Utc).AddTicks(526), "BJJcVkTHd9Qkv8iCM8srzsyU50CjkRe4ckHbWkHVlAc=", new Guid("372e9e7e-1181-464e-8721-57aae55723d6"), "AD" });

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_UserId",
                table: "Gallery",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
