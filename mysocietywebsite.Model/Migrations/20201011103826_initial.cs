using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mysocietywebsite.Model.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
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
                    table.PrimaryKey("PK_Role", x => x.Id);
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
                        name: "FK_Users_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("504b806b-d41f-4882-aa12-93d5d2b16301"), new Guid("504b806b-d41f-4882-aa12-93d5d2b16301"), new DateTime(2020, 10, 11, 10, 38, 25, 148, DateTimeKind.Utc).AddTicks(8426), true, false, new Guid("504b806b-d41f-4882-aa12-93d5d2b16301"), new DateTime(2020, 10, 11, 10, 38, 25, 148, DateTimeKind.Utc).AddTicks(9383), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Contact", "CreatedBy", "CreatedOn", "Email", "Fullname", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Password", "RoleId", "Username" },
                values: new object[] { new Guid("536d890f-49b8-4c5f-bfe3-2b16dca5f423"), "H.No - 30 Indus Town", "9109072549", new Guid("536d890f-49b8-4c5f-bfe3-2b16dca5f423"), new DateTime(2020, 10, 11, 10, 38, 25, 150, DateTimeKind.Utc).AddTicks(6236), "tarun@gmail.com", "Tarunendra", true, false, new Guid("536d890f-49b8-4c5f-bfe3-2b16dca5f423"), new DateTime(2020, 10, 11, 10, 38, 25, 150, DateTimeKind.Utc).AddTicks(6256), "123456789", new Guid("504b806b-d41f-4882-aa12-93d5d2b16301"), "AD" });

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
                name: "Role");
        }
    }
}
