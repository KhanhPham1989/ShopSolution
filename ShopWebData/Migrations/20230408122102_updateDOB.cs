using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebData.Migrations
{
    public partial class updateDOB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1606a152-b05a-4af9-bee2-0b207c5df7b2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1c09930c-34f2-46c2-85dd-d3cad1372941"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2fbdb271-1eae-43b9-b935-0e73a1ea8e46"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("467689f2-c5b9-4c10-8ef4-a27a267bd48e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6306799c-b4de-4177-b17e-7bb0df53a29a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68c31387-f4ab-4021-be68-1ea1023a5705"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a9605d25-e9fc-4501-8cd2-7083b38564e0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c60cdd95-f9f2-40bf-b169-9f8b6925deb6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c90e8924-a844-4aff-a6c9-47b505e578b9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f90ea124-f8f8-4550-8586-aa12372d990e"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LastLoginDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6306799c-b4de-4177-b17e-7bb0df53a29a"), 0, "3ee0309b-7f95-4036-aebd-f66ffd04cc95", "abc8@gmail.com", false, "Nguyen Van 8", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(1014), false, null, null, null, "811111", "0123456788", false, null, false, "Ten8" },
                    { new Guid("c90e8924-a844-4aff-a6c9-47b505e578b9"), 0, "e920f7aa-5b8b-4cfa-9451-e59a932d97c6", "abc7@gmail.com", false, "Nguyen Van 7", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(989), false, null, null, null, "711111", "0123456787", false, null, false, "Ten7" },
                    { new Guid("1606a152-b05a-4af9-bee2-0b207c5df7b2"), 0, "5016a33e-c020-4830-b68a-50e9672088f9", "abc6@gmail.com", false, "Nguyen Van 6", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(963), false, null, null, null, "611111", "0123456786", false, null, false, "Ten6" },
                    { new Guid("467689f2-c5b9-4c10-8ef4-a27a267bd48e"), 0, "73e2b419-9ab0-4b29-92e5-cee7a6bbadd9", "abc5@gmail.com", false, "Nguyen Van 5", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(935), false, null, null, null, "511111", "0123456785", false, null, false, "Ten5" },
                    { new Guid("1c09930c-34f2-46c2-85dd-d3cad1372941"), 0, "d9184807-c222-45d5-a174-db0c7be57454", "abc4@gmail.com", false, "Nguyen Van 4", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(907), false, null, null, null, "411111", "0123456784", false, null, false, "Ten4" },
                    { new Guid("f90ea124-f8f8-4550-8586-aa12372d990e"), 0, "b62fb182-6dbb-47b8-85fb-8ea8fb59b3c4", "abc3@gmail.com", false, "Nguyen Van 3", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(874), false, null, null, null, "311111", "0123456783", false, null, false, "Ten3" },
                    { new Guid("c60cdd95-f9f2-40bf-b169-9f8b6925deb6"), 0, "2a743c52-f48b-48df-9fd2-b6142321934b", "abc2@gmail.com", false, "Nguyen Van 2", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(845), false, null, null, null, "211111", "0123456782", false, null, false, "Ten2" },
                    { new Guid("68c31387-f4ab-4021-be68-1ea1023a5705"), 0, "63ae5b24-3fad-4504-a687-8bfbe93d5a28", "abc1@gmail.com", false, "Nguyen Van 1", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(749), false, null, null, null, "111111", "0123456781", false, null, false, "Ten1" },
                    { new Guid("a9605d25-e9fc-4501-8cd2-7083b38564e0"), 0, "6c2f9e23-aab9-43ea-a710-f32df10e4b9a", "abc9@gmail.com", false, "Nguyen Van 9", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(1040), false, null, null, null, "911111", "0123456789", false, null, false, "Ten9" },
                    { new Guid("2fbdb271-1eae-43b9-b935-0e73a1ea8e46"), 0, "0b81c4a1-fed5-49c8-9612-564e82d7db26", "abc0@gmail.com", false, "Nguyen Van 0", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(211), false, null, null, null, "011111", "0123456780", false, null, false, "Ten0" }
                });
        }
    }
}
