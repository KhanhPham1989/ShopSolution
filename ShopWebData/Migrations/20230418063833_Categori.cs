using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebData.Migrations
{
    public partial class Categori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "CateName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FullName", "LastLoginDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7fe68c06-4005-4e6c-990c-4f0de1cb50ee"), 0, "c96fcd3a-d9b1-49a6-b096-736b9e2922b0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc8@gmail.com", false, "Nguyen Van 8", new DateTime(2023, 4, 18, 13, 38, 32, 818, DateTimeKind.Local).AddTicks(1822), false, null, null, null, "811111", "0123456788", false, null, false, "Ten8" },
                    { new Guid("87b1fbab-8c4a-4b6e-9bab-0f2695bcc627"), 0, "483da0fb-f355-46b2-b789-2674b5caeb49", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc7@gmail.com", false, "Nguyen Van 7", new DateTime(2023, 4, 18, 13, 38, 32, 818, DateTimeKind.Local).AddTicks(1799), false, null, null, null, "711111", "0123456787", false, null, false, "Ten7" },
                    { new Guid("7e0c76da-b1e9-47d3-be49-abe208c1b01b"), 0, "7ca7fc04-15fd-4d49-ae9e-1ba09c436b9b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc6@gmail.com", false, "Nguyen Van 6", new DateTime(2023, 4, 18, 13, 38, 32, 818, DateTimeKind.Local).AddTicks(1775), false, null, null, null, "611111", "0123456786", false, null, false, "Ten6" },
                    { new Guid("e449fa2c-de93-4cce-b28b-dcf347c82609"), 0, "83ebe65d-4494-473e-832d-0b10f5d05dda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc5@gmail.com", false, "Nguyen Van 5", new DateTime(2023, 4, 18, 13, 38, 32, 818, DateTimeKind.Local).AddTicks(1750), false, null, null, null, "511111", "0123456785", false, null, false, "Ten5" },
                    { new Guid("b0b8ab4c-1d2b-4053-9b3b-d88b150fc96f"), 0, "0c2dd75f-e16a-4b74-a4c2-b53161076a70", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc4@gmail.com", false, "Nguyen Van 4", new DateTime(2023, 4, 18, 13, 38, 32, 818, DateTimeKind.Local).AddTicks(1720), false, null, null, null, "411111", "0123456784", false, null, false, "Ten4" },
                    { new Guid("020f1f5c-cac3-4def-b6a5-e7f40032426d"), 0, "0c094c7f-5aab-4d5d-aacb-2e48f3c6a1e6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc3@gmail.com", false, "Nguyen Van 3", new DateTime(2023, 4, 18, 13, 38, 32, 818, DateTimeKind.Local).AddTicks(1695), false, null, null, null, "311111", "0123456783", false, null, false, "Ten3" },
                    { new Guid("dc216351-d06e-4760-b5e6-2e4375a2354a"), 0, "59db22c4-4cc7-4d29-8a97-39c289c789dc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc2@gmail.com", false, "Nguyen Van 2", new DateTime(2023, 4, 18, 13, 38, 32, 818, DateTimeKind.Local).AddTicks(1668), false, null, null, null, "211111", "0123456782", false, null, false, "Ten2" },
                    { new Guid("a138bf59-b631-472c-b761-7c70678f9f0c"), 0, "1948a70e-9bd7-443d-bb0e-e356e0120dc2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc1@gmail.com", false, "Nguyen Van 1", new DateTime(2023, 4, 18, 13, 38, 32, 818, DateTimeKind.Local).AddTicks(1618), false, null, null, null, "111111", "0123456781", false, null, false, "Ten1" },
                    { new Guid("94f09981-ac99-482b-a998-86a77e21f4b5"), 0, "accab2da-1ff0-4584-a541-a3498798de6d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc9@gmail.com", false, "Nguyen Van 9", new DateTime(2023, 4, 18, 13, 38, 32, 818, DateTimeKind.Local).AddTicks(1893), false, null, null, null, "911111", "0123456789", false, null, false, "Ten9" },
                    { new Guid("5943298b-711e-4007-98de-dca5d30821fb"), 0, "8acc4c64-1f0c-4024-b5df-9e00007de876", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc0@gmail.com", false, "Nguyen Van 0", new DateTime(2023, 4, 18, 13, 38, 32, 818, DateTimeKind.Local).AddTicks(1023), false, null, null, null, "011111", "0123456780", false, null, false, "Ten0" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("020f1f5c-cac3-4def-b6a5-e7f40032426d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5943298b-711e-4007-98de-dca5d30821fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7e0c76da-b1e9-47d3-be49-abe208c1b01b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7fe68c06-4005-4e6c-990c-4f0de1cb50ee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87b1fbab-8c4a-4b6e-9bab-0f2695bcc627"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("94f09981-ac99-482b-a998-86a77e21f4b5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a138bf59-b631-472c-b761-7c70678f9f0c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0b8ab4c-1d2b-4053-9b3b-d88b150fc96f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dc216351-d06e-4760-b5e6-2e4375a2354a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e449fa2c-de93-4cce-b28b-dcf347c82609"));

            migrationBuilder.DropColumn(
                name: "CateName",
                table: "Category");

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
        }
    }
}
