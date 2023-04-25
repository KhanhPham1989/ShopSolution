using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebData.Migrations
{
    public partial class updateSlideData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Product",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tieude = table.Column<string>(name: "Tieu de", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateCreated",
                value: new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "Tieu de", "Image", "Name", "SortOrder", "Url", "status" },
                values: new object[,]
                {
                    { 4, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit", "/themes/images/carousel/4.png", "Four Thumbnail label", 1, "#", 1 },
                    { 3, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit", "/themes/images/carousel/3.png", "Third Thumbnail label", 1, "#", 1 },
                    { 2, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit", "/themes/images/carousel/2.png", "Second Thumbnail label", 1, "#", 1 },
                    { 1, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit", "/themes/images/carousel/1.png", "First Thumbnail label", 1, "#", 1 },
                    { 5, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit", "/themes/images/carousel/5.png", "Five Thumbnail label", 1, "#", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FullName", "LastLoginDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("cc5bc9a3-0690-43e4-abf7-2e8b6443a94b"), 0, "1d71da81-1676-433b-943b-a74ff10275f0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc9@gmail.com", false, "Nguyen Van 9", new DateTime(2023, 4, 20, 14, 45, 13, 603, DateTimeKind.Local).AddTicks(7269), false, null, null, null, "911111", "0123456789", false, null, false, "Ten9" },
                    { new Guid("4f465c02-e699-4985-a5af-7d282b2cfba9"), 0, "3c2e80c9-772d-47c6-aa47-f4259defc94d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc8@gmail.com", false, "Nguyen Van 8", new DateTime(2023, 4, 20, 14, 45, 13, 603, DateTimeKind.Local).AddTicks(7234), false, null, null, null, "811111", "0123456788", false, null, false, "Ten8" },
                    { new Guid("d807f24a-01fe-4793-8ea1-33be3f039d51"), 0, "b62ad4da-bdda-42ba-822a-79505cd1ddf4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc7@gmail.com", false, "Nguyen Van 7", new DateTime(2023, 4, 20, 14, 45, 13, 603, DateTimeKind.Local).AddTicks(7201), false, null, null, null, "711111", "0123456787", false, null, false, "Ten7" },
                    { new Guid("e19d44dc-0c65-40a6-8fdc-98338ed4fa5c"), 0, "e9ade919-aed3-4266-ac8c-da73ad43f834", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc6@gmail.com", false, "Nguyen Van 6", new DateTime(2023, 4, 20, 14, 45, 13, 603, DateTimeKind.Local).AddTicks(7166), false, null, null, null, "611111", "0123456786", false, null, false, "Ten6" },
                    { new Guid("db6bf2dc-114e-447d-8345-65d844a54aa4"), 0, "a4a09455-fdd5-481f-a298-08d8ffa875da", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc5@gmail.com", false, "Nguyen Van 5", new DateTime(2023, 4, 20, 14, 45, 13, 603, DateTimeKind.Local).AddTicks(7129), false, null, null, null, "511111", "0123456785", false, null, false, "Ten5" },
                    { new Guid("3dbe8bd5-329a-40db-b09d-2f4492b4ed79"), 0, "c891668e-23f1-4942-a723-daa44137b628", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc4@gmail.com", false, "Nguyen Van 4", new DateTime(2023, 4, 20, 14, 45, 13, 603, DateTimeKind.Local).AddTicks(7094), false, null, null, null, "411111", "0123456784", false, null, false, "Ten4" },
                    { new Guid("658013fc-0269-482b-b83c-c69b8a404376"), 0, "f5cedbf3-c805-48b1-a012-497a4410b36c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc3@gmail.com", false, "Nguyen Van 3", new DateTime(2023, 4, 20, 14, 45, 13, 603, DateTimeKind.Local).AddTicks(7055), false, null, null, null, "311111", "0123456783", false, null, false, "Ten3" },
                    { new Guid("dd0e727d-2593-48fd-9a1f-52aefea52151"), 0, "884a12c0-982a-448d-bf13-5571cf697640", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc2@gmail.com", false, "Nguyen Van 2", new DateTime(2023, 4, 20, 14, 45, 13, 603, DateTimeKind.Local).AddTicks(6958), false, null, null, null, "211111", "0123456782", false, null, false, "Ten2" },
                    { new Guid("8f3a83c9-f093-446a-914e-eebb77386b44"), 0, "4ec0b5b5-a5bd-4c78-ac5d-9fffeb723da6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc1@gmail.com", false, "Nguyen Van 1", new DateTime(2023, 4, 20, 14, 45, 13, 603, DateTimeKind.Local).AddTicks(6894), false, null, null, null, "111111", "0123456781", false, null, false, "Ten1" },
                    { new Guid("b5a7203e-bde8-4e07-9185-3c73603ea552"), 0, "8ae54033-4cf6-4c9a-8bda-4f4873fa9943", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc0@gmail.com", false, "Nguyen Van 0", new DateTime(2023, 4, 20, 14, 45, 13, 603, DateTimeKind.Local).AddTicks(6198), false, null, null, null, "011111", "0123456780", false, null, false, "Ten0" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3dbe8bd5-329a-40db-b09d-2f4492b4ed79"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4f465c02-e699-4985-a5af-7d282b2cfba9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("658013fc-0269-482b-b83c-c69b8a404376"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8f3a83c9-f093-446a-914e-eebb77386b44"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b5a7203e-bde8-4e07-9185-3c73603ea552"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cc5bc9a3-0690-43e4-abf7-2e8b6443a94b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d807f24a-01fe-4793-8ea1-33be3f039d51"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("db6bf2dc-114e-447d-8345-65d844a54aa4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd0e727d-2593-48fd-9a1f-52aefea52151"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e19d44dc-0c65-40a6-8fdc-98338ed4fa5c"));

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Product");

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
    }
}