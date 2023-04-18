using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebData.Migrations
{
    public partial class updateUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("14f326e1-931b-4e58-a732-e02f94d9726c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2f3ffb72-6a19-40b5-b7f8-9808e95201ef"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3558cbdc-4e73-4e30-b2ef-c8d8dcb5d87f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("73844bce-f335-477b-bee9-0397786c7062"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("745ac30e-5e6c-49b3-a37f-74e4c5420093"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("915e53c1-0ab1-4ab0-9c0e-3793c146c693"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97b0a477-4650-4875-8c26-15ce2767efb6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a82eeec0-ba3d-4d1f-b65c-35c83cdc6c54"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b9b5c492-d9a5-4491-a115-e3fa40f805bd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e4639848-dc9d-4db1-a861-090cefdf66ff"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FullName", "LastLoginDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("745ac30e-5e6c-49b3-a37f-74e4c5420093"), 0, "66ec0be5-1d9c-4d01-944d-b342fd7346ff", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc8@gmail.com", false, "Nguyen Van 8", new DateTime(2023, 4, 8, 19, 21, 0, 963, DateTimeKind.Local).AddTicks(8545), false, null, null, null, "811111", "0123456788", false, null, false, "Ten8" },
                    { new Guid("e4639848-dc9d-4db1-a861-090cefdf66ff"), 0, "dc4f1537-5b7b-4442-a8ee-3c0d1503b7a0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc7@gmail.com", false, "Nguyen Van 7", new DateTime(2023, 4, 8, 19, 21, 0, 963, DateTimeKind.Local).AddTicks(8520), false, null, null, null, "711111", "0123456787", false, null, false, "Ten7" },
                    { new Guid("915e53c1-0ab1-4ab0-9c0e-3793c146c693"), 0, "4cc02965-fa2d-4026-b95a-56fc6d3f49a7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc6@gmail.com", false, "Nguyen Van 6", new DateTime(2023, 4, 8, 19, 21, 0, 963, DateTimeKind.Local).AddTicks(8498), false, null, null, null, "611111", "0123456786", false, null, false, "Ten6" },
                    { new Guid("73844bce-f335-477b-bee9-0397786c7062"), 0, "519b295e-4be9-42e9-ae4e-a616dfa3cf23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc5@gmail.com", false, "Nguyen Van 5", new DateTime(2023, 4, 8, 19, 21, 0, 963, DateTimeKind.Local).AddTicks(8473), false, null, null, null, "511111", "0123456785", false, null, false, "Ten5" },
                    { new Guid("2f3ffb72-6a19-40b5-b7f8-9808e95201ef"), 0, "92ca138f-0d3c-41c3-9220-af25658156c5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc4@gmail.com", false, "Nguyen Van 4", new DateTime(2023, 4, 8, 19, 21, 0, 963, DateTimeKind.Local).AddTicks(8398), false, null, null, null, "411111", "0123456784", false, null, false, "Ten4" },
                    { new Guid("a82eeec0-ba3d-4d1f-b65c-35c83cdc6c54"), 0, "982c6641-2b57-4627-9df1-06af2e0a6265", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc3@gmail.com", false, "Nguyen Van 3", new DateTime(2023, 4, 8, 19, 21, 0, 963, DateTimeKind.Local).AddTicks(8371), false, null, null, null, "311111", "0123456783", false, null, false, "Ten3" },
                    { new Guid("14f326e1-931b-4e58-a732-e02f94d9726c"), 0, "2cc07ff8-e5c6-4fe4-9504-bdab3220ef9d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc2@gmail.com", false, "Nguyen Van 2", new DateTime(2023, 4, 8, 19, 21, 0, 963, DateTimeKind.Local).AddTicks(8347), false, null, null, null, "211111", "0123456782", false, null, false, "Ten2" },
                    { new Guid("b9b5c492-d9a5-4491-a115-e3fa40f805bd"), 0, "4ce7a240-aa3a-45cc-8459-1a6d66ecaa43", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc1@gmail.com", false, "Nguyen Van 1", new DateTime(2023, 4, 8, 19, 21, 0, 963, DateTimeKind.Local).AddTicks(8305), false, null, null, null, "111111", "0123456781", false, null, false, "Ten1" },
                    { new Guid("97b0a477-4650-4875-8c26-15ce2767efb6"), 0, "9ca28e98-6a75-4bf7-a9b6-4af9a9b5810f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc9@gmail.com", false, "Nguyen Van 9", new DateTime(2023, 4, 8, 19, 21, 0, 963, DateTimeKind.Local).AddTicks(8568), false, null, null, null, "911111", "0123456789", false, null, false, "Ten9" },
                    { new Guid("3558cbdc-4e73-4e30-b2ef-c8d8dcb5d87f"), 0, "962bbb54-170e-4ec0-991d-7c53ad19a1c8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc0@gmail.com", false, "Nguyen Van 0", new DateTime(2023, 4, 8, 19, 21, 0, 963, DateTimeKind.Local).AddTicks(7796), false, null, null, null, "011111", "0123456780", false, null, false, "Ten0" }
                });
        }
    }
}
