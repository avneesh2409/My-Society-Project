using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mysocietywebsite.Model.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("536d890f-49b8-4c5f-bfe3-2b16dca5f423"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("504b806b-d41f-4882-aa12-93d5d2b16301"));

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("fa97aa9f-d2ca-438d-aec4-d98b4c2bad86"), new Guid("fa97aa9f-d2ca-438d-aec4-d98b4c2bad86"), new DateTime(2020, 10, 11, 11, 38, 21, 381, DateTimeKind.Utc).AddTicks(3041), true, false, new Guid("fa97aa9f-d2ca-438d-aec4-d98b4c2bad86"), new DateTime(2020, 10, 11, 11, 38, 21, 381, DateTimeKind.Utc).AddTicks(4008), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Contact", "CreatedBy", "CreatedOn", "Email", "Fullname", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Password", "RoleId", "Username" },
                values: new object[] { new Guid("514414ba-8ff1-4f62-95b8-296952d896ad"), "H.No - 30 Indus Town", "9109072549", new Guid("514414ba-8ff1-4f62-95b8-296952d896ad"), new DateTime(2020, 10, 11, 11, 38, 21, 383, DateTimeKind.Utc).AddTicks(919), "tarun@gmail.com", "Tarunendra", true, false, new Guid("514414ba-8ff1-4f62-95b8-296952d896ad"), new DateTime(2020, 10, 11, 11, 38, 21, 383, DateTimeKind.Utc).AddTicks(937), "123456789", new Guid("fa97aa9f-d2ca-438d-aec4-d98b4c2bad86"), "AD" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("514414ba-8ff1-4f62-95b8-296952d896ad"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fa97aa9f-d2ca-438d-aec4-d98b4c2bad86"));

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("504b806b-d41f-4882-aa12-93d5d2b16301"), new Guid("504b806b-d41f-4882-aa12-93d5d2b16301"), new DateTime(2020, 10, 11, 10, 38, 25, 148, DateTimeKind.Utc).AddTicks(8426), true, false, new Guid("504b806b-d41f-4882-aa12-93d5d2b16301"), new DateTime(2020, 10, 11, 10, 38, 25, 148, DateTimeKind.Utc).AddTicks(9383), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Contact", "CreatedBy", "CreatedOn", "Email", "Fullname", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Password", "RoleId", "Username" },
                values: new object[] { new Guid("536d890f-49b8-4c5f-bfe3-2b16dca5f423"), "H.No - 30 Indus Town", "9109072549", new Guid("536d890f-49b8-4c5f-bfe3-2b16dca5f423"), new DateTime(2020, 10, 11, 10, 38, 25, 150, DateTimeKind.Utc).AddTicks(6236), "tarun@gmail.com", "Tarunendra", true, false, new Guid("536d890f-49b8-4c5f-bfe3-2b16dca5f423"), new DateTime(2020, 10, 11, 10, 38, 25, 150, DateTimeKind.Utc).AddTicks(6256), "123456789", new Guid("504b806b-d41f-4882-aa12-93d5d2b16301"), "AD" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
