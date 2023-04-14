using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebData.Migrations
{
    public partial class updatedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_AppUserId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_AppUserId",
                table: "UserRoles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cdff0aa-3b04-4de6-b272-7e3396547bfb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19ed6003-80f4-48cd-b337-f1493f525605"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2d489c76-4446-4199-be46-87928b451da2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2d8c5d9a-1f95-4313-a8f1-db13c18042a5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("300ec321-a88d-407e-b11a-214cc6727ab7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67245797-6b85-4370-8fcf-f973473656dd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d807717-7c80-4e66-8f00-9b2ba36d6830"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f55125f-1bdb-47c2-92a6-071fd1f27676"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b473467b-ca85-4eaf-ab08-2096ec4e4ef5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dbacf549-92a3-4dcf-aefe-82c7debfee9c"));

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserRoles");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    appUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    roleIdentityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_roleIdentityId",
                        column: x => x.roleIdentityId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_UserRoles_UserId_RoleId",
                        columns: x => new { x.UserId, x.RoleId },
                        principalTable: "UserRoles",
                        principalColumns: new[] { "UserId", "RoleId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_appUserId",
                        column: x => x.appUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FullName", "LastLoginDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2a62a989-5d4f-4654-9d9e-399a31e04b64"), 0, "cafb3632-d4f6-453f-a738-4cc4eac922cc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc8@gmail.com", false, "Nguyen Van 8", new DateTime(2023, 4, 14, 13, 43, 47, 579, DateTimeKind.Local).AddTicks(7285), false, null, null, null, "811111", "0123456788", false, null, false, "Ten8" },
                    { new Guid("aa62aede-b2e2-4c56-8119-e1e713752dc9"), 0, "3e23254a-570b-4c6d-bd02-589357348b71", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc7@gmail.com", false, "Nguyen Van 7", new DateTime(2023, 4, 14, 13, 43, 47, 579, DateTimeKind.Local).AddTicks(7233), false, null, null, null, "711111", "0123456787", false, null, false, "Ten7" },
                    { new Guid("c7f5e3d2-da96-4682-a506-d7a487b4e912"), 0, "926f3ac3-1148-4dff-9d34-9657ab04fb56", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc6@gmail.com", false, "Nguyen Van 6", new DateTime(2023, 4, 14, 13, 43, 47, 579, DateTimeKind.Local).AddTicks(7174), false, null, null, null, "611111", "0123456786", false, null, false, "Ten6" },
                    { new Guid("7b958007-9673-4e2e-b296-5680bd9e9e34"), 0, "a11edf2e-de0c-4347-a647-10f1014c30ec", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc5@gmail.com", false, "Nguyen Van 5", new DateTime(2023, 4, 14, 13, 43, 47, 579, DateTimeKind.Local).AddTicks(7086), false, null, null, null, "511111", "0123456785", false, null, false, "Ten5" },
                    { new Guid("386866e3-7f32-4a57-9bfc-3a26c55e3cdc"), 0, "499f2920-12b5-40d1-a649-6fc4abe4a857", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc4@gmail.com", false, "Nguyen Van 4", new DateTime(2023, 4, 14, 13, 43, 47, 579, DateTimeKind.Local).AddTicks(6951), false, null, null, null, "411111", "0123456784", false, null, false, "Ten4" },
                    { new Guid("8025e7ad-d383-4be0-9162-0c307af19fb3"), 0, "7be8eb21-1033-427e-8542-d44953a766e3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc3@gmail.com", false, "Nguyen Van 3", new DateTime(2023, 4, 14, 13, 43, 47, 579, DateTimeKind.Local).AddTicks(6865), false, null, null, null, "311111", "0123456783", false, null, false, "Ten3" },
                    { new Guid("f2a04e65-85bf-421f-8d1a-dd70064497fa"), 0, "4c6b748e-811d-4d8f-a703-8797241c1df9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc2@gmail.com", false, "Nguyen Van 2", new DateTime(2023, 4, 14, 13, 43, 47, 579, DateTimeKind.Local).AddTicks(6737), false, null, null, null, "211111", "0123456782", false, null, false, "Ten2" },
                    { new Guid("242a0b4a-8c81-48c5-be3a-8a42eb1e0c21"), 0, "0aa9d098-19cb-4985-a522-34f0cf2272a5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc1@gmail.com", false, "Nguyen Van 1", new DateTime(2023, 4, 14, 13, 43, 47, 579, DateTimeKind.Local).AddTicks(6652), false, null, null, null, "111111", "0123456781", false, null, false, "Ten1" },
                    { new Guid("bf74d45c-6c03-4f58-86d6-4cd4b92cb2a1"), 0, "4987ffdf-2464-45d3-ade5-666029911564", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc9@gmail.com", false, "Nguyen Van 9", new DateTime(2023, 4, 14, 13, 43, 47, 579, DateTimeKind.Local).AddTicks(7336), false, null, null, null, "911111", "0123456789", false, null, false, "Ten9" },
                    { new Guid("9c1d5dd1-2d8d-4e2c-af9d-7e4f0f699e80"), 0, "4c202d2f-5e18-411c-ac94-e4d7ad611e47", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc0@gmail.com", false, "Nguyen Van 0", new DateTime(2023, 4, 14, 13, 43, 47, 579, DateTimeKind.Local).AddTicks(5750), false, null, null, null, "011111", "0123456780", false, null, false, "Ten0" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_appUserId",
                table: "UserRole",
                column: "appUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_roleIdentityId",
                table: "UserRole",
                column: "roleIdentityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("242a0b4a-8c81-48c5-be3a-8a42eb1e0c21"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2a62a989-5d4f-4654-9d9e-399a31e04b64"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("386866e3-7f32-4a57-9bfc-3a26c55e3cdc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7b958007-9673-4e2e-b296-5680bd9e9e34"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8025e7ad-d383-4be0-9162-0c307af19fb3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9c1d5dd1-2d8d-4e2c-af9d-7e4f0f699e80"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa62aede-b2e2-4c56-8119-e1e713752dc9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf74d45c-6c03-4f58-86d6-4cd4b92cb2a1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7f5e3d2-da96-4682-a506-d7a487b4e912"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f2a04e65-85bf-421f-8d1a-dd70064497fa"));

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FullName", "LastLoginDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2d8c5d9a-1f95-4313-a8f1-db13c18042a5"), 0, "d2da26eb-1f31-4d4b-9cd4-2ba38d60efea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc8@gmail.com", false, "Nguyen Van 8", new DateTime(2023, 4, 13, 15, 3, 55, 936, DateTimeKind.Local).AddTicks(469), false, null, null, null, "811111", "0123456788", false, null, false, "Ten8" },
                    { new Guid("9f55125f-1bdb-47c2-92a6-071fd1f27676"), 0, "d2594372-d4bb-4bc0-b41c-3823558f6234", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc7@gmail.com", false, "Nguyen Van 7", new DateTime(2023, 4, 13, 15, 3, 55, 936, DateTimeKind.Local).AddTicks(382), false, null, null, null, "711111", "0123456787", false, null, false, "Ten7" },
                    { new Guid("67245797-6b85-4370-8fcf-f973473656dd"), 0, "d104dad0-c9d2-4501-bd6f-84ea458607db", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc6@gmail.com", false, "Nguyen Van 6", new DateTime(2023, 4, 13, 15, 3, 55, 936, DateTimeKind.Local).AddTicks(292), false, null, null, null, "611111", "0123456786", false, null, false, "Ten6" },
                    { new Guid("19ed6003-80f4-48cd-b337-f1493f525605"), 0, "b18f3877-8d11-4a2d-8c74-57e60dc52b00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc5@gmail.com", false, "Nguyen Van 5", new DateTime(2023, 4, 13, 15, 3, 55, 936, DateTimeKind.Local).AddTicks(226), false, null, null, null, "511111", "0123456785", false, null, false, "Ten5" },
                    { new Guid("dbacf549-92a3-4dcf-aefe-82c7debfee9c"), 0, "fa65f9e2-52fb-4d76-872a-f9d6221c79e3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc4@gmail.com", false, "Nguyen Van 4", new DateTime(2023, 4, 13, 15, 3, 55, 936, DateTimeKind.Local).AddTicks(162), false, null, null, null, "411111", "0123456784", false, null, false, "Ten4" },
                    { new Guid("6d807717-7c80-4e66-8f00-9b2ba36d6830"), 0, "cc3b4a2a-093a-46d3-95d8-8d0c63a82702", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc3@gmail.com", false, "Nguyen Van 3", new DateTime(2023, 4, 13, 15, 3, 55, 936, DateTimeKind.Local).AddTicks(70), false, null, null, null, "311111", "0123456783", false, null, false, "Ten3" },
                    { new Guid("0cdff0aa-3b04-4de6-b272-7e3396547bfb"), 0, "9719f688-81c4-4d76-bb6c-f7789a6e2714", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc2@gmail.com", false, "Nguyen Van 2", new DateTime(2023, 4, 13, 15, 3, 55, 935, DateTimeKind.Local).AddTicks(9982), false, null, null, null, "211111", "0123456782", false, null, false, "Ten2" },
                    { new Guid("2d489c76-4446-4199-be46-87928b451da2"), 0, "aa5528ea-ab31-4ce1-a5d3-c31e1da35079", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc1@gmail.com", false, "Nguyen Van 1", new DateTime(2023, 4, 13, 15, 3, 55, 935, DateTimeKind.Local).AddTicks(9877), false, null, null, null, "111111", "0123456781", false, null, false, "Ten1" },
                    { new Guid("300ec321-a88d-407e-b11a-214cc6727ab7"), 0, "ee6527a9-04f4-43b1-929a-0cb11399c925", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc9@gmail.com", false, "Nguyen Van 9", new DateTime(2023, 4, 13, 15, 3, 55, 936, DateTimeKind.Local).AddTicks(674), false, null, null, null, "911111", "0123456789", false, null, false, "Ten9" },
                    { new Guid("b473467b-ca85-4eaf-ab08-2096ec4e4ef5"), 0, "a087e1d4-2c73-4695-8045-a6bd4d52c4de", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc0@gmail.com", false, "Nguyen Van 0", new DateTime(2023, 4, 13, 15, 3, 55, 935, DateTimeKind.Local).AddTicks(8862), false, null, null, null, "011111", "0123456780", false, null, false, "Ten0" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_AppUserId",
                table: "UserRoles",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_AppUserId",
                table: "UserRoles",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
