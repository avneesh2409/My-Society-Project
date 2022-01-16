using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mysocietywebsite.Model.Migrations
{
    public partial class initialmigration : Migration
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("92235171-06b3-40e6-adaf-2499bbe3b4f0"), new Guid("92235171-06b3-40e6-adaf-2499bbe3b4f0"), new DateTime(2022, 1, 16, 10, 21, 55, 3, DateTimeKind.Utc).AddTicks(4001), true, false, new Guid("92235171-06b3-40e6-adaf-2499bbe3b4f0"), new DateTime(2022, 1, 16, 10, 21, 55, 3, DateTimeKind.Utc).AddTicks(5320), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("c90cea60-7517-414d-822e-74677528a0f7"), new Guid("92235171-06b3-40e6-adaf-2499bbe3b4f0"), new DateTime(2022, 1, 16, 10, 21, 55, 3, DateTimeKind.Utc).AddTicks(6012), true, false, new Guid("92235171-06b3-40e6-adaf-2499bbe3b4f0"), new DateTime(2022, 1, 16, 10, 21, 55, 3, DateTimeKind.Utc).AddTicks(6060), "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Contact", "CreatedBy", "CreatedOn", "Email", "Fullname", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Password", "RoleId", "Username" },
                values: new object[] { new Guid("0c6b13e0-0f19-45ae-8fac-f6f3293284ef"), "H.No - 30 Indus Town", "9109072549", new Guid("0c6b13e0-0f19-45ae-8fac-f6f3293284ef"), new DateTime(2022, 1, 16, 10, 21, 56, 963, DateTimeKind.Utc).AddTicks(5771), "tarun@gmail.com", "Tarunendra", true, false, new Guid("0c6b13e0-0f19-45ae-8fac-f6f3293284ef"), new DateTime(2022, 1, 16, 10, 21, 56, 963, DateTimeKind.Utc).AddTicks(5844), "BJJcVkTHd9Qkv8iCM8srzsyU50CjkRe4ckHbWkHVlAc=", new Guid("92235171-06b3-40e6-adaf-2499bbe3b4f0"), "AD" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
