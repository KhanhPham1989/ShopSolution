using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebData.Migrations
{
    public partial class seeddataProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "DateCreated", "Description", "OriginalPrice", "Price", "ProductName", "SeoAlias", "Stock", "ViewCount" },
                values: new object[,]
                {
                    { 5, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 5 cua SamSung", 2005m, 1005m, "SanPham 05", "ABCD5", 15, 25 },
                    { 17, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 17 cua SamSung", 2017m, 1017m, "SanPham 017", "ABCD17", 27, 37 },
                    { 16, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 16 cua SamSung", 2016m, 1016m, "SanPham 016", "ABCD16", 26, 36 },
                    { 15, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 15 cua SamSung", 2015m, 1015m, "SanPham 015", "ABCD15", 25, 35 },
                    { 14, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 14 cua SamSung", 2014m, 1014m, "SanPham 014", "ABCD14", 24, 34 },
                    { 13, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 13 cua SamSung", 2013m, 1013m, "SanPham 013", "ABCD13", 23, 33 },
                    { 12, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 12 cua SamSung", 2012m, 1012m, "SanPham 012", "ABCD12", 22, 32 },
                    { 11, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 11 cua SamSung", 2011m, 1011m, "SanPham 011", "ABCD11", 21, 31 },
                    { 10, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 10 cua SamSung", 2010m, 1010m, "SanPham 010", "ABCD10", 20, 30 },
                    { 9, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 9 cua SamSung", 2009m, 1009m, "SanPham 09", "ABCD9", 19, 29 },
                    { 8, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 8 cua SamSung", 2008m, 1008m, "SanPham 08", "ABCD8", 18, 28 },
                    { 7, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 7 cua SamSung", 2007m, 1007m, "SanPham 07", "ABCD7", 17, 27 },
                    { 6, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 6 cua SamSung", 2006m, 1006m, "SanPham 06", "ABCD6", 16, 26 },
                    { 18, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 18 cua SamSung", 2018m, 1018m, "SanPham 018", "ABCD18", 28, 38 },
                    { 19, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 19 cua SamSung", 2019m, 1019m, "SanPham 019", "ABCD19", 29, 39 },
                    { 3, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 3 cua SamSung", 2003m, 1003m, "SanPham 03", "ABCD3", 13, 23 },
                    { 2, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 2 cua SamSung", 2002m, 1002m, "SanPham 02", "ABCD2", 12, 22 },
                    { 1, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 1 cua SamSung", 2001m, 1001m, "SanPham 01", "ABCD1", 11, 21 },
                    { 4, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Local), "San pham thu 4 cua SamSung", 2004m, 1004m, "SanPham 04", "ABCD4", 14, 24 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LastLoginDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a9605d25-e9fc-4501-8cd2-7083b38564e0"), 0, "6c2f9e23-aab9-43ea-a710-f32df10e4b9a", "abc9@gmail.com", false, "Nguyen Van 9", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(1040), false, null, null, null, "911111", "0123456789", false, null, false, "Ten9" },
                    { new Guid("6306799c-b4de-4177-b17e-7bb0df53a29a"), 0, "3ee0309b-7f95-4036-aebd-f66ffd04cc95", "abc8@gmail.com", false, "Nguyen Van 8", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(1014), false, null, null, null, "811111", "0123456788", false, null, false, "Ten8" },
                    { new Guid("c90e8924-a844-4aff-a6c9-47b505e578b9"), 0, "e920f7aa-5b8b-4cfa-9451-e59a932d97c6", "abc7@gmail.com", false, "Nguyen Van 7", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(989), false, null, null, null, "711111", "0123456787", false, null, false, "Ten7" },
                    { new Guid("1606a152-b05a-4af9-bee2-0b207c5df7b2"), 0, "5016a33e-c020-4830-b68a-50e9672088f9", "abc6@gmail.com", false, "Nguyen Van 6", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(963), false, null, null, null, "611111", "0123456786", false, null, false, "Ten6" },
                    { new Guid("467689f2-c5b9-4c10-8ef4-a27a267bd48e"), 0, "73e2b419-9ab0-4b29-92e5-cee7a6bbadd9", "abc5@gmail.com", false, "Nguyen Van 5", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(935), false, null, null, null, "511111", "0123456785", false, null, false, "Ten5" },
                    { new Guid("1c09930c-34f2-46c2-85dd-d3cad1372941"), 0, "d9184807-c222-45d5-a174-db0c7be57454", "abc4@gmail.com", false, "Nguyen Van 4", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(907), false, null, null, null, "411111", "0123456784", false, null, false, "Ten4" },
                    { new Guid("f90ea124-f8f8-4550-8586-aa12372d990e"), 0, "b62fb182-6dbb-47b8-85fb-8ea8fb59b3c4", "abc3@gmail.com", false, "Nguyen Van 3", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(874), false, null, null, null, "311111", "0123456783", false, null, false, "Ten3" },
                    { new Guid("c60cdd95-f9f2-40bf-b169-9f8b6925deb6"), 0, "2a743c52-f48b-48df-9fd2-b6142321934b", "abc2@gmail.com", false, "Nguyen Van 2", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(845), false, null, null, null, "211111", "0123456782", false, null, false, "Ten2" },
                    { new Guid("68c31387-f4ab-4021-be68-1ea1023a5705"), 0, "63ae5b24-3fad-4504-a687-8bfbe93d5a28", "abc1@gmail.com", false, "Nguyen Van 1", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(749), false, null, null, null, "111111", "0123456781", false, null, false, "Ten1" },
                    { new Guid("2fbdb271-1eae-43b9-b935-0e73a1ea8e46"), 0, "0b81c4a1-fed5-49c8-9612-564e82d7db26", "abc0@gmail.com", false, "Nguyen Van 0", new DateTime(2023, 4, 2, 13, 28, 54, 462, DateTimeKind.Local).AddTicks(211), false, null, null, null, "011111", "0123456780", false, null, false, "Ten0" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19);

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
        }
    }
}
