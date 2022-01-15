using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mysocietywebsite.Model.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("514414ba-8ff1-4f62-95b8-296952d896ad"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fa97aa9f-d2ca-438d-aec4-d98b4c2bad86"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("bfa65a33-79e5-4eb9-ad35-6a73ac0172d7"), new Guid("bfa65a33-79e5-4eb9-ad35-6a73ac0172d7"), new DateTime(2022, 1, 14, 14, 41, 59, 337, DateTimeKind.Utc).AddTicks(9073), true, false, new Guid("bfa65a33-79e5-4eb9-ad35-6a73ac0172d7"), new DateTime(2022, 1, 14, 14, 41, 59, 337, DateTimeKind.Utc).AddTicks(9616), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Contact", "CreatedBy", "CreatedOn", "Email", "Fullname", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Password", "RoleId", "Username" },
                values: new object[] { new Guid("1ef664ec-904b-43c7-87ab-a1bfbd3df8de"), "H.No - 30 Indus Town", "9109072549", new Guid("1ef664ec-904b-43c7-87ab-a1bfbd3df8de"), new DateTime(2022, 1, 14, 14, 41, 59, 339, DateTimeKind.Utc).AddTicks(1899), "tarun@gmail.com", "Tarunendra", true, false, new Guid("1ef664ec-904b-43c7-87ab-a1bfbd3df8de"), new DateTime(2022, 1, 14, 14, 41, 59, 339, DateTimeKind.Utc).AddTicks(1918), "123456789", new Guid("bfa65a33-79e5-4eb9-ad35-6a73ac0172d7"), "AD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1ef664ec-904b-43c7-87ab-a1bfbd3df8de"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bfa65a33-79e5-4eb9-ad35-6a73ac0172d7"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("fa97aa9f-d2ca-438d-aec4-d98b4c2bad86"), new Guid("fa97aa9f-d2ca-438d-aec4-d98b4c2bad86"), new DateTime(2020, 10, 11, 11, 38, 21, 381, DateTimeKind.Utc).AddTicks(3041), true, false, new Guid("fa97aa9f-d2ca-438d-aec4-d98b4c2bad86"), new DateTime(2020, 10, 11, 11, 38, 21, 381, DateTimeKind.Utc).AddTicks(4008), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Contact", "CreatedBy", "CreatedOn", "Email", "Fullname", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOn", "Password", "RoleId", "Username" },
                values: new object[] { new Guid("514414ba-8ff1-4f62-95b8-296952d896ad"), "H.No - 30 Indus Town", "9109072549", new Guid("514414ba-8ff1-4f62-95b8-296952d896ad"), new DateTime(2020, 10, 11, 11, 38, 21, 383, DateTimeKind.Utc).AddTicks(919), "tarun@gmail.com", "Tarunendra", true, false, new Guid("514414ba-8ff1-4f62-95b8-296952d896ad"), new DateTime(2020, 10, 11, 11, 38, 21, 383, DateTimeKind.Utc).AddTicks(937), "123456789", new Guid("fa97aa9f-d2ca-438d-aec4-d98b4c2bad86"), "AD" });
        }
    }
}
