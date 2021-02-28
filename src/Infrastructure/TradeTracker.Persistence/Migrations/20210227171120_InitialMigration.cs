using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeTracker.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccessTag = table.Column<string>(type: "TEXT", nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Symbol = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionType = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", nullable: false),
                    Notional = table.Column<decimal>(type: "TEXT", nullable: false),
                    TradePrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("07ccf096-451d-4702-9554-56785abb3a5a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 20, 16, 22, 0, 0, DateTimeKind.Utc), null, null, 118.68m, 2.43m, "I", 48.84m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e9fbfda1-40c9-4a46-b5f3-3fd5217bf6e5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 24, 18, 56, 0, 0, DateTimeKind.Utc), null, null, 263.03m, 4.44m, "S", 59.24m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f0246820-96f9-4bd2-8dbf-596f77070b06"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 13, 17, 35, 0, 0, DateTimeKind.Utc), null, null, 15.99m, 2.85m, "ZJM", 5.61m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f7dab48d-ef33-43ef-b1a1-361ee62f6d07"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 18, 18, 46, 0, 0, DateTimeKind.Utc), null, null, 22.10m, 0.86m, "VDJ", 25.7m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9321b67a-c0e8-49fd-994f-6b844e6d3b73"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 20, 16, 49, 0, 0, DateTimeKind.Utc), null, null, 171.32m, 2.10m, "KL", 81.58m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a60475e6-666d-4c1f-b678-5e05ceaf1371"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 19, 14, 53, 0, 0, DateTimeKind.Utc), null, null, 24.02m, 1.13m, "ZP", 21.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6a6428f6-4753-4ae0-b549-46ee79baf16e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 6, 17, 16, 0, 0, DateTimeKind.Utc), null, null, 196.41m, 2.84m, "OZ", 69.16m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ba1b472d-0a33-4d5b-845a-eb7f9fcb27ff"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 31, 15, 25, 0, 0, DateTimeKind.Utc), null, null, 140.57m, 2.86m, "W", 49.15m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e353b984-5d35-4348-96a2-cdc40c041d2f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 23, 18, 9, 0, 0, DateTimeKind.Utc), null, null, 19.32m, 2.85m, "QN", 6.78m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("075ecdd8-df1d-429a-9b6b-323e36fc0038"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 11, 18, 6, 0, 0, DateTimeKind.Utc), null, null, 81.83m, 4.22m, "G", 19.39m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("02b47264-d109-4135-b341-5205930eb5cf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 2, 18, 55, 0, 0, DateTimeKind.Utc), null, null, 183.40m, 2.96m, "XN", 61.96m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("910752ea-fe3c-4c4d-9ffc-7c1bb8315d9e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 13, 16, 17, 0, 0, DateTimeKind.Utc), null, null, 382.78m, 4.07m, "BPH", 94.05m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("216b0f9b-7c71-4862-9bae-5858c5f7e637"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 19, 18, 11, 0, 0, DateTimeKind.Utc), null, null, 232.14m, 3.83m, "GJ", 60.61m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fef35702-c104-4af2-a38a-9334ef55b3d3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 18, 19, 13, 0, 0, DateTimeKind.Utc), null, null, 135.15m, 1.92m, "Y", 70.39m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1a31084b-0105-473a-9e04-a586f7b33d95"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 15, 4, 0, 0, DateTimeKind.Utc), null, null, 89.21m, 1.01m, "GR", 88.33m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("22cd8a00-fd78-4000-9f9b-a916da1b4dbb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 15, 27, 0, 0, DateTimeKind.Utc), null, null, 3.48m, 0.12m, "WP", 28.97m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ec22663f-2831-478a-bc0e-79d506e3b368"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 12, 16, 4, 0, 0, DateTimeKind.Utc), null, null, 121.77m, 1.54m, "MQ", 79.07m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("42948d36-1a8f-4e37-8324-e3b1a19498a4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 4, 16, 32, 0, 0, DateTimeKind.Utc), null, null, 406.83m, 4.83m, "VXO", 84.23m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("850a110b-4a9c-4be3-b9bb-8f33426e2b49"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 3, 18, 33, 0, 0, DateTimeKind.Utc), null, null, 48.71m, 3.53m, "K", 13.8m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b5a7fadc-8583-4118-85e8-8fa75d6332bf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 2, 16, 55, 0, 0, DateTimeKind.Utc), null, null, 5.34m, 1.56m, "DA", 3.42m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a709ff60-955a-4668-872d-7426923abba0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 28, 19, 7, 0, 0, DateTimeKind.Utc), null, null, 215.31m, 2.82m, "SV", 76.35m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8a39400c-8ade-4b70-a14d-ca2fe9492fd5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 13, 15, 43, 0, 0, DateTimeKind.Utc), null, null, 10.03m, 1.56m, "J", 6.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("17f796d6-58ec-4700-9fbd-b953ab2d8de8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 12, 20, 19, 0, 0, DateTimeKind.Utc), null, null, 30.13m, 3.09m, "XX", 9.75m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dcb99489-4d69-4910-98d4-d23054369109"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 10, 20, 19, 0, 0, DateTimeKind.Utc), null, null, 22.27m, 1.48m, "GYR", 15.05m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b65e9d44-8424-41b1-8c2b-7598a0eeb58e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 12, 16, 7, 0, 0, DateTimeKind.Utc), null, null, 6.13m, 3.83m, "E", 1.6m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3b2d2cf4-5e35-4e9d-ba8e-7ca0b4be247e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 4, 14, 54, 0, 0, DateTimeKind.Utc), null, null, 21.15m, 0.38m, "FKT", 55.67m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0f706043-2e1b-4a17-b790-112129907f3b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 28, 15, 55, 0, 0, DateTimeKind.Utc), null, null, 25.70m, 0.52m, "XC", 49.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("676f3cec-25f0-43b5-aa72-10c70b657cf5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 9, 18, 20, 0, 0, DateTimeKind.Utc), null, null, 72.60m, 0.79m, "INP", 91.9m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("281e2e45-40e6-4ff0-9f4b-b15bcea01c32"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 26, 15, 9, 0, 0, DateTimeKind.Utc), null, null, 262.55m, 3.70m, "DQU", 70.96m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c5d38176-b8ca-48c8-90a0-9624840ffe24"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 2, 19, 17, 0, 0, DateTimeKind.Utc), null, null, 1.66m, 0.12m, "DGJ", 13.84m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("eefeedff-ee00-4d3e-8bc0-22aa67cdfccd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 13, 18, 18, 0, 0, DateTimeKind.Utc), null, null, 127.62m, 3.01m, "L", 42.4m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("aec637c2-8f10-45d6-9655-7c4a60bd9f03"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 29, 18, 44, 0, 0, DateTimeKind.Utc), null, null, 3.88m, 0.50m, "WC", 7.75m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0271211a-7857-4a69-bc32-e024c24705f0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 13, 18, 21, 0, 0, DateTimeKind.Utc), null, null, 348.20m, 4.87m, "OS", 71.5m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cd3d2a2b-866f-41c6-bf64-622bfdfc58da"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 16, 4, 0, 0, DateTimeKind.Utc), null, null, 92.35m, 3.31m, "C", 27.9m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("90040c92-f9f2-429c-ae4d-c06bf6b5709d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 23, 18, 0, 0, 0, DateTimeKind.Utc), null, null, 4.67m, 0.05m, "FI", 93.31m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3c9d7da0-c1e3-41f9-8227-5a42f0bbbf91"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 31, 14, 57, 0, 0, DateTimeKind.Utc), null, null, 210.22m, 3.31m, "XJ", 63.51m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d7349dd4-54ec-4958-bcae-0591292a632b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 11, 15, 21, 0, 0, DateTimeKind.Utc), null, null, 68.22m, 0.85m, "AW", 80.26m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("48f23810-51ed-432b-9cf5-0fbb0fba5d00"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 18, 15, 0, 0, 0, DateTimeKind.Utc), null, null, 329.55m, 3.75m, "JN", 87.88m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e956ab74-132f-4bf0-bc77-0684806bd6e8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 27, 20, 50, 0, 0, DateTimeKind.Utc), null, null, 309.16m, 3.32m, "ITX", 93.12m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c147142a-e956-46cf-86f9-5cb2363708f3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 21, 17, 14, 0, 0, DateTimeKind.Utc), null, null, 15.06m, 0.70m, "OV", 21.52m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("197c8a23-bf12-4cf1-b68c-b2008a124d46"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 20, 52, 0, 0, DateTimeKind.Utc), null, null, 88.19m, 1.19m, "GU", 74.11m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bf4670ca-a2e4-4ac3-8d6e-b0e3f8a40df4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 16, 4, 0, 0, DateTimeKind.Utc), null, null, 60.26m, 3.01m, "ON", 20.02m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ac15c05a-d9a3-4aa5-ab41-53c7b885b072"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 28, 17, 7, 0, 0, DateTimeKind.Utc), null, null, 16.36m, 0.23m, "H", 71.13m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3028a8ce-75b4-4574-ae03-6195e65e829d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 4, 16, 50, 0, 0, DateTimeKind.Utc), null, null, 73.97m, 2.43m, "TE", 30.44m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d9e37d3e-039c-45b3-b60b-6c8b74d95d79"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 13, 15, 59, 0, 0, DateTimeKind.Utc), null, null, 38.02m, 1.98m, "QXD", 19.2m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("03932780-5e2f-400e-aceb-3c23ddcda033"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 2, 17, 57, 0, 0, DateTimeKind.Utc), null, null, 100.87m, 2.20m, "WIC", 45.85m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("abf9a3ce-2970-4965-9395-37684f673981"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 29, 19, 59, 0, 0, DateTimeKind.Utc), null, null, 106.43m, 2.90m, "VYX", 36.7m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5477ec72-84d7-4241-a104-b91a4d9862e4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 14, 18, 39, 0, 0, DateTimeKind.Utc), null, null, 52.89m, 1.50m, "TLI", 35.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("48419212-f490-4efd-8004-020562157bee"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 11, 15, 55, 0, 0, DateTimeKind.Utc), null, null, 35.54m, 1.83m, "RJ", 19.42m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9bbfc65f-9457-48e6-8822-c7876c6db52b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 22, 16, 30, 0, 0, DateTimeKind.Utc), null, null, 46.36m, 1.19m, "QQH", 38.96m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3a860ccd-1582-4d54-9e05-843196cfc2f2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 29, 20, 42, 0, 0, DateTimeKind.Utc), null, null, 21.23m, 0.26m, "P", 81.65m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7b6f2bb4-e9d8-4434-b97b-6919f2975301"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 20, 15, 6, 0, 0, DateTimeKind.Utc), null, null, 255.92m, 4.98m, "TJC", 51.39m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("601add75-67c2-4cb9-8543-36b3e95437ed"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 17, 43, 0, 0, DateTimeKind.Utc), null, null, 213.95m, 2.82m, "I", 75.87m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("75a57c17-d523-48d5-ba58-c6632a47aa97"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 12, 20, 8, 0, 0, DateTimeKind.Utc), null, null, 38.18m, 2.37m, "V", 16.11m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f9fd6d47-8be8-4043-ba08-83026f6bc06b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 2, 20, 43, 0, 0, DateTimeKind.Utc), null, null, 16.38m, 2.00m, "OI", 8.19m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7a1b9ff6-8534-4d3b-be4a-27e2684651d8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 18, 37, 0, 0, DateTimeKind.Utc), null, null, 38.10m, 0.72m, "VC", 52.91m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a7d18ee4-92f4-49e9-a4aa-c5a7385f23a8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 20, 18, 23, 0, 0, DateTimeKind.Utc), null, null, 54.90m, 1.11m, "Q", 49.46m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("33d056cd-f62a-42e2-a849-588736bfda34"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 25, 15, 47, 0, 0, DateTimeKind.Utc), null, null, 98.19m, 4.36m, "ZY", 22.52m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("22f7fb20-e7f4-4278-bcf8-9e042d3dcf07"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 29, 19, 37, 0, 0, DateTimeKind.Utc), null, null, 126.26m, 4.63m, "O", 27.27m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8ab759ec-b7c7-414a-869d-0664706da9c4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 21, 15, 57, 0, 0, DateTimeKind.Utc), null, null, 160.52m, 3.60m, "NDZ", 44.59m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("eed8efa6-593b-4987-80bc-6e5f66c8d613"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 5, 15, 46, 0, 0, DateTimeKind.Utc), null, null, 31.43m, 0.91m, "NJ", 34.54m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("95db8b1a-f8ff-4178-a479-c1b4c53517f1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 12, 17, 26, 0, 0, DateTimeKind.Utc), null, null, 31.14m, 3.43m, "FEZ", 9.08m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0bef7aff-79fb-46da-aa83-1adf04364817"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 19, 17, 26, 0, 0, DateTimeKind.Utc), null, null, 88.28m, 3.41m, "LG", 25.89m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("96701279-5578-4b30-bd7c-b26a72602104"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 26, 17, 37, 0, 0, DateTimeKind.Utc), null, null, 14.61m, 0.15m, "GX", 97.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9a5cf004-28a2-4237-963d-a95b755b7664"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 8, 19, 5, 0, 0, DateTimeKind.Utc), null, null, 201.34m, 2.49m, "VMG", 80.86m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("92c73f55-984f-451d-9a81-a5e01a6957fb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 28, 20, 19, 0, 0, DateTimeKind.Utc), null, null, 39.07m, 2.23m, "A", 17.52m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("40bf00af-d3c3-4195-b517-aaad5dcfaf72"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 8, 16, 39, 0, 0, DateTimeKind.Utc), null, null, 116.36m, 1.54m, "IY", 75.56m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d3f39da6-0cd7-4ae7-8cb8-e0a3f215da02"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 4, 17, 42, 0, 0, DateTimeKind.Utc), null, null, 103.60m, 4.55m, "WOE", 22.77m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e90c1804-3a65-4f6b-a915-f931fd55fe22"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 4, 16, 20, 0, 0, DateTimeKind.Utc), null, null, 40.92m, 0.54m, "A", 75.78m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1810f71b-e2c7-43ec-8ab1-baabd7416ff4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 6, 20, 6, 0, 0, DateTimeKind.Utc), null, null, 309.34m, 3.97m, "JH", 77.92m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("915758f7-b0ee-45aa-aa36-80fe37f717c4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 18, 17, 2, 0, 0, DateTimeKind.Utc), null, null, 361.71m, 4.70m, "I", 76.96m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0652cac5-4db9-43e7-8b01-7a5de063f6b6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 3, 15, 20, 0, 0, DateTimeKind.Utc), null, null, 12.04m, 0.16m, "S", 75.25m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b7c68ea4-0ead-4140-9b4c-50bd37de7626"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 14, 20, 2, 0, 0, DateTimeKind.Utc), null, null, 118.44m, 1.32m, "TG", 89.73m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e6a988fc-91d3-466a-b12c-c9b07340322d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 7, 19, 4, 0, 0, DateTimeKind.Utc), null, null, 8.43m, 0.10m, "VF", 84.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2891090d-5832-40c1-b3dc-e746b6958824"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 3, 17, 16, 0, 0, DateTimeKind.Utc), null, null, 34.07m, 4.15m, "YID", 8.21m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e51a60e2-9325-45bb-b350-c1a84c3efd0a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 13, 19, 42, 0, 0, DateTimeKind.Utc), null, null, 128.56m, 3.60m, "CYA", 35.71m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("430a1639-5ed7-4c4b-beac-2def9a872897"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 9, 18, 27, 0, 0, DateTimeKind.Utc), null, null, 15.16m, 0.52m, "NMB", 29.16m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("929b2382-613d-4da3-a03e-e111d963b656"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 10, 19, 24, 0, 0, DateTimeKind.Utc), null, null, 17.12m, 1.35m, "OB", 12.68m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7b6bec8f-e134-495b-9ad5-baf2a8a9e965"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 9, 18, 21, 0, 0, DateTimeKind.Utc), null, null, 56.71m, 0.62m, "SFY", 91.46m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3865cff7-ce1a-4f00-91ca-ace034fd4f0c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 3, 15, 25, 0, 0, DateTimeKind.Utc), null, null, 31.10m, 2.42m, "J", 12.85m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2f13ea24-cfe3-477e-ac08-1c17d4fcf177"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 5, 16, 58, 0, 0, DateTimeKind.Utc), null, null, 306.77m, 3.22m, "H", 95.27m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8b9243ac-a39c-41d1-9ad8-28f68f4f0fc5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 20, 14, 51, 0, 0, DateTimeKind.Utc), null, null, 27.83m, 0.37m, "IG", 75.22m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("226fdc14-8c6a-4e8e-a6a2-00c95166ed74"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 18, 48, 0, 0, DateTimeKind.Utc), null, null, 69.18m, 1.05m, "WOA", 65.89m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f6a803f5-0aa6-4771-84fe-1505f2de47f9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 19, 15, 39, 0, 0, DateTimeKind.Utc), null, null, 4.51m, 0.51m, "DSW", 8.84m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("17f978a4-ac44-4b76-9c3e-c98e6d3543a6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 11, 17, 27, 0, 0, DateTimeKind.Utc), null, null, 51.13m, 0.78m, "YIY", 65.55m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("def35a20-0ca6-4bce-8342-b7a214fbeccf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 10, 15, 55, 0, 0, DateTimeKind.Utc), null, null, 71.01m, 3.54m, "OD", 20.06m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("265809f7-fc5f-46af-83bc-9d43b915dc5b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 9, 20, 32, 0, 0, DateTimeKind.Utc), null, null, 205.05m, 2.98m, "CP", 68.81m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ba78963f-fd71-4ae7-99cb-79baadcc8fbf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 19, 16, 26, 0, 0, DateTimeKind.Utc), null, null, 21.26m, 0.44m, "ILR", 48.32m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("012dfe95-b1e6-4301-8a27-0ee6b53c08ff"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 4, 15, 19, 0, 0, DateTimeKind.Utc), null, null, 4.08m, 0.25m, "LXU", 16.31m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6c2e305a-1e1c-442b-96df-3e4b1cb3ce46"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 8, 20, 51, 0, 0, DateTimeKind.Utc), null, null, 176.60m, 1.85m, "ARY", 95.46m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7ad83940-8e2e-4e88-bece-6566c276d76b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 15, 19, 8, 0, 0, DateTimeKind.Utc), null, null, 191.58m, 3.20m, "P", 59.87m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b060f6c8-509a-4e61-a410-4474e9868a7a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 2, 19, 9, 0, 0, DateTimeKind.Utc), null, null, 136.36m, 2.20m, "GWA", 61.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9d0acf07-2e70-4af6-b516-a57152182101"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 13, 18, 26, 0, 0, DateTimeKind.Utc), null, null, 150.50m, 2.59m, "W", 58.11m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4fc847c2-45e5-4a6c-8bb3-08cdcc6a277d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 23, 15, 52, 0, 0, DateTimeKind.Utc), null, null, 344.66m, 4.39m, "EWA", 78.51m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9de7ca00-86c1-439b-8f71-deb9a1c0f650"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 19, 21, 0, 0, DateTimeKind.Utc), null, null, 36.57m, 3.54m, "VWA", 10.33m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3f31616a-41f0-4a5b-b26c-b84977ec5183"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 6, 19, 1, 0, 0, DateTimeKind.Utc), null, null, 63.57m, 0.91m, "GOZ", 69.86m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cea5c14e-1776-4244-bcd0-f44b6072db3b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 3, 20, 20, 0, 0, DateTimeKind.Utc), null, null, 148.41m, 3.39m, "BBO", 43.78m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("541e2392-6ddc-4643-a7ca-89b6e18c298f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 31, 16, 29, 0, 0, DateTimeKind.Utc), null, null, 72.10m, 1.21m, "CHR", 59.59m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5bc3b35a-0af0-4c97-b9fd-12e9bf900e83"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 11, 16, 18, 0, 0, DateTimeKind.Utc), null, null, 125.67m, 2.42m, "KS", 51.93m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("37820bb1-0467-4e35-a549-2456c59f90e9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 14, 19, 28, 0, 0, DateTimeKind.Utc), null, null, 11.75m, 0.15m, "D", 78.36m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8a71b09d-4f48-45f5-8023-b4715d36d976"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 20, 20, 18, 0, 0, DateTimeKind.Utc), null, null, 27.96m, 2.33m, "M", 12m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d8551d9a-5738-459c-b29c-2db26341ce7f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 4, 16, 52, 0, 0, DateTimeKind.Utc), null, null, 22.84m, 0.59m, "RO", 38.71m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("456e5ad0-8731-4b5e-9886-5c1d8eae6ef5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 22, 18, 20, 0, 0, DateTimeKind.Utc), null, null, 193.42m, 3.32m, "MV", 58.26m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0d0dce6e-7369-4939-88b9-b20a79466080"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 20, 18, 50, 0, 0, DateTimeKind.Utc), null, null, 464.35m, 4.72m, "FPO", 98.38m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9a8e081d-4950-40c5-9016-34d89ff21a64"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 14, 20, 16, 0, 0, DateTimeKind.Utc), null, null, 104.34m, 3.14m, "VC", 33.23m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4e02be52-ee22-4a01-b6a0-2cdd67455ac5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 3, 14, 42, 0, 0, DateTimeKind.Utc), null, null, 80.86m, 0.87m, "O", 92.94m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("aa4d2325-72ee-4ae3-b00b-a4ebcece5228"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 29, 18, 47, 0, 0, DateTimeKind.Utc), null, null, 172.81m, 4.07m, "ZOD", 42.46m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4e37ea6e-37ed-4a1e-a9ac-dd5f48c7aef9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 8, 18, 37, 0, 0, DateTimeKind.Utc), null, null, 24.08m, 2.09m, "X", 11.52m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("191db074-4c98-4109-9c21-2e27c01ccde9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 21, 20, 26, 0, 0, DateTimeKind.Utc), null, null, 119.72m, 1.77m, "WNP", 67.64m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("58bedc39-82ea-4ae8-b945-0c1f2997db18"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 15, 17, 49, 0, 0, DateTimeKind.Utc), null, null, 57.02m, 1.64m, "CR", 34.77m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c9308af4-64df-4ebc-891a-ebe4d89bcde9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 4, 20, 29, 0, 0, DateTimeKind.Utc), null, null, 63.74m, 1.48m, "T", 43.07m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7fdda0b3-5ff9-4d39-a754-f404be884807"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 19, 19, 25, 0, 0, DateTimeKind.Utc), null, null, 70.91m, 2.44m, "P", 29.06m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d00d7400-07cb-42de-8a44-2c1eea1c70d5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 18, 18, 27, 0, 0, DateTimeKind.Utc), null, null, 110.86m, 3.38m, "K", 32.8m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8984c0d3-4d47-4f88-8289-cbf68a240326"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 22, 20, 40, 0, 0, DateTimeKind.Utc), null, null, 139.31m, 4.09m, "JQ", 34.06m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5bfa6b64-022b-48ef-8f79-ab5a27b4edee"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 22, 17, 37, 0, 0, DateTimeKind.Utc), null, null, 116.18m, 1.54m, "H", 75.44m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("201eea0d-0620-47e9-b404-df747c53b1c2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 16, 18, 47, 0, 0, DateTimeKind.Utc), null, null, 163.90m, 2.17m, "F", 75.53m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7fc036c4-ed9c-44c8-8732-09e2e6ee95da"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 21, 20, 20, 0, 0, DateTimeKind.Utc), null, null, 245.41m, 4.81m, "NAD", 51.02m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b0998a1b-8221-4eed-a8d6-846b7db87a5f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 3, 17, 19, 0, 0, DateTimeKind.Utc), null, null, 301.77m, 4.05m, "C", 74.51m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5fe99e74-4fc3-4f47-be42-c480a9e403e2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 15, 18, 6, 0, 0, DateTimeKind.Utc), null, null, 338.42m, 4.61m, "KX", 73.41m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1a6ad86c-a90f-4f86-b5db-556dc668a75e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 14, 17, 44, 0, 0, DateTimeKind.Utc), null, null, 165.80m, 1.80m, "U", 92.11m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("157f0f38-a805-479c-9f66-961d7f2c0428"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 14, 19, 21, 0, 0, DateTimeKind.Utc), null, null, 182.13m, 2.60m, "CHF", 70.05m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c1194f9b-85ce-471f-b23c-2b30c8eee9ed"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 7, 16, 20, 0, 0, DateTimeKind.Utc), null, null, 280.63m, 4.59m, "P", 61.14m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bd1a5b74-c50e-49e9-9057-e9aa91e7f2ea"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 5, 19, 24, 0, 0, DateTimeKind.Utc), null, null, 143.81m, 2.40m, "IE", 59.92m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e6eea53c-cbe1-4b6c-b81d-29c2b3abfcea"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 22, 18, 39, 0, 0, DateTimeKind.Utc), null, null, 179.99m, 2.47m, "WU", 72.87m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6908f83e-ed27-447a-bc27-165efc9b0060"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 19, 54, 0, 0, DateTimeKind.Utc), null, null, 120.64m, 1.62m, "I", 74.47m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("70e4650a-6c15-4aa2-8f10-fb34a98956c5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 7, 19, 19, 0, 0, DateTimeKind.Utc), null, null, 0.45m, 0.20m, "BI", 2.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ed7f6df0-0fc6-49f2-8370-a512638ba0a5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 6, 20, 26, 0, 0, DateTimeKind.Utc), null, null, 83.76m, 2.46m, "O", 34.05m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("05962aac-e43f-4720-9911-e3bcfbc5e8d4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 30, 20, 51, 0, 0, DateTimeKind.Utc), null, null, 139.01m, 2.27m, "LOJ", 61.24m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("be4423d1-b883-4a11-920f-2798eaf332aa"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 18, 14, 0, 0, DateTimeKind.Utc), null, null, 30.57m, 3.11m, "OCS", 9.83m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a0539838-e001-4b43-b77f-453059d1df00"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 2, 14, 59, 0, 0, DateTimeKind.Utc), null, null, 10.77m, 1.81m, "WVW", 5.95m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("664d9ede-a5d9-454f-8869-bf78474a6c2c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 26, 15, 0, 0, 0, DateTimeKind.Utc), null, null, 64.27m, 2.66m, "UF", 24.16m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("eee1c420-6de6-40df-b38c-d1825d585b96"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 19, 36, 0, 0, DateTimeKind.Utc), null, null, 125.93m, 3.22m, "VII", 39.11m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9cd2a499-15e9-4cbc-8567-7cd615aca9f5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 15, 16, 12, 0, 0, DateTimeKind.Utc), null, null, 1.80m, 0.53m, "DI", 3.4m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bff34798-9ead-4725-a995-0475ff10ff55"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 24, 16, 51, 0, 0, DateTimeKind.Utc), null, null, 27.17m, 0.72m, "Y", 37.73m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6305a55b-c4cd-42a9-9d50-eb2486ed0a01"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 9, 16, 50, 0, 0, DateTimeKind.Utc), null, null, 198.82m, 2.90m, "IO", 68.56m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4f4cb4b6-0efc-48d8-8cb8-7cd256383c22"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 19, 16, 30, 0, 0, DateTimeKind.Utc), null, null, 85.36m, 2.47m, "O", 34.56m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("39f100d0-2e0b-4a60-8fce-4c3715ff739c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 23, 19, 11, 0, 0, DateTimeKind.Utc), null, null, 24.01m, 3.18m, "F", 7.55m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f7a38ca4-8e01-4aa8-801b-54e5f670be08"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 15, 14, 34, 0, 0, DateTimeKind.Utc), null, null, 40.19m, 0.79m, "L", 50.87m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c441f88d-74e2-43d2-9672-6981876fb7df"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 3, 18, 22, 0, 0, DateTimeKind.Utc), null, null, 5.22m, 2.57m, "FMA", 2.03m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4c18ff72-6dd6-43cb-bd2f-54fbd85241d6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 17, 18, 16, 0, 0, DateTimeKind.Utc), null, null, 159.52m, 2.84m, "IAD", 56.17m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("808691b8-81dd-4e65-b137-d88d057cac98"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 28, 18, 22, 0, 0, DateTimeKind.Utc), null, null, 86.16m, 2.41m, "AO", 35.75m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8c022a9e-a55b-4269-8264-40cec5b8e947"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 4, 15, 11, 0, 0, DateTimeKind.Utc), null, null, 80.05m, 1.86m, "G", 43.04m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a25aed6c-c54c-4141-b35a-f7c107d5463e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 17, 18, 48, 0, 0, DateTimeKind.Utc), null, null, 96.32m, 3.57m, "IW", 26.98m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("21758a91-c784-41f0-b834-a01357c549c4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 14, 38, 0, 0, DateTimeKind.Utc), null, null, 369.33m, 4.29m, "E", 86.09m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("56cd21e0-1df0-41bf-b491-ef921eaa50d8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 20, 10, 0, 0, DateTimeKind.Utc), null, null, 58.36m, 0.67m, "K", 87.1m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("59ef3aac-45aa-4790-926f-4884c8e640f7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 21, 17, 11, 0, 0, DateTimeKind.Utc), null, null, 423.26m, 4.51m, "D", 93.85m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("22ba9e05-feef-485e-a8c4-1d0a4f1629cd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 14, 20, 33, 0, 0, DateTimeKind.Utc), null, null, 217.57m, 4.39m, "MY", 49.56m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e45333f8-7aa1-415a-bbc4-5c297695c963"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 13, 19, 10, 0, 0, DateTimeKind.Utc), null, null, 2.07m, 1.62m, "OW", 1.28m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3754db0b-08e7-4c21-a733-3aec7e4f02dc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 12, 18, 30, 0, 0, DateTimeKind.Utc), null, null, 36.52m, 0.48m, "JG", 76.08m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("63a90725-803c-4e0b-96d7-3623584bb1f6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 25, 15, 5, 0, 0, DateTimeKind.Utc), null, null, 151.75m, 1.65m, "F", 91.97m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e95c66e6-f4d2-44e1-9a82-da80fe455122"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 21, 17, 3, 0, 0, DateTimeKind.Utc), null, null, 70.36m, 1.91m, "V", 36.84m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ef424d54-2484-4129-806d-b0e62740af08"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 27, 20, 7, 0, 0, DateTimeKind.Utc), null, null, 129.09m, 1.31m, "NU", 98.54m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f0813024-9e6d-4636-b996-a7243eafe62d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 18, 15, 7, 0, 0, DateTimeKind.Utc), null, null, 123.06m, 2.71m, "C", 45.41m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d015549a-ae62-466b-84cf-649e4d3c455d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 16, 15, 30, 0, 0, DateTimeKind.Utc), null, null, 205.74m, 2.14m, "LUA", 96.14m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8d6f80c0-c53b-4f78-a469-4763313ce478"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 29, 17, 27, 0, 0, DateTimeKind.Utc), null, null, 0.34m, 0.11m, "K", 3.05m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9998166c-b97d-4a07-b0e9-d2f5424f22ef"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 27, 15, 16, 0, 0, DateTimeKind.Utc), null, null, 106.97m, 2.09m, "OX", 51.18m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dca44d2d-2c00-4fb2-86bc-227955115cc6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 25, 19, 0, 0, 0, DateTimeKind.Utc), null, null, 377.77m, 4.87m, "PDH", 77.57m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9878805c-cc27-48a5-ac0e-437efe807d32"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 22, 18, 50, 0, 0, DateTimeKind.Utc), null, null, 2.59m, 0.09m, "D", 28.79m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("97e36028-559c-4a3d-8289-aec67c48f5d9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 6, 14, 50, 0, 0, DateTimeKind.Utc), null, null, 106.19m, 3.01m, "OTF", 35.28m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("186161a0-a5cf-4d40-b503-dab0a2d39d24"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 20, 19, 41, 0, 0, DateTimeKind.Utc), null, null, 12.84m, 1.26m, "UT", 10.19m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ff95a07f-ed2a-433e-91ac-174cf2f91c59"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 25, 18, 5, 0, 0, DateTimeKind.Utc), null, null, 51.83m, 1.30m, "FUZ", 39.87m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8abe6802-0a61-416a-b773-47a6c2053c94"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 27, 18, 24, 0, 0, DateTimeKind.Utc), null, null, 69.63m, 1.58m, "F", 44.07m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e93d40a4-d971-45ee-947a-59718ad5840d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 11, 18, 32, 0, 0, DateTimeKind.Utc), null, null, 39.66m, 0.95m, "X", 41.75m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d4e2b258-a2ab-401f-9da9-1acc3e172d57"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 5, 15, 19, 0, 0, DateTimeKind.Utc), null, null, 402.04m, 4.37m, "E", 92m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("950e4ee7-c10e-4082-b06c-8f1cbec92b42"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 18, 15, 30, 0, 0, DateTimeKind.Utc), null, null, 306.12m, 3.53m, "MH", 86.72m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2753bfb7-ef6e-4043-8f2f-f99f74ca237b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 7, 20, 43, 0, 0, DateTimeKind.Utc), null, null, 63.11m, 1.47m, "N", 42.93m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9e6dd55b-fc4d-4354-9ce0-094b40457145"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 8, 20, 46, 0, 0, DateTimeKind.Utc), null, null, 102.87m, 2.81m, "NU", 36.61m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b8b7bb7a-56b8-41fe-a25c-e47eb7b59782"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 11, 18, 10, 0, 0, DateTimeKind.Utc), null, null, 151.90m, 3.30m, "JWT", 46.03m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6724d630-89a7-4089-a18e-be6d31e75c99"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 27, 16, 41, 0, 0, DateTimeKind.Utc), null, null, 165.42m, 3.06m, "AYT", 54.06m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a7c95671-a8db-487b-8403-dc3a559446c2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 18, 43, 0, 0, DateTimeKind.Utc), null, null, 11.97m, 1.05m, "Z", 11.4m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("81defa6f-a517-4b36-8629-3a9616c77e89"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 28, 15, 7, 0, 0, DateTimeKind.Utc), null, null, 142.16m, 4.43m, "UPI", 32.09m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e39d89a0-c279-4a4e-9c7b-fe9a28a799bf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 20, 45, 0, 0, DateTimeKind.Utc), null, null, 129.44m, 2.17m, "N", 59.65m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("927e596c-c000-44db-a8f8-379e8e89cab8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 5, 18, 51, 0, 0, DateTimeKind.Utc), null, null, 392.11m, 4.75m, "LPA", 82.55m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f2065222-e3c1-42ae-9032-1ca53dd8cf7f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 8, 20, 27, 0, 0, DateTimeKind.Utc), null, null, 17.69m, 1.36m, "KAQ", 13.01m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("137b6bc7-6c52-4c3e-8bd4-b93611ed8cc4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 1, 18, 21, 0, 0, DateTimeKind.Utc), null, null, 28.48m, 3.56m, "M", 8m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dc2e91d3-6e49-4c41-a1e6-2c16d448d097"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 14, 19, 21, 0, 0, DateTimeKind.Utc), null, null, 27.21m, 4.11m, "KC", 6.62m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cf6bbaef-a2f1-4019-a53c-256ae70b94e8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 10, 18, 33, 0, 0, DateTimeKind.Utc), null, null, 10.85m, 1.32m, "FX", 8.22m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("20311d85-1f58-4d7a-b1c0-aa7be17b0e47"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 14, 18, 42, 0, 0, DateTimeKind.Utc), null, null, 165.33m, 1.67m, "ZP", 99m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6746fe61-7209-40d7-a013-da0bb4a80fb0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 27, 16, 58, 0, 0, DateTimeKind.Utc), null, null, 14.54m, 3.70m, "T", 3.93m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("093113f1-f2b8-4ac8-af7d-00a38e0ad4f9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 30, 19, 14, 0, 0, DateTimeKind.Utc), null, null, 48.17m, 0.57m, "HJ", 84.51m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9e6f9e67-0412-45cc-aefd-acd436e52e88"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 17, 20, 20, 0, 0, DateTimeKind.Utc), null, null, 177.17m, 3.87m, "KFV", 45.78m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c9a24bdf-c28a-428a-b79e-1e50288b526d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 23, 16, 42, 0, 0, DateTimeKind.Utc), null, null, 19.76m, 0.26m, "PCD", 75.99m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("77571b03-1394-4c48-a498-1bd409b97ce6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 25, 19, 12, 0, 0, DateTimeKind.Utc), null, null, 349.95m, 3.94m, "IZ", 88.82m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ede36dfe-7cdf-416f-a95d-47344453a059"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 26, 15, 33, 0, 0, DateTimeKind.Utc), null, null, 223.23m, 4.02m, "U", 55.53m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6ae41308-440e-4fc6-a4c2-b31aad1f1123"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 30, 18, 58, 0, 0, DateTimeKind.Utc), null, null, 80.91m, 1.55m, "BVP", 52.2m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ad28223d-8fc7-4cfb-af37-e4ed99632383"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 16, 15, 58, 0, 0, DateTimeKind.Utc), null, null, 58.12m, 1.19m, "M", 48.84m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("77f41819-f207-4129-8289-88db1aeb257d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 17, 16, 3, 0, 0, DateTimeKind.Utc), null, null, 247.75m, 4.78m, "M", 51.83m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d57d0590-b6ad-4522-86b8-7dd58f13ea9d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 18, 17, 49, 0, 0, DateTimeKind.Utc), null, null, 294.96m, 3.02m, "N", 97.67m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3b1705ec-1c64-4222-b30c-a9f4cd8afe3c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 17, 18, 0, 0, DateTimeKind.Utc), null, null, 35.03m, 2.90m, "MJ", 12.08m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("be48d3c3-e502-4c2c-aa63-cdb05d2592a1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 30, 16, 45, 0, 0, DateTimeKind.Utc), null, null, 207.13m, 3.39m, "ZW", 61.1m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("35bee501-0463-4de2-aedc-755991dd48af"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 5, 20, 34, 0, 0, DateTimeKind.Utc), null, null, 222.38m, 4.18m, "AGV", 53.2m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b6a55e5f-f274-42ac-8489-970cbb14fa08"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 4, 19, 11, 0, 0, DateTimeKind.Utc), null, null, 174.50m, 2.36m, "XS", 73.94m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b03e89ad-7b21-454c-bd03-e732cbb4ebcb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 15, 36, 0, 0, DateTimeKind.Utc), null, null, 38.03m, 1.59m, "U", 23.92m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("87c9b1ca-c364-439a-87b6-11b08e714808"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 17, 17, 6, 0, 0, DateTimeKind.Utc), null, null, 222.74m, 3.43m, "DYI", 64.94m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("85388e60-065a-409c-9103-f8359f74ddad"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 23, 16, 0, 0, 0, DateTimeKind.Utc), null, null, 225.00m, 3.00m, "P", 75m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("94fdcf3f-a080-499a-8df4-cb34323828a7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 24, 20, 43, 0, 0, DateTimeKind.Utc), null, null, 1.64m, 0.39m, "KK", 4.2m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("56bd4226-73fd-4cea-a6c6-cc2802aeea7e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 3, 19, 8, 0, 0, DateTimeKind.Utc), null, null, 376.75m, 4.33m, "DK", 87.01m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2ec4345e-0d04-440d-8a37-576529dfa11c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 24, 20, 4, 0, 0, DateTimeKind.Utc), null, null, 5.28m, 0.10m, "U", 52.76m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d3f0410d-835e-4ec5-86c1-1a9ed18a64e3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 30, 20, 28, 0, 0, DateTimeKind.Utc), null, null, 84.01m, 4.98m, "MS", 16.87m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e8c574b4-a9a7-4c59-8f7f-d0a5cceb624a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 24, 19, 15, 0, 0, DateTimeKind.Utc), null, null, 130.88m, 3.48m, "FVY", 37.61m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1d4ecb35-81c5-48fb-b775-be9fe1a1fa44"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 10, 19, 44, 0, 0, DateTimeKind.Utc), null, null, 73.40m, 1.97m, "GH", 37.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3dd09957-ae60-4867-ba25-0ed26003f292"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 26, 20, 16, 0, 0, DateTimeKind.Utc), null, null, 63.90m, 1.59m, "RJ", 40.19m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1fbadbbb-03cd-4b21-b70a-1b43ef68ae39"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 1, 18, 17, 0, 0, DateTimeKind.Utc), null, null, 9.50m, 0.14m, "OID", 67.86m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6dfc0228-6461-4952-b6ea-274f75c81fb2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 26, 17, 57, 0, 0, DateTimeKind.Utc), null, null, 216.33m, 3.01m, "JF", 71.87m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b711ceea-0db0-4f6e-8c99-baa2e8409928"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 27, 18, 40, 0, 0, DateTimeKind.Utc), null, null, 3.12m, 0.27m, "DIY", 11.57m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4d045222-be13-4842-a553-5347f7f8bf54"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 16, 15, 52, 0, 0, DateTimeKind.Utc), null, null, 43.61m, 3.64m, "PF", 11.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("52ccee7e-5a0a-4a23-b5db-114817b59f21"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 18, 16, 17, 0, 0, DateTimeKind.Utc), null, null, 189.70m, 3.69m, "PO", 51.41m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e3c603f9-4be3-4537-8ac7-57ebec7364b3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 16, 17, 6, 0, 0, DateTimeKind.Utc), null, null, 118.34m, 3.99m, "L", 29.66m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9430831f-3ff7-4df2-aa11-6366096c7272"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 15, 17, 29, 0, 0, DateTimeKind.Utc), null, null, 244.94m, 3.09m, "QS", 79.27m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a6bfe8a0-2d34-4991-964b-96a616445508"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 6, 17, 20, 0, 0, DateTimeKind.Utc), null, null, 67.28m, 2.47m, "WI", 27.24m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d812c5d8-ea48-47fe-8cbe-d00412a994ee"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 24, 16, 8, 0, 0, DateTimeKind.Utc), null, null, 74.39m, 2.05m, "L", 36.29m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6c1ccc89-1214-44d0-a363-6db4411a7f6a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 13, 15, 46, 0, 0, DateTimeKind.Utc), null, null, 233.68m, 4.61m, "SX", 50.69m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b35d2043-5747-4972-94ed-9f74a3d383b0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 30, 15, 23, 0, 0, DateTimeKind.Utc), null, null, 94.80m, 1.25m, "EQE", 75.84m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fa54ff88-f922-4303-9811-bb075f48ce42"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 4, 20, 54, 0, 0, DateTimeKind.Utc), null, null, 289.84m, 3.30m, "H", 87.83m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("158f9ca8-50df-424b-ba2a-b189f1e6783e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 20, 20, 15, 0, 0, DateTimeKind.Utc), null, null, 56.12m, 1.48m, "GAM", 37.92m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("18ef0add-af5d-4b65-ac33-f1656762b1c6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 19, 16, 23, 0, 0, DateTimeKind.Utc), null, null, 50.50m, 1.62m, "V", 31.17m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0412e17f-0272-4bd9-a316-9202a0fb115f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 13, 17, 15, 0, 0, DateTimeKind.Utc), null, null, 62.40m, 2.14m, "JOM", 29.16m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("28c65622-ccbf-4081-b664-d233d4723090"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 9, 18, 8, 0, 0, DateTimeKind.Utc), null, null, 89.60m, 1.48m, "BUT", 60.54m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ae3d8b20-764b-4b0a-ad52-558cd6daaf18"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 10, 17, 1, 0, 0, DateTimeKind.Utc), null, null, 425.51m, 4.48m, "XD", 94.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("178021b6-f691-42a0-a790-5090668b41b0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 15, 20, 11, 0, 0, DateTimeKind.Utc), null, null, 29.27m, 1.46m, "H", 20.05m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("507d1cf1-4fd0-4d34-8488-5c5babcf0f0d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 12, 16, 31, 0, 0, DateTimeKind.Utc), null, null, 254.89m, 4.55m, "EQM", 56.02m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("153dccf2-ef7c-43e2-88ca-0dd8be7d197c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 16, 18, 45, 0, 0, DateTimeKind.Utc), null, null, 8.32m, 0.25m, "ZL", 33.29m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e4ba17fb-2ad9-4d8c-82ba-57d956ac5c08"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 14, 17, 6, 0, 0, DateTimeKind.Utc), null, null, 16.36m, 0.26m, "CYX", 62.91m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4040a6a1-af5b-4c6a-8af3-87bf98a0d702"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 19, 19, 6, 0, 0, DateTimeKind.Utc), null, null, 140.61m, 4.72m, "UF", 29.79m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1e175311-6208-48a5-9304-69fb4d2242ac"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 3, 20, 32, 0, 0, DateTimeKind.Utc), null, null, 13.72m, 4.26m, "I", 3.22m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("766ce0a8-255f-44a4-b219-a441803b57a9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 18, 24, 0, 0, DateTimeKind.Utc), null, null, 27.59m, 1.53m, "WM", 18.03m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("521855dd-6b70-428a-bc9c-e9041b56b97d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 26, 15, 59, 0, 0, DateTimeKind.Utc), null, null, 20.95m, 0.51m, "UNF", 41.07m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6aa3aa52-a7be-441f-b46a-acbc654db71a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 12, 18, 18, 0, 0, DateTimeKind.Utc), null, null, 32.86m, 2.89m, "K", 11.37m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("faa5cd5d-9c1d-40db-941f-31a613f2662a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 7, 14, 49, 0, 0, DateTimeKind.Utc), null, null, 103.89m, 1.93m, "TE", 53.83m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a6fd08a5-4090-4d59-bda1-62639ed89c2c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 20, 16, 42, 0, 0, DateTimeKind.Utc), null, null, 8.64m, 1.22m, "NA", 7.08m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6b7d5fe2-7ce1-4eb7-a66c-2a4cfb766ad8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 16, 19, 42, 0, 0, DateTimeKind.Utc), null, null, 300.54m, 4.02m, "LZ", 74.76m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("664edac7-493e-47cd-8a81-5cd28a9223ab"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 29, 14, 53, 0, 0, DateTimeKind.Utc), null, null, 203.05m, 4.04m, "KYL", 50.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f543d1e6-c1c5-4b77-a575-b663400d9510"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 19, 19, 48, 0, 0, DateTimeKind.Utc), null, null, 184.64m, 2.51m, "ONP", 73.56m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3cbfe322-8209-468b-a89c-6bb83eb42149"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 15, 20, 33, 0, 0, DateTimeKind.Utc), null, null, 46.51m, 1.98m, "OJ", 23.49m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fde83c56-ecbf-4904-a01e-249fe658c5b0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 11, 17, 6, 0, 0, DateTimeKind.Utc), null, null, 133.99m, 4.30m, "DY", 31.16m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("82bce2c3-2c6c-4af2-8aec-aa38211cfff8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 28, 15, 13, 0, 0, DateTimeKind.Utc), null, null, 303.77m, 3.60m, "DLJ", 84.38m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3b697a74-e5b9-4989-861f-50ec05436059"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 5, 14, 36, 0, 0, DateTimeKind.Utc), null, null, 12.91m, 0.30m, "S", 43.02m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1a85870d-3ea9-4442-8ae1-c7da71aac131"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 6, 18, 14, 0, 0, DateTimeKind.Utc), null, null, 315.58m, 4.87m, "X", 64.8m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bf0389b1-9d96-4ccb-8340-cc333a103b36"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 1, 20, 8, 0, 0, DateTimeKind.Utc), null, null, 327.45m, 3.38m, "M", 96.88m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("51ff251e-b7c4-4e82-aa5d-c31d82bf8174"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 3, 18, 26, 0, 0, DateTimeKind.Utc), null, null, 29.16m, 0.47m, "QH", 62.04m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b15d5f61-00ac-4643-9ee5-522fd4e5bf63"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 4, 16, 24, 0, 0, DateTimeKind.Utc), null, null, 7.59m, 1.83m, "U", 4.15m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f85e9968-ed53-4cac-99b2-21c8733d08bb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 2, 15, 14, 0, 0, DateTimeKind.Utc), null, null, 173.28m, 1.89m, "Z", 91.68m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("46a445e5-86d9-41ab-b5d2-9eb02960f12c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 3, 17, 13, 0, 0, DateTimeKind.Utc), null, null, 156.60m, 4.53m, "PDM", 34.57m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d3b335c6-0dbf-4028-a7e2-8e5a0240cf32"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 20, 20, 10, 0, 0, DateTimeKind.Utc), null, null, 22.23m, 0.44m, "B", 50.53m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ca354d9d-d8aa-4479-93c7-8fff49fbd7b0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 7, 15, 31, 0, 0, DateTimeKind.Utc), null, null, 163.18m, 1.99m, "DQ", 82m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("58966029-80b8-494e-9dcc-c1245cc1bd50"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 10, 20, 37, 0, 0, DateTimeKind.Utc), null, null, 31.12m, 0.87m, "M", 35.77m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1da06a55-1223-4167-b520-b61eca95d506"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 27, 15, 41, 0, 0, DateTimeKind.Utc), null, null, 9.56m, 0.69m, "Z", 13.86m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cd56387a-0153-4b7e-826c-19e70b4ae81d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 13, 20, 5, 0, 0, DateTimeKind.Utc), null, null, 223.32m, 4.22m, "WC", 52.92m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("43e5340c-0eb5-4fe7-9358-e71c5e47f4a6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 15, 15, 23, 0, 0, DateTimeKind.Utc), null, null, 259.98m, 2.85m, "WB", 91.22m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fac2077a-3281-4d42-991d-c385f82cbfe6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 17, 19, 49, 0, 0, DateTimeKind.Utc), null, null, 2.94m, 0.39m, "N", 7.54m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("19ea416b-8693-47c7-86bd-9a696d40b7d3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 25, 19, 32, 0, 0, DateTimeKind.Utc), null, null, 82.77m, 1.63m, "QZ", 50.78m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a75d32ea-17bd-4b3d-b055-3ac080c5894a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 16, 17, 28, 0, 0, DateTimeKind.Utc), null, null, 334.68m, 3.78m, "G", 88.54m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b7bfd59c-fa92-4c54-a12b-6f8a8fe04fd0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 29, 20, 48, 0, 0, DateTimeKind.Utc), null, null, 251.55m, 3.92m, "H", 64.17m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("842c481d-285e-47ac-be4d-dd4d0f53e877"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 22, 15, 4, 0, 0, DateTimeKind.Utc), null, null, 76.60m, 1.17m, "IYV", 65.47m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5703fc8b-9be0-4cd1-8f5e-e26773d1d3b9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 17, 18, 43, 0, 0, DateTimeKind.Utc), null, null, 112.75m, 1.49m, "WX", 75.67m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("978a7d59-4a96-4dda-84bd-171e1013a5d1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 7, 18, 26, 0, 0, DateTimeKind.Utc), null, null, 52.21m, 0.70m, "H", 74.59m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ed846ef9-3c84-4d90-b416-449c5b8aec89"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 20, 2, 0, 0, DateTimeKind.Utc), null, null, 137.82m, 3.89m, "OIN", 35.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6c516282-aff1-4e85-95db-bddb6e8302b1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 17, 14, 58, 0, 0, DateTimeKind.Utc), null, null, 195.80m, 4.25m, "TT", 46.07m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("12a79dc8-af63-48b8-936b-1fa5ef5c38a4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 22, 15, 59, 0, 0, DateTimeKind.Utc), null, null, 9.12m, 4.24m, "Q", 2.15m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("22941a85-284d-4ea7-b85b-d71050c0c1ca"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 27, 15, 54, 0, 0, DateTimeKind.Utc), null, null, 119.84m, 1.75m, "GUL", 68.48m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("eb28e716-3cc6-4af4-ae13-cb8673b67b0b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 25, 16, 54, 0, 0, DateTimeKind.Utc), null, null, 120.51m, 3.56m, "Z", 33.85m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9088a6fd-b74f-44b5-9ff9-2f845c46b2c3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 19, 16, 3, 0, 0, DateTimeKind.Utc), null, null, 27.80m, 1.73m, "N", 16.07m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("81f62985-4201-4e96-94dd-eac3601a2408"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 2, 18, 51, 0, 0, DateTimeKind.Utc), null, null, 17.23m, 0.55m, "HV", 31.32m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("71e94472-9e53-4d66-8b12-508884256ebc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 16, 20, 54, 0, 0, DateTimeKind.Utc), null, null, 7.29m, 0.85m, "IU", 8.58m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5df54750-d548-4f06-b5c6-9036552daed7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 19, 20, 48, 0, 0, DateTimeKind.Utc), null, null, 31.17m, 1.60m, "OG", 19.48m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("89ec3b93-7267-4da1-a953-e9462c3eb5e5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 29, 17, 22, 0, 0, DateTimeKind.Utc), null, null, 35.73m, 1.36m, "Z", 26.27m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("45f405c1-f53b-48af-bac7-e95914b24832"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 27, 18, 52, 0, 0, DateTimeKind.Utc), null, null, 467.70m, 4.88m, "C", 95.84m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("772ecc19-3a6e-48e0-a399-16b0a1977c0f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 10, 20, 21, 0, 0, DateTimeKind.Utc), null, null, 68.38m, 0.80m, "GTL", 85.48m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("99db40b5-721a-4b2e-a1c6-4d18e482999d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 15, 18, 51, 0, 0, DateTimeKind.Utc), null, null, 45.15m, 2.02m, "KQM", 22.35m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("36a8fc32-00a3-4cd3-b7e0-ba1c3bb17fa5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 2, 16, 31, 0, 0, DateTimeKind.Utc), null, null, 431.05m, 4.34m, "MSX", 99.32m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8f0c1335-936f-4c1b-a2ea-6c75007f25ad"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 10, 15, 10, 0, 0, DateTimeKind.Utc), null, null, 13.63m, 0.23m, "S", 59.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1b6cabb7-e2cc-4f0d-821d-63b12935912d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 26, 18, 12, 0, 0, DateTimeKind.Utc), null, null, 14.57m, 1.30m, "ROV", 11.21m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5937c2d4-0fdf-4488-9df3-8a8ed5e60755"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 18, 16, 40, 0, 0, DateTimeKind.Utc), null, null, 374.67m, 4.33m, "WE", 86.53m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("882e9179-1937-467e-beef-e9559fd14496"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 7, 18, 49, 0, 0, DateTimeKind.Utc), null, null, 12.34m, 0.15m, "N", 82.3m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e8f6fc89-a251-4e43-9d2f-d7a2373946df"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 26, 19, 21, 0, 0, DateTimeKind.Utc), null, null, 11.87m, 1.03m, "HDE", 11.52m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8dbd65e6-0036-4756-ab8a-712004fd1da0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 16, 58, 0, 0, DateTimeKind.Utc), null, null, 225.33m, 4.78m, "LMO", 47.14m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("711218b0-feac-463c-970c-4a23a5bbe13d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 16, 18, 23, 0, 0, DateTimeKind.Utc), null, null, 264.08m, 4.62m, "FGL", 57.16m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0aefb860-002f-4834-932a-4c50bf84faa2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 1, 19, 21, 0, 0, DateTimeKind.Utc), null, null, 124.12m, 4.73m, "XZB", 26.24m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e1b40e6f-f4f4-44a7-8939-dfdc76fcd25d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 10, 15, 25, 0, 0, DateTimeKind.Utc), null, null, 101.10m, 3.38m, "LB", 29.91m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("edbd9482-0bd3-43ea-b9ce-ed98ac447f16"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 22, 14, 34, 0, 0, DateTimeKind.Utc), null, null, 50.36m, 0.95m, "ZFM", 53.01m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a5f6bd83-6942-4343-8234-469abcbea1a5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 30, 18, 30, 0, 0, DateTimeKind.Utc), null, null, 156.76m, 2.10m, "HP", 74.65m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7866f1c9-5f61-4f42-8b63-4d77502d7f44"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 22, 19, 52, 0, 0, DateTimeKind.Utc), null, null, 5.14m, 0.89m, "KT", 5.78m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("82302665-99d9-4b69-bffe-c8e43c7ca8ec"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 19, 19, 55, 0, 0, DateTimeKind.Utc), null, null, 40.19m, 1.40m, "CIV", 28.71m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("03c8ee68-b721-43b7-9e66-bdaa661570e8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 23, 15, 7, 0, 0, DateTimeKind.Utc), null, null, 335.50m, 4.11m, "NTD", 81.63m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("342c03a9-6d98-4173-bf8a-b9400b03dd60"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 7, 15, 0, 0, 0, DateTimeKind.Utc), null, null, 42.01m, 0.92m, "QLU", 45.66m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c83a5964-54c9-418b-b298-db5b91e4dcea"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 26, 15, 41, 0, 0, DateTimeKind.Utc), null, null, 66.30m, 0.74m, "M", 89.59m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("55786628-f05c-4d47-89fd-4c4175941118"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 2, 19, 1, 0, 0, DateTimeKind.Utc), null, null, 4.88m, 0.64m, "MWY", 7.62m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e676b239-af7f-4fe7-8fd9-e63c3d3e2b22"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 16, 19, 16, 0, 0, DateTimeKind.Utc), null, null, 140.68m, 1.53m, "Y", 91.95m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4a97cca1-c511-475a-bc6a-904cf4efb787"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 23, 15, 0, 0, 0, DateTimeKind.Utc), null, null, 40.16m, 0.62m, "KAL", 64.78m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6a1d7278-618a-4360-b5f1-ce61d2654eeb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 23, 15, 4, 0, 0, DateTimeKind.Utc), null, null, 103.67m, 2.65m, "PXQ", 39.12m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ab2c44d3-de8a-4f3d-bcc8-3d8d6405d1e3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 16, 20, 15, 0, 0, DateTimeKind.Utc), null, null, 79.25m, 1.91m, "F", 41.49m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("733a9093-f7b6-453b-95a3-6890ea8453dd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 10, 19, 43, 0, 0, DateTimeKind.Utc), null, null, 18.06m, 0.99m, "CU", 18.24m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a24de8a4-dedf-4866-904e-537fd822ce8c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 8, 19, 48, 0, 0, DateTimeKind.Utc), null, null, 31.15m, 4.12m, "JB", 7.56m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2c4b88cf-a256-43d5-adf5-0102ef2d5919"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 21, 15, 23, 0, 0, DateTimeKind.Utc), null, null, 1.68m, 0.61m, "N", 2.76m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e811ff8c-11a5-4eeb-a578-ee84082ca45b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 5, 20, 47, 0, 0, DateTimeKind.Utc), null, null, 60.33m, 1.61m, "F", 37.47m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2f6edf5c-294e-4825-b49d-5a9ab833127e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 18, 16, 38, 0, 0, DateTimeKind.Utc), null, null, 18.21m, 3.95m, "B", 4.61m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ac30c468-89ed-4c20-8b09-6a9f284a0e15"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 17, 19, 14, 0, 0, DateTimeKind.Utc), null, null, 11.11m, 2.40m, "XV", 4.63m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4327070e-1dfc-44fe-bf45-c8956bf66bf3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 4, 16, 14, 0, 0, DateTimeKind.Utc), null, null, 9.72m, 0.58m, "IH", 16.75m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c3b29f88-daee-46ea-9dd5-4dbd9a4bb68f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 26, 16, 37, 0, 0, DateTimeKind.Utc), null, null, 73.99m, 4.90m, "K", 15.1m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dd4f78e1-557e-469d-9da1-9889db368018"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 5, 17, 25, 0, 0, DateTimeKind.Utc), null, null, 1.35m, 0.06m, "I", 22.56m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bb8e41d5-f5a2-4823-94f9-5857e3302c25"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 17, 19, 1, 0, 0, DateTimeKind.Utc), null, null, 46.48m, 1.07m, "DL", 43.44m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5c05dfcf-437a-4c7e-9611-c3dd7d38ba2f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 12, 19, 30, 0, 0, DateTimeKind.Utc), null, null, 1.41m, 0.26m, "CFY", 5.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("05234294-6897-482f-8a91-115368e6a9fc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 13, 15, 36, 0, 0, DateTimeKind.Utc), null, null, 254.61m, 2.95m, "HWT", 86.31m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8ecf632b-c9ad-4bbb-b8da-6848053fa92b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 17, 18, 54, 0, 0, DateTimeKind.Utc), null, null, 269.86m, 4.09m, "CS", 65.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cebbc583-ab36-4920-a41a-9aeb2462159e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 15, 19, 40, 0, 0, DateTimeKind.Utc), null, null, 124.54m, 2.13m, "DUB", 58.47m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9e5af5f2-318a-40e1-ad91-2ab6362b0170"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 17, 14, 44, 0, 0, DateTimeKind.Utc), null, null, 149.12m, 2.78m, "BXK", 53.64m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("00ed65cd-f304-4d3e-8a94-81e08d2dfe43"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 14, 19, 13, 0, 0, DateTimeKind.Utc), null, null, 250.89m, 3.77m, "YFH", 66.55m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("99328fd8-61f1-47be-868e-2f370653c415"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 14, 14, 56, 0, 0, DateTimeKind.Utc), null, null, 76.61m, 2.53m, "L", 30.28m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ce0651a8-9310-447d-8325-f7f76633e2ee"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 2, 20, 26, 0, 0, DateTimeKind.Utc), null, null, 159.91m, 2.29m, "C", 69.83m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b0570d30-409a-4bde-ab17-bc72cc8e2e65"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 14, 15, 4, 0, 0, DateTimeKind.Utc), null, null, 188.38m, 4.64m, "WNV", 40.6m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8bfbec54-ef57-4690-9869-ba8f982a888f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 15, 28, 0, 0, DateTimeKind.Utc), null, null, 138.20m, 2.51m, "WDE", 55.06m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9032c3b7-9adc-4c55-a995-e5faa961d50b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 16, 17, 31, 0, 0, DateTimeKind.Utc), null, null, 45.54m, 4.43m, "GR", 10.28m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("84478298-63bb-4a9b-a096-e83454d5dbc8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 16, 19, 45, 0, 0, DateTimeKind.Utc), null, null, 37.79m, 0.72m, "KY", 52.48m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bf9841bb-1945-4e79-a5b3-15b34c84b9c5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 6, 20, 25, 0, 0, DateTimeKind.Utc), null, null, 165.43m, 3.19m, "F", 51.86m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9ba9649b-577a-4416-ade8-d7bb78773901"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 30, 18, 28, 0, 0, DateTimeKind.Utc), null, null, 15.45m, 0.64m, "HU", 24.14m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fdfcf36e-5069-4ab7-9d66-9ccd09e10025"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 21, 17, 18, 0, 0, DateTimeKind.Utc), null, null, 99.19m, 1.27m, "FCD", 78.1m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dbe37696-6059-42c3-9a3a-c29b93c125f6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 8, 17, 53, 0, 0, DateTimeKind.Utc), null, null, 40.19m, 0.92m, "NO", 43.69m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3fb73dd4-c192-4233-9e19-4898a631436e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 14, 17, 47, 0, 0, DateTimeKind.Utc), null, null, 266.04m, 2.94m, "JF", 90.49m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("456758bf-c26c-4ab7-bf5c-64d7ab615451"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 11, 20, 54, 0, 0, DateTimeKind.Utc), null, null, 129.06m, 1.61m, "WVV", 80.16m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d7059dbd-8ced-47d3-9744-ebcf7def9671"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 22, 15, 27, 0, 0, DateTimeKind.Utc), null, null, 169.94m, 4.05m, "YU", 41.96m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c843c0c8-8b76-48fc-b2b7-d2584b0f8387"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 27, 17, 43, 0, 0, DateTimeKind.Utc), null, null, 30.90m, 1.73m, "C", 17.86m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ec365684-966a-492e-a14f-2023983852a5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 5, 16, 2, 0, 0, DateTimeKind.Utc), null, null, 386.58m, 4.54m, "HN", 85.15m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ad445a27-bc1e-47cc-9250-23146d109568"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 26, 17, 52, 0, 0, DateTimeKind.Utc), null, null, 455.18m, 4.67m, "PF", 97.47m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1b1a8c02-cffe-4d91-9e07-e9b563c4c554"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 17, 18, 13, 0, 0, DateTimeKind.Utc), null, null, 320.93m, 4.08m, "Z", 78.66m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("512fe8b0-8dd6-4673-a75f-7fc6295d362e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 16, 17, 23, 0, 0, DateTimeKind.Utc), null, null, 33.91m, 0.64m, "X", 52.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f8fe3f5d-f3f4-4337-9267-5996bde14d03"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 26, 18, 21, 0, 0, DateTimeKind.Utc), null, null, 44.18m, 2.17m, "J", 20.36m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8afe0c16-2eb5-4ea2-a9b5-c49703e5ef6e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 9, 17, 47, 0, 0, DateTimeKind.Utc), null, null, 238.56m, 4.30m, "DT", 55.48m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("12b13fff-8649-4968-a03e-b531efbbc00b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 28, 15, 46, 0, 0, DateTimeKind.Utc), null, null, 88.59m, 3.73m, "MH", 23.75m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a85e6edb-1238-4398-92a5-50e782a6cd8f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 5, 19, 29, 0, 0, DateTimeKind.Utc), null, null, 74.65m, 0.87m, "BOZ", 85.81m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6b025b01-e90a-41be-950c-747533ceb507"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 14, 15, 39, 0, 0, DateTimeKind.Utc), null, null, 239.10m, 3.00m, "FPK", 79.7m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2f0988fd-1532-43e3-90b1-877d4bb1dd5a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 9, 17, 33, 0, 0, DateTimeKind.Utc), null, null, 206.84m, 4.48m, "R", 46.17m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("22dfa694-ae7f-49aa-8c31-a14a74e625bf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 22, 17, 46, 0, 0, DateTimeKind.Utc), null, null, 3.13m, 1.85m, "Q", 1.69m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0deca297-a5f9-455d-b8a4-f6de4fd81c70"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 16, 19, 39, 0, 0, DateTimeKind.Utc), null, null, 67.37m, 1.52m, "J", 44.32m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("60129512-0b3f-4f4e-8570-f068367a4c5c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 11, 15, 49, 0, 0, DateTimeKind.Utc), null, null, 228.01m, 3.39m, "ORO", 67.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("eecf3197-85ac-471f-8ac3-ee63b2f695a0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 27, 17, 47, 0, 0, DateTimeKind.Utc), null, null, 16.44m, 0.88m, "QUS", 18.68m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7657b927-d841-4cd1-8ea4-dc3615f57bdf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 28, 19, 3, 0, 0, DateTimeKind.Utc), null, null, 309.26m, 3.37m, "NXE", 91.77m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("34209a14-8517-4487-8c88-ee7180a0202e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 22, 15, 38, 0, 0, DateTimeKind.Utc), null, null, 289.61m, 3.42m, "EO", 84.68m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6e3df388-7bec-4617-b5a9-3ae89aa67474"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 13, 15, 31, 0, 0, DateTimeKind.Utc), null, null, 200.03m, 3.29m, "LZY", 60.8m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("96788759-ca62-4549-96a5-2e336e3ef3c0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 17, 14, 59, 0, 0, DateTimeKind.Utc), null, null, 185.67m, 2.23m, "EGF", 83.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fc92502d-36f5-428d-b9a0-8cf81d009bef"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 26, 18, 24, 0, 0, DateTimeKind.Utc), null, null, 65.66m, 2.68m, "TXE", 24.5m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5e41607f-1eb2-452a-86c6-29426746e0ac"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 5, 14, 55, 0, 0, DateTimeKind.Utc), null, null, 16.89m, 4.16m, "K", 4.06m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("15ca46e6-df6b-46d8-9dc2-5bace62d05ae"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 20, 29, 0, 0, DateTimeKind.Utc), null, null, 54.70m, 3.21m, "Y", 17.04m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b898e909-4b51-425b-b2c0-f283fb52e635"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 5, 16, 0, 0, 0, DateTimeKind.Utc), null, null, 149.63m, 3.56m, "P", 42.03m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("529f9852-ede7-402f-bd3d-54141b88f10b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 25, 20, 36, 0, 0, DateTimeKind.Utc), null, null, 146.32m, 2.89m, "UKQ", 50.63m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("90292a95-8c27-4ae2-85b1-1a3688255a41"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 8, 15, 50, 0, 0, DateTimeKind.Utc), null, null, 17.45m, 0.25m, "A", 69.81m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9ddd1a71-c990-4a0c-8ce4-35272a11a958"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 4, 20, 35, 0, 0, DateTimeKind.Utc), null, null, 107.53m, 2.64m, "KWR", 40.73m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d81ba582-a62e-4743-9a2a-2c9e7c60db74"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 26, 20, 0, 0, 0, DateTimeKind.Utc), null, null, 309.97m, 4.48m, "GX", 69.19m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0b8872c8-e84a-4cc4-beca-6d9fc786e5a8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 22, 20, 27, 0, 0, DateTimeKind.Utc), null, null, 4.72m, 1.01m, "CU", 4.67m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("aa60a53a-70d3-4506-8d53-57a258800bf3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 11, 18, 17, 0, 0, DateTimeKind.Utc), null, null, 208.79m, 2.70m, "IM", 77.33m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a2f7a88e-6793-40f8-95c3-3f38a05a856b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 12, 19, 4, 0, 0, DateTimeKind.Utc), null, null, 20.02m, 4.44m, "X", 4.51m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4e0cc450-7f56-417f-95c0-8894b9a51d73"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 14, 16, 13, 0, 0, DateTimeKind.Utc), null, null, 65.88m, 2.60m, "X", 25.34m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a547b141-c96e-4435-8e76-6c45082ef29c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 9, 14, 45, 0, 0, DateTimeKind.Utc), null, null, 84.12m, 1.01m, "YZ", 83.29m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2d7ed7b8-6a90-48c6-8ee0-1da4189ce47c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 29, 16, 16, 0, 0, DateTimeKind.Utc), null, null, 126.54m, 2.00m, "A", 63.27m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("485258c0-eec6-49a4-9e8a-000d83f6fd21"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 28, 18, 26, 0, 0, DateTimeKind.Utc), null, null, 8.40m, 0.31m, "EI", 27.1m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fe7970eb-a06d-4cf9-ac5e-0c8122fd3600"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 14, 20, 44, 0, 0, DateTimeKind.Utc), null, null, 433.33m, 4.97m, "EVO", 87.19m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9633b0df-48c2-4aea-a502-3e452d4b4a2b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 16, 17, 10, 0, 0, DateTimeKind.Utc), null, null, 101.59m, 2.57m, "PO", 39.53m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7d5dcb9a-f7a8-43d9-926c-6cbd19d005c1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 2, 18, 31, 0, 0, DateTimeKind.Utc), null, null, 34.13m, 1.01m, "ARF", 33.79m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("da3e2b93-aaf3-452e-843d-75b135babea6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 16, 17, 43, 0, 0, DateTimeKind.Utc), null, null, 318.19m, 4.29m, "N", 74.17m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bf7cb346-720b-4190-aa0b-6e0d76fa9279"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 7, 14, 48, 0, 0, DateTimeKind.Utc), null, null, 47.20m, 4.50m, "J", 10.49m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("04df2cf7-0b69-485b-bd57-19159b5879ff"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 15, 15, 50, 0, 0, DateTimeKind.Utc), null, null, 43.63m, 0.44m, "ZHD", 99.16m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c088fbb6-065a-4521-b0ef-faad5bd7d00b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 25, 17, 39, 0, 0, DateTimeKind.Utc), null, null, 332.30m, 4.51m, "JA", 73.68m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f981e933-1d7d-4e04-bf8a-af76cdedffe8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 3, 19, 2, 0, 0, DateTimeKind.Utc), null, null, 160.66m, 2.34m, "WKK", 68.66m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8d3a350b-5f75-4640-a908-f8b2a0a2235b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 11, 16, 38, 0, 0, DateTimeKind.Utc), null, null, 212.84m, 2.42m, "NX", 87.95m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8c20a750-48dc-43f5-b9e6-6269bb6beac6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 20, 14, 43, 0, 0, DateTimeKind.Utc), null, null, 222.08m, 2.29m, "R", 96.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b53df8cc-1478-4e09-881e-472161450355"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 20, 8, 0, 0, DateTimeKind.Utc), null, null, 40.16m, 0.63m, "LEF", 63.75m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e9b9c97c-c9b2-4293-aad2-366719355c7d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 4, 17, 18, 0, 0, DateTimeKind.Utc), null, null, 202.16m, 3.75m, "ZL", 53.91m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c527c232-bc29-4f21-9e3d-411d5644ccc4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 30, 20, 46, 0, 0, DateTimeKind.Utc), null, null, 4.37m, 0.12m, "GD", 36.45m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0f1f6ae5-f9a9-48dc-88c5-86ce2e7c284e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 30, 18, 8, 0, 0, DateTimeKind.Utc), null, null, 218.39m, 3.97m, "BW", 55.01m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b406dec9-4ed6-4227-97ce-21a367cb54db"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 16, 19, 47, 0, 0, DateTimeKind.Utc), null, null, 115.79m, 1.39m, "AE", 83.3m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b90ffd90-e49f-4304-93b1-ef1cbfdf84d9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 4, 18, 7, 0, 0, DateTimeKind.Utc), null, null, 19.61m, 3.21m, "Y", 6.11m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("597e4ef5-04f3-4f6c-8a9d-fa49f18fd588"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 11, 15, 56, 0, 0, DateTimeKind.Utc), null, null, 181.69m, 3.59m, "X", 50.61m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f15bee8c-b93b-4e73-a5ab-56a9b384d661"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 23, 14, 55, 0, 0, DateTimeKind.Utc), null, null, 8.48m, 0.38m, "L", 22.31m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ccce9b73-1fc5-4bea-a894-f22c9e74146c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 12, 15, 31, 0, 0, DateTimeKind.Utc), null, null, 293.17m, 4.09m, "B", 71.68m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ac899f81-4690-4a4b-8027-25d6fadef418"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 23, 17, 42, 0, 0, DateTimeKind.Utc), null, null, 25.41m, 0.47m, "DC", 54.06m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1f4a58a7-39ff-4893-bb83-7f942c3ee556"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 29, 16, 3, 0, 0, DateTimeKind.Utc), null, null, 16.86m, 0.75m, "M", 22.48m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d63fa069-b27b-4e6d-9e02-7e91000319c1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 8, 14, 33, 0, 0, DateTimeKind.Utc), null, null, 38.40m, 4.16m, "QRP", 9.23m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1ea28201-ad67-48c1-a780-8dadc7b4c426"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 13, 16, 11, 0, 0, DateTimeKind.Utc), null, null, 78.16m, 3.07m, "T", 25.46m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1dd397e7-05ff-4b38-8ee3-27fb9fb85d77"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 2, 15, 18, 0, 0, DateTimeKind.Utc), null, null, 41.32m, 0.51m, "EC", 81.01m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f34d21d0-609b-4984-b091-ce2534fbe1d2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 27, 19, 57, 0, 0, DateTimeKind.Utc), null, null, 40.87m, 4.73m, "IO", 8.64m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("52397bee-94a8-46b8-9589-55abc54797f9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 12, 18, 3, 0, 0, DateTimeKind.Utc), null, null, 247.02m, 2.71m, "O", 91.15m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("959edda0-5184-494d-878b-65f28da61b58"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 25, 15, 42, 0, 0, DateTimeKind.Utc), null, null, 366.69m, 4.25m, "TZ", 86.28m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7d018ddf-927e-42a4-a6d5-21d05668ca5e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 9, 18, 7, 0, 0, DateTimeKind.Utc), null, null, 227.56m, 4.30m, "K", 52.92m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7b06c67b-6f0b-443c-8d4b-c99ddce59166"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 24, 16, 7, 0, 0, DateTimeKind.Utc), null, null, 184.13m, 4.10m, "T", 44.91m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c16c2184-d830-46d8-8e05-4ef8ec46eb50"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 23, 16, 25, 0, 0, DateTimeKind.Utc), null, null, 9.07m, 0.41m, "B", 22.13m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f49f4742-9768-45f4-bef4-05be56284ac0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 22, 20, 31, 0, 0, DateTimeKind.Utc), null, null, 193.31m, 2.74m, "BCE", 70.55m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b09b155d-3783-4b8b-a077-ed1c05a02e74"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 21, 18, 46, 0, 0, DateTimeKind.Utc), null, null, 34.81m, 3.45m, "N", 10.09m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f3224546-0de9-41c1-bbf1-cea8e1de19aa"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 31, 17, 6, 0, 0, DateTimeKind.Utc), null, null, 175.57m, 3.35m, "UUT", 52.41m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("95b77aef-d7ae-4e49-9b1f-6f2333c9f9af"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 30, 18, 5, 0, 0, DateTimeKind.Utc), null, null, 227.31m, 3.00m, "RVW", 75.77m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8e799505-5c9e-42e1-ab6c-1d7e6ed5d4d8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 19, 16, 19, 0, 0, DateTimeKind.Utc), null, null, 10.74m, 2.31m, "B", 4.65m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8035b5a1-ff30-4380-b6ce-18f656c43c7d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 3, 15, 32, 0, 0, DateTimeKind.Utc), null, null, 12.79m, 3.06m, "U", 4.18m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e73acfec-3aae-40b1-85e1-a016d28570a3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 28, 19, 11, 0, 0, DateTimeKind.Utc), null, null, 19.60m, 1.01m, "KH", 19.41m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("01b36e58-1cea-4c65-a2bc-95060a2f12ce"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 26, 16, 3, 0, 0, DateTimeKind.Utc), null, null, 64.49m, 0.76m, "W", 84.86m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("def2d8c9-701a-4518-b017-74b0baaf1f91"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 26, 19, 32, 0, 0, DateTimeKind.Utc), null, null, 126.79m, 1.66m, "EI", 76.38m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e6707262-7706-41b6-bb66-829c7755f391"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 4, 18, 20, 0, 0, DateTimeKind.Utc), null, null, 334.27m, 4.72m, "X", 70.82m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4d5d00b3-9d47-4740-be47-ce483d02de3f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 14, 20, 43, 0, 0, DateTimeKind.Utc), null, null, 149.87m, 3.60m, "MB", 41.63m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("46285f13-81c2-46ee-b2f1-364e641e4eb6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 25, 20, 8, 0, 0, DateTimeKind.Utc), null, null, 21.02m, 0.36m, "PLI", 58.4m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6025b380-7121-4896-b61b-120e33c6aff7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 11, 19, 55, 0, 0, DateTimeKind.Utc), null, null, 8.49m, 0.30m, "OAR", 28.31m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6b912c0e-1ce8-48c4-8a9e-8c86cfec203e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 28, 16, 6, 0, 0, DateTimeKind.Utc), null, null, 53.57m, 1.02m, "QN", 52.52m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a9794259-f811-47c9-9a68-520ebc13dc24"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 15, 18, 52, 0, 0, DateTimeKind.Utc), null, null, 25.62m, 3.90m, "Z", 6.57m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dc677feb-7817-48a3-92a0-506bac5bdee2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 5, 19, 20, 0, 0, DateTimeKind.Utc), null, null, 10.43m, 0.59m, "HFI", 17.68m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9c0c07a0-95ca-40c8-812b-c3445fdffd8a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 3, 17, 7, 0, 0, DateTimeKind.Utc), null, null, 22.25m, 0.61m, "UO", 36.47m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0f8f4f2a-bbf8-48ba-a0c0-2e43b3e9397d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 17, 15, 28, 0, 0, DateTimeKind.Utc), null, null, 9.36m, 1.32m, "I", 7.09m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c2cde6f8-00f1-4f1c-b8b0-43f934e25781"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 10, 17, 7, 0, 0, DateTimeKind.Utc), null, null, 1.43m, 0.48m, "BL", 2.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e927e310-fa20-4637-a23c-659163e2055a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 27, 16, 46, 0, 0, DateTimeKind.Utc), null, null, 20.97m, 0.21m, "YH", 99.87m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("91ef209e-2b6c-45b4-a30f-18dd6fa89714"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 29, 19, 50, 0, 0, DateTimeKind.Utc), null, null, 4.04m, 1.26m, "NJ", 3.21m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("de9c3860-ceb5-462b-9238-a6debcdae648"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 18, 20, 41, 0, 0, DateTimeKind.Utc), null, null, 121.96m, 1.90m, "A", 64.19m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("965f0afe-50c6-4cf0-aafc-5856534f71bf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 5, 20, 29, 0, 0, DateTimeKind.Utc), null, null, 11.27m, 0.96m, "V", 11.74m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7bfdf1a5-cf9b-4616-b4f7-1d161f72f9ad"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 16, 19, 57, 0, 0, DateTimeKind.Utc), null, null, 145.84m, 2.05m, "SJ", 71.14m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c56ace22-6286-46de-9905-59909e330863"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 14, 18, 41, 0, 0, DateTimeKind.Utc), null, null, 360.30m, 4.79m, "WL", 75.22m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("87b68488-1a9a-43eb-8ee3-4f75ce49b0a2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 18, 14, 39, 0, 0, DateTimeKind.Utc), null, null, 116.46m, 1.74m, "ZA", 66.93m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5b903aa8-fe01-4cbd-87e9-01e14d752bcf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 9, 18, 9, 0, 0, DateTimeKind.Utc), null, null, 73.03m, 1.11m, "BVS", 65.79m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("05528d08-c30b-42ed-80dd-cacc0cb17548"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 25, 15, 58, 0, 0, DateTimeKind.Utc), null, null, 380.52m, 4.84m, "TS", 78.62m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9d3a41f9-64d8-4488-8f10-5db5954e6647"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 22, 18, 19, 0, 0, DateTimeKind.Utc), null, null, 99.52m, 2.06m, "QE", 48.31m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("71f9fa26-b31b-405f-b4e8-482944fdaf5c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 26, 14, 46, 0, 0, DateTimeKind.Utc), null, null, 161.97m, 1.96m, "A", 82.64m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bfb1ea2a-0d7e-469b-979f-0bb5414eacd6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 28, 20, 11, 0, 0, DateTimeKind.Utc), null, null, 28.43m, 1.20m, "JNX", 23.69m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cd4ee7d5-0b88-4d31-a850-69f9a1690017"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 4, 17, 53, 0, 0, DateTimeKind.Utc), null, null, 9.53m, 0.14m, "MD", 68.07m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c1069a33-e3df-4f06-b4da-28e9c26a9217"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 14, 15, 0, 0, 0, DateTimeKind.Utc), null, null, 126.70m, 2.95m, "BJX", 42.95m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("986f9506-22d9-4ca2-82b0-7f9058e3d203"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 16, 17, 5, 0, 0, DateTimeKind.Utc), null, null, 10.73m, 3.10m, "TJB", 3.46m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("850d3e48-c937-4f35-b86f-b2dd61be8f2c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 10, 17, 53, 0, 0, DateTimeKind.Utc), null, null, 49.71m, 4.65m, "KKB", 10.69m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("aaba9b61-e31d-422f-9614-98f41f3eaa61"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 4, 16, 51, 0, 0, DateTimeKind.Utc), null, null, 261.54m, 3.49m, "T", 74.94m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("119bd17f-c0f6-4493-ac5e-e082b43df621"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 26, 17, 43, 0, 0, DateTimeKind.Utc), null, null, 109.72m, 1.77m, "UCI", 61.99m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9f101b09-b249-4308-ad65-4875aa9ac291"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 26, 18, 16, 0, 0, DateTimeKind.Utc), null, null, 133.82m, 2.04m, "DC", 65.6m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("274a165f-005f-4879-a075-92dd57379957"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 11, 18, 22, 0, 0, DateTimeKind.Utc), null, null, 66.04m, 2.12m, "G", 31.15m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c1cf3c54-1b97-4655-a842-9ad01ac896cd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 5, 17, 42, 0, 0, DateTimeKind.Utc), null, null, 248.90m, 3.88m, "KG", 64.15m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d31e2c92-4e10-46db-a1b9-d2d3bf372b02"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 8, 18, 45, 0, 0, DateTimeKind.Utc), null, null, 15.04m, 0.99m, "EE", 15.19m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c928e792-8054-41e7-b811-2896988e4f9c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 3, 19, 44, 0, 0, DateTimeKind.Utc), null, null, 192.67m, 4.04m, "J", 47.69m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f481f77f-4257-4a75-b092-6ad77a4d52b7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 13, 14, 44, 0, 0, DateTimeKind.Utc), null, null, 205.82m, 4.75m, "XTO", 43.33m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e3d2729f-8e4d-4bd2-b3a4-2c5e7bcca081"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 9, 17, 13, 0, 0, DateTimeKind.Utc), null, null, 38.69m, 1.86m, "P", 20.8m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3571fc9d-71bb-48e7-a5de-b038973b92d3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 12, 14, 57, 0, 0, DateTimeKind.Utc), null, null, 133.42m, 2.84m, "QMQ", 46.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f96194dd-6dc6-4492-b82d-f712c58d7968"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 25, 17, 7, 0, 0, DateTimeKind.Utc), null, null, 233.36m, 2.49m, "L", 93.72m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("176c1960-0d45-4e87-ab29-1f38cc851473"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 2, 18, 56, 0, 0, DateTimeKind.Utc), null, null, 60.66m, 2.89m, "NR", 20.99m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b85b3ccf-81ce-4282-bd39-d40e8f3b404d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 19, 17, 47, 0, 0, DateTimeKind.Utc), null, null, 213.01m, 2.22m, "UON", 95.95m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5a3658b1-d8ff-4237-851c-e69ae9cf5b40"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 21, 16, 26, 0, 0, DateTimeKind.Utc), null, null, 63.78m, 2.23m, "W", 28.6m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ae6afa73-738a-4c9f-8ec3-960e41526e84"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 12, 16, 44, 0, 0, DateTimeKind.Utc), null, null, 121.09m, 4.62m, "EHZ", 26.21m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("db0e20ea-433b-4194-bd3b-e1b1b1dd675d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 27, 14, 47, 0, 0, DateTimeKind.Utc), null, null, 11.17m, 0.16m, "D", 69.79m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("66fc1122-1432-4aee-9c2b-1e18b5cfa88b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 7, 16, 52, 0, 0, DateTimeKind.Utc), null, null, 405.52m, 4.36m, "Z", 93.01m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2f96b2f9-b11d-4d5b-b266-1f9978a649f2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 11, 15, 14, 0, 0, DateTimeKind.Utc), null, null, 52.52m, 1.01m, "YHI", 52m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8b5aba23-2a5f-47b2-9e2a-8c82abb6702d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 27, 17, 14, 0, 0, DateTimeKind.Utc), null, null, 122.33m, 1.70m, "VW", 71.96m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c8b423d3-ebd6-42ab-a3b7-7903fdfa76f0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 18, 16, 9, 0, 0, DateTimeKind.Utc), null, null, 108.30m, 3.00m, "AC", 36.1m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d64975e2-bd7e-4771-bf33-f5b169646f42"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 30, 20, 13, 0, 0, DateTimeKind.Utc), null, null, 43.36m, 0.97m, "G", 44.7m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7cb7d6d3-b51e-4721-9158-5b9a8813d52d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 21, 18, 42, 0, 0, DateTimeKind.Utc), null, null, 485.75m, 4.92m, "A", 98.73m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b360a9d6-6e90-4571-8ae6-69be4de74f5b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 17, 17, 16, 0, 0, DateTimeKind.Utc), null, null, 4.45m, 0.05m, "ROG", 89.03m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("040ade0c-7bd9-473e-bb3b-6cf13cddcde6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 10, 19, 3, 0, 0, DateTimeKind.Utc), null, null, 188.77m, 2.54m, "I", 74.32m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("383c5ee4-75de-4e26-a8cf-94dc20d198eb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 26, 17, 1, 0, 0, DateTimeKind.Utc), null, null, 25.66m, 1.06m, "V", 24.21m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bcd3e8b7-dc7f-47d5-99c8-e3b143039217"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 31, 20, 34, 0, 0, DateTimeKind.Utc), null, null, 403.25m, 4.23m, "L", 95.33m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e6f06a70-d2fb-4df0-881e-ece0fb5730e7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 12, 17, 36, 0, 0, DateTimeKind.Utc), null, null, 207.23m, 4.74m, "QB", 43.72m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b8640fcd-7ddb-4097-a472-ab377a28b1cc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 29, 18, 10, 0, 0, DateTimeKind.Utc), null, null, 7.81m, 0.75m, "D", 10.41m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e6e6a883-b5c8-49e5-8c5a-846fe8744cd5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 20, 1, 0, 0, DateTimeKind.Utc), null, null, 30.74m, 3.08m, "ELE", 9.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("14ce2e6c-8a14-4312-afa6-7eab9a9a0312"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 24, 15, 36, 0, 0, DateTimeKind.Utc), null, null, 334.95m, 4.46m, "BW", 75.1m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d5dda67f-5b81-487c-9616-b0a9747c5819"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 26, 17, 15, 0, 0, DateTimeKind.Utc), null, null, 99.32m, 3.16m, "HHH", 31.43m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6902bf88-c7ba-4289-b743-1df24c34007c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 9, 16, 58, 0, 0, DateTimeKind.Utc), null, null, 1.64m, 0.20m, "TJE", 8.18m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4c488088-bde9-48b8-b253-7f0f7c91f10c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 22, 16, 13, 0, 0, DateTimeKind.Utc), null, null, 59.04m, 1.70m, "W", 34.73m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("abd82d7c-3ae0-4027-9505-68c1caf7cc4c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 15, 19, 39, 0, 0, DateTimeKind.Utc), null, null, 17.60m, 0.74m, "VTT", 23.79m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("09aed398-e11d-44d2-8b13-9b5e3019f0c5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 7, 17, 1, 0, 0, DateTimeKind.Utc), null, null, 38.12m, 2.83m, "OM", 13.47m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e6a1a6b6-042f-4cce-a9df-a9bdb6b2544f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 11, 19, 7, 0, 0, DateTimeKind.Utc), null, null, 307.35m, 3.95m, "JUJ", 77.81m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8818ddbb-fb57-4f3b-af2b-4dd64c8d3c55"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 24, 14, 31, 0, 0, DateTimeKind.Utc), null, null, 180.08m, 3.71m, "BIY", 48.54m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b97a1629-43e1-4b5d-ac54-37f0d7bd1111"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 3, 20, 10, 0, 0, DateTimeKind.Utc), null, null, 119.88m, 2.51m, "YPQ", 47.76m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e8ef7ad1-6f2b-4b1b-be2a-3359a034b6d8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 6, 17, 27, 0, 0, DateTimeKind.Utc), null, null, 41.89m, 1.35m, "P", 31.03m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3cc1b318-dd57-4250-8616-567b95f7140e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 10, 18, 37, 0, 0, DateTimeKind.Utc), null, null, 133.23m, 3.03m, "KRZ", 43.97m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3b6803ce-9361-4722-a8ff-dfda44895477"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 8, 18, 22, 0, 0, DateTimeKind.Utc), null, null, 454.12m, 4.57m, "BN", 99.37m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d23857bd-e03a-4e8b-ab0d-8d7880c0fa6f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 21, 18, 59, 0, 0, DateTimeKind.Utc), null, null, 312.09m, 4.27m, "U", 73.09m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("337cc61c-dc2f-42fd-a505-3bc1696d919e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 26, 18, 48, 0, 0, DateTimeKind.Utc), null, null, 11.32m, 4.64m, "I", 2.44m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f6f86387-b6e6-408f-92a0-60ded7456784"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 19, 46, 0, 0, DateTimeKind.Utc), null, null, 359.39m, 4.46m, "KQM", 80.58m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("88783258-ba93-4226-9993-ccd0d9db1696"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 24, 20, 51, 0, 0, DateTimeKind.Utc), null, null, 4.91m, 0.86m, "JV", 5.71m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3fa09afb-1da2-41a9-8711-a7371d6c5f80"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 19, 2, 0, 0, DateTimeKind.Utc), null, null, 146.82m, 4.53m, "PB", 32.41m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5c7f5c0e-2575-49fc-b6e1-f24a136f50a8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 11, 16, 27, 0, 0, DateTimeKind.Utc), null, null, 54.47m, 0.64m, "Z", 85.11m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("32562a50-2be7-4792-961a-834f5c39f715"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 19, 55, 0, 0, DateTimeKind.Utc), null, null, 3.81m, 0.08m, "B", 47.65m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c6546414-331d-4583-a874-8f8ba4a01e12"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 19, 19, 50, 0, 0, DateTimeKind.Utc), null, null, 79.64m, 3.65m, "SCF", 21.82m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9cab2461-ffdc-4bcb-b0f5-ae8102ab748f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 22, 18, 58, 0, 0, DateTimeKind.Utc), null, null, 403.38m, 4.35m, "KRY", 92.73m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6caa2c30-67ca-4d2e-8335-612f09560fc0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 10, 16, 33, 0, 0, DateTimeKind.Utc), null, null, 173.63m, 4.93m, "Z", 35.22m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7c519d27-f6bb-4eae-b546-bd6c2b3ba28f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 29, 17, 31, 0, 0, DateTimeKind.Utc), null, null, 2.82m, 0.06m, "BZP", 47.08m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4f4aefc8-6405-4993-b443-d13d36726ab0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 4, 20, 2, 0, 0, DateTimeKind.Utc), null, null, 154.25m, 1.57m, "SVS", 98.25m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("24f2d861-969c-46f8-85bc-dfd77e05107e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 27, 20, 0, 0, 0, DateTimeKind.Utc), null, null, 249.33m, 3.82m, "ZFJ", 65.27m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5750f4b5-9ebe-41ee-9287-f9d287fbd462"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 10, 17, 34, 0, 0, DateTimeKind.Utc), null, null, 66.00m, 4.13m, "XRT", 15.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3ddf6aa1-dd99-435e-835e-c9741dff2f9d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 18, 17, 10, 0, 0, DateTimeKind.Utc), null, null, 51.81m, 1.48m, "PP", 35.01m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f33a90c8-b13c-47a3-b313-01a7a6238473"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 17, 18, 11, 0, 0, DateTimeKind.Utc), null, null, 158.30m, 2.35m, "MUO", 67.36m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9fc5fce6-2180-45bf-baa4-a70cf22906f0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 12, 19, 46, 0, 0, DateTimeKind.Utc), null, null, 133.66m, 4.11m, "N", 32.52m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5b8fd5d7-f8dc-443c-8138-fd6e10372da7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 17, 15, 0, 0, 0, DateTimeKind.Utc), null, null, 310.70m, 4.52m, "EE", 68.74m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("43818701-d949-4a90-a97c-d0dd0772fbef"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 21, 18, 12, 0, 0, DateTimeKind.Utc), null, null, 167.90m, 1.84m, "VGZ", 91.25m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2ee4915f-3df6-4895-b7d1-f939147b2ffd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 29, 16, 13, 0, 0, DateTimeKind.Utc), null, null, 30.94m, 1.39m, "YX", 22.26m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b1bf8bbe-1228-4b67-ba9e-d724a20e9ac1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 28, 18, 8, 0, 0, DateTimeKind.Utc), null, null, 131.40m, 1.36m, "XFU", 96.62m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0787eba6-4968-4f87-bf78-21f19e25a89e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 13, 14, 32, 0, 0, DateTimeKind.Utc), null, null, 77.02m, 1.21m, "XEL", 63.65m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ff24bca2-e884-4214-ad64-fe72f98a4a42"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 6, 15, 18, 0, 0, DateTimeKind.Utc), null, null, 103.28m, 1.29m, "NO", 80.06m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fdddaf5b-a3d9-49d4-8955-446ef0fba75d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 21, 15, 38, 0, 0, DateTimeKind.Utc), null, null, 15.13m, 0.27m, "EO", 56.04m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f4ad3b0b-7db7-4ce1-8810-9813cfea78f0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 18, 17, 56, 0, 0, DateTimeKind.Utc), null, null, 49.70m, 1.32m, "I", 37.65m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2c94882c-7508-4681-9823-ad6cd013b6d0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 8, 18, 43, 0, 0, DateTimeKind.Utc), null, null, 93.94m, 2.93m, "ST", 32.06m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a5ffc036-3331-4299-9e9d-0a1c1e38daa7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 13, 18, 46, 0, 0, DateTimeKind.Utc), null, null, 99.44m, 2.86m, "F", 34.77m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("af3400ac-b0e7-4aff-9ca3-20fa2091d226"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 27, 20, 10, 0, 0, DateTimeKind.Utc), null, null, 172.73m, 2.37m, "CGX", 72.88m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a7efcd26-a60c-4f84-9e4e-f48d1166a117"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 10, 19, 4, 0, 0, DateTimeKind.Utc), null, null, 41.20m, 0.51m, "JPX", 80.79m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c1a2fcbc-973e-4b61-8895-cdba2c38a438"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 19, 14, 34, 0, 0, DateTimeKind.Utc), null, null, 38.85m, 0.53m, "I", 73.3m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cc1342d6-2f5c-49db-a476-505ebc20406d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 19, 15, 40, 0, 0, DateTimeKind.Utc), null, null, 389.93m, 4.05m, "T", 96.28m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0e29a643-86b2-4c38-bd36-81491f71780f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 27, 15, 18, 0, 0, DateTimeKind.Utc), null, null, 61.82m, 4.62m, "A", 13.38m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3e55816a-d11b-4390-a67b-b56f6cbad678"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 14, 18, 51, 0, 0, DateTimeKind.Utc), null, null, 5.04m, 0.41m, "ZDQ", 12.3m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9c104f33-bf0e-4b08-b72f-af2b832e535e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 8, 18, 7, 0, 0, DateTimeKind.Utc), null, null, 27.59m, 0.76m, "O", 36.3m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6e5f2125-3c9a-4355-8b89-004e33b4ae53"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 30, 16, 22, 0, 0, DateTimeKind.Utc), null, null, 166.12m, 2.12m, "YL", 78.36m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("be6e1027-a528-4df9-99a7-8b18984c7e37"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 29, 17, 53, 0, 0, DateTimeKind.Utc), null, null, 6.20m, 0.65m, "A", 9.54m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("02b43c26-b3ad-428b-8b72-c4eafd4a1103"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 21, 14, 53, 0, 0, DateTimeKind.Utc), null, null, 405.16m, 4.12m, "J", 98.34m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4d26cbca-6d9b-4940-a4ac-3c336d5939b3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 15, 15, 39, 0, 0, DateTimeKind.Utc), null, null, 61.04m, 1.74m, "YX", 35.08m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f81af99d-522d-4341-870f-c5d15d48a50d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 12, 19, 42, 0, 0, DateTimeKind.Utc), null, null, 188.34m, 3.15m, "VH", 59.79m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("500ebec3-ebdd-4e18-a0e2-efd567bea252"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 27, 18, 35, 0, 0, DateTimeKind.Utc), null, null, 228.63m, 3.15m, "YVG", 72.58m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d30b5d5d-dd24-4da6-b1e7-ba9600b4ec92"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 11, 14, 38, 0, 0, DateTimeKind.Utc), null, null, 10.74m, 0.38m, "RWX", 28.25m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e42ad35a-3ffa-44cb-9b5b-aa3177eb5e7c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 24, 19, 36, 0, 0, DateTimeKind.Utc), null, null, 107.60m, 4.65m, "P", 23.14m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dfcce254-7f80-4758-b3f5-78ddd93d27f7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 25, 17, 38, 0, 0, DateTimeKind.Utc), null, null, 86.64m, 4.56m, "JKY", 19m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bb4ed09f-0c50-4765-b8b7-b75f1c1a2390"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 21, 20, 2, 0, 0, DateTimeKind.Utc), null, null, 440.24m, 4.54m, "ZM", 96.97m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1ed6a5c6-b538-43b9-b8a9-047eaa9c7bd0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 16, 14, 49, 0, 0, DateTimeKind.Utc), null, null, 95.62m, 1.52m, "ETM", 62.91m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2d4ae3b1-8f44-4bfc-89b0-c0c7cb0bbd0b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 14, 51, 0, 0, DateTimeKind.Utc), null, null, 37.52m, 0.67m, "N", 56m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e44c5d38-5749-40d2-9b75-1c083da3f294"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 16, 20, 24, 0, 0, DateTimeKind.Utc), null, null, 36.70m, 0.50m, "PU", 73.4m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1ba0e069-c171-4be4-9a91-46cf079484c4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 17, 17, 8, 0, 0, DateTimeKind.Utc), null, null, 283.72m, 3.18m, "ES", 89.22m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3a7e5c15-f22c-432a-83d7-0cb5cfcd53b9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 8, 19, 53, 0, 0, DateTimeKind.Utc), null, null, 52.54m, 0.57m, "RQR", 92.18m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ddcf4e2e-f7c8-4ed5-bccc-c5eafe27a496"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 15, 15, 28, 0, 0, DateTimeKind.Utc), null, null, 423.23m, 4.26m, "PS", 99.35m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ec40fcb8-7210-41b4-b390-b99df207d7fa"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 13, 17, 5, 0, 0, DateTimeKind.Utc), null, null, 125.54m, 3.87m, "IP", 32.44m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("feb8244e-c182-47bd-827d-efb8106ffe99"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 16, 43, 0, 0, DateTimeKind.Utc), null, null, 140.02m, 3.29m, "RXZ", 42.56m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a5e9d3b8-3613-4881-a071-029037fc1699"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 20, 17, 12, 0, 0, DateTimeKind.Utc), null, null, 65.62m, 1.35m, "NPH", 48.61m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("74a48a8b-124d-451c-b0f2-76e61854d442"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 31, 15, 27, 0, 0, DateTimeKind.Utc), null, null, 75.17m, 1.51m, "AEW", 49.78m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("477f3031-ac20-48a3-9f8e-dd1b9d879276"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 2, 16, 0, 0, 0, DateTimeKind.Utc), null, null, 32.62m, 1.35m, "I", 24.16m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f4101be2-6af4-4b81-bd0a-1644c6438cff"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 26, 17, 22, 0, 0, DateTimeKind.Utc), null, null, 12.02m, 0.13m, "XH", 92.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a092871c-d246-49d8-9c6b-571bc26722b5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 1, 15, 7, 0, 0, DateTimeKind.Utc), null, null, 143.14m, 1.70m, "PC", 84.2m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d659ea80-7ada-433a-bd31-34472f6885f3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 20, 19, 16, 0, 0, DateTimeKind.Utc), null, null, 219.08m, 2.38m, "I", 92.05m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("01d8f649-89f1-428e-9e60-ea50d356ff98"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 26, 20, 7, 0, 0, DateTimeKind.Utc), null, null, 56.03m, 2.81m, "DK", 19.94m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d04995b5-d384-4136-915f-39281a437ba9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 31, 16, 47, 0, 0, DateTimeKind.Utc), null, null, 194.86m, 2.97m, "S", 65.61m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d1e8bde4-c96b-4453-a2b1-f3037434c8b7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 17, 15, 56, 0, 0, DateTimeKind.Utc), null, null, 26.77m, 2.54m, "S", 10.54m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("84388cad-b7f4-4021-8861-bde533aff781"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 12, 17, 5, 0, 0, DateTimeKind.Utc), null, null, 159.32m, 2.62m, "KX", 60.81m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7083d7f7-6660-4e4f-8420-d2d137782cfd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 2, 18, 37, 0, 0, DateTimeKind.Utc), null, null, 19.89m, 4.50m, "Z", 4.42m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("080c8a99-cd16-4521-80f5-1342be920334"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 26, 17, 47, 0, 0, DateTimeKind.Utc), null, null, 8.69m, 0.33m, "YN", 26.32m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9d74ebb2-2c67-44b5-be53-a1812fea277b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 25, 19, 43, 0, 0, DateTimeKind.Utc), null, null, 27.16m, 0.29m, "PLC", 93.64m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6c59d41a-e9b6-464a-ab9d-5d2baeddf6ae"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 13, 20, 52, 0, 0, DateTimeKind.Utc), null, null, 69.69m, 0.73m, "AO", 95.46m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b34eafe0-1911-4794-98bc-1a68ea583ec1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 8, 17, 7, 0, 0, DateTimeKind.Utc), null, null, 26.72m, 0.65m, "BC", 41.11m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c93db214-0a37-4840-880f-64a68342fa1f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 7, 15, 17, 0, 0, DateTimeKind.Utc), null, null, 224.25m, 2.99m, "OVG", 75m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b274639b-99ad-4c69-84a3-34d89169935b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 26, 18, 0, 0, 0, DateTimeKind.Utc), null, null, 124.13m, 2.03m, "OQU", 61.15m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6a4c2f6f-12b9-4ea5-8266-923e554c005b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 19, 17, 13, 0, 0, DateTimeKind.Utc), null, null, 313.54m, 4.59m, "SAP", 68.31m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1efcc428-5b39-4f6d-bc1d-56e7d317ecf6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 14, 18, 46, 0, 0, DateTimeKind.Utc), null, null, 21.47m, 1.36m, "SGG", 15.79m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5cb1ce2a-23bb-473b-8fdb-244d17ae0c75"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 10, 15, 4, 0, 0, DateTimeKind.Utc), null, null, 80.45m, 1.77m, "PQO", 45.45m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("af52d19e-bb0d-4a50-9fc3-9d194f848ff6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 11, 15, 39, 0, 0, DateTimeKind.Utc), null, null, 115.46m, 4.40m, "DU", 26.24m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("04ecd68a-f1de-4b9e-b11d-4a98cb0a467e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 30, 17, 36, 0, 0, DateTimeKind.Utc), null, null, 30.71m, 2.33m, "BO", 13.18m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("03d295e0-ea7b-4aac-8d4c-c2d927055a3a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 10, 19, 3, 0, 0, DateTimeKind.Utc), null, null, 97.06m, 1.40m, "PW", 69.33m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("09fb10ea-80b6-46fa-a698-6933656129bb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 21, 15, 40, 0, 0, DateTimeKind.Utc), null, null, 41.79m, 0.87m, "S", 48.04m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5bba1e07-ae2b-4004-a254-b348232fefff"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 23, 18, 46, 0, 0, DateTimeKind.Utc), null, null, 40.82m, 3.59m, "ZKB", 11.37m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("932fcfa9-4c92-470a-aa89-d5bae8828534"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 20, 17, 44, 0, 0, DateTimeKind.Utc), null, null, 10.15m, 0.19m, "MN", 53.44m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ec3adba0-27db-488b-ab2d-5b96efe0f322"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 5, 20, 30, 0, 0, DateTimeKind.Utc), null, null, 46.27m, 0.53m, "ZJE", 87.31m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2de0854e-8db8-4478-9c8e-b552147cd1a0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 29, 20, 43, 0, 0, DateTimeKind.Utc), null, null, 178.27m, 4.07m, "K", 43.8m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("81e6d07a-8b26-45f3-8146-5f6bc32bc9b7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 5, 15, 22, 0, 0, DateTimeKind.Utc), null, null, 271.23m, 4.51m, "Z", 60.14m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dd0f58dd-d917-4893-9ad2-7ed06efda901"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 22, 16, 46, 0, 0, DateTimeKind.Utc), null, null, 73.44m, 1.12m, "FT", 65.57m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("af03d35d-f287-4265-a7d2-285916e1aa56"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 24, 16, 3, 0, 0, DateTimeKind.Utc), null, null, 50.49m, 1.02m, "RP", 49.5m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7e2585d7-31ec-4bff-b782-0a901671857c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 29, 20, 19, 0, 0, DateTimeKind.Utc), null, null, 203.49m, 2.86m, "PCM", 71.15m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ee166433-0a7c-405e-b51d-a258053649da"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 25, 20, 39, 0, 0, DateTimeKind.Utc), null, null, 87.37m, 1.08m, "BH", 80.9m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("71ba118a-4161-4faf-b321-00a8560760ee"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 5, 18, 51, 0, 0, DateTimeKind.Utc), null, null, 4.09m, 1.78m, "DWO", 2.3m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1bfa909b-89db-4c3d-8594-5c899d56c1fd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 8, 15, 44, 0, 0, DateTimeKind.Utc), null, null, 95.66m, 2.78m, "F", 34.41m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("20371249-df58-45a1-91d1-691b0fe4c929"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 15, 18, 51, 0, 0, DateTimeKind.Utc), null, null, 3.53m, 0.26m, "DEG", 13.58m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("852b8897-b880-4675-955c-1a98af032e58"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 16, 19, 5, 0, 0, DateTimeKind.Utc), null, null, 268.90m, 4.56m, "R", 58.97m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("92ca4e30-cfce-4e35-b7e1-bc4cd42ec240"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 12, 18, 16, 0, 0, DateTimeKind.Utc), null, null, 133.80m, 1.72m, "T", 77.79m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a6d03838-0d80-4733-bdca-e256d52409fb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 22, 19, 24, 0, 0, DateTimeKind.Utc), null, null, 165.17m, 4.73m, "W", 34.92m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ba97fa6a-c762-488b-bbec-4c764f5e9bc5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 4, 20, 34, 0, 0, DateTimeKind.Utc), null, null, 15.33m, 0.23m, "P", 66.65m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1c1e7b33-0000-4645-8acf-3aca05e30b53"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 4, 18, 27, 0, 0, DateTimeKind.Utc), null, null, 80.60m, 1.69m, "G", 47.69m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("47fd3f60-8544-4e5e-be9c-9157a9e48d28"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 5, 18, 5, 0, 0, DateTimeKind.Utc), null, null, 46.32m, 1.09m, "N", 42.5m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d3c2ee9e-3bdb-47d9-b075-3c1c2675b9dc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 9, 19, 3, 0, 0, DateTimeKind.Utc), null, null, 95.94m, 1.30m, "JDO", 73.8m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e68de543-cc11-4697-a091-3c58e2d85ec1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 17, 19, 27, 0, 0, DateTimeKind.Utc), null, null, 12.63m, 0.43m, "TS", 29.37m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("50b4aa85-ec9c-48c3-9302-f00f8aec57dc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 19, 50, 0, 0, DateTimeKind.Utc), null, null, 135.58m, 2.74m, "DZ", 49.48m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4ee6c6da-6a68-40a6-b2cd-87fdc3b7513d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 15, 19, 31, 0, 0, DateTimeKind.Utc), null, null, 29.15m, 0.72m, "XO", 40.48m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1e519572-2959-4e70-bee5-80c407829130"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 31, 16, 13, 0, 0, DateTimeKind.Utc), null, null, 87.27m, 2.41m, "MG", 36.21m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2893b767-b8e6-4062-93f5-4f1d67336843"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 19, 19, 0, 0, 0, DateTimeKind.Utc), null, null, 91.45m, 1.56m, "SJ", 58.62m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("973686ac-3030-40a1-a01b-47febd61a314"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 16, 14, 40, 0, 0, DateTimeKind.Utc), null, null, 108.89m, 3.69m, "POV", 29.51m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a981106b-3b23-46e6-b53f-506fc5e1a9b7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 15, 14, 40, 0, 0, DateTimeKind.Utc), null, null, 51.39m, 0.63m, "Z", 81.57m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a0e5baba-f980-4888-b850-b80b4b9afeb0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 28, 19, 23, 0, 0, DateTimeKind.Utc), null, null, 71.78m, 1.67m, "Q", 42.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9c00f147-eeba-4b7f-911d-d62f3d3983ff"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 11, 14, 48, 0, 0, DateTimeKind.Utc), null, null, 38.81m, 0.91m, "OBT", 42.65m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("50527a72-38a1-4da1-b48b-a9f5efd02118"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 23, 20, 32, 0, 0, DateTimeKind.Utc), null, null, 392.22m, 4.92m, "DWV", 79.72m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b9c9e465-90c8-43e0-86a5-269534de5088"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 2, 15, 35, 0, 0, DateTimeKind.Utc), null, null, 97.86m, 1.33m, "LGX", 73.58m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9be59412-118a-48ea-b981-a3e2cd7a9535"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 21, 17, 53, 0, 0, DateTimeKind.Utc), null, null, 23.69m, 1.42m, "NK", 16.68m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c0920400-c00a-45e5-9641-10e1502c0252"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 5, 14, 58, 0, 0, DateTimeKind.Utc), null, null, 89.93m, 2.73m, "TME", 32.94m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("84299b1d-65a0-4623-b191-59bed565e334"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 15, 19, 33, 0, 0, DateTimeKind.Utc), null, null, 90.43m, 0.97m, "K", 93.23m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b4f47ed9-9c5c-4696-b5f0-44c81f0f6603"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 17, 16, 10, 0, 0, DateTimeKind.Utc), null, null, 0.66m, 0.10m, "EPT", 6.6m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("19aa337c-3f2a-4f9b-8fde-3de658685f3b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 18, 14, 53, 0, 0, DateTimeKind.Utc), null, null, 212.04m, 4.96m, "YM", 42.75m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("406c20eb-5328-48fd-af54-3cb7e3cc90ec"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 8, 15, 55, 0, 0, DateTimeKind.Utc), null, null, 45.63m, 3.59m, "GXZ", 12.71m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("71b6e25b-1e85-4a01-b895-e3432be6fe2b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 27, 18, 19, 0, 0, DateTimeKind.Utc), null, null, 259.58m, 4.99m, "E", 52.02m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("be1f4cff-9126-4cab-8736-5a94ea4f0e93"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 12, 14, 42, 0, 0, DateTimeKind.Utc), null, null, 57.50m, 4.51m, "VS", 12.75m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c0d030e2-e283-4098-9bb6-4a0d0540f9fe"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 25, 14, 56, 0, 0, DateTimeKind.Utc), null, null, 279.09m, 3.38m, "J", 82.57m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("897b7a98-1bbd-4e1e-bb1a-eae7231d840c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 31, 16, 16, 0, 0, DateTimeKind.Utc), null, null, 232.87m, 2.47m, "J", 94.28m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2aaa4d79-2dec-4a3d-997a-8f8ba40905bc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 24, 18, 30, 0, 0, DateTimeKind.Utc), null, null, 108.03m, 1.44m, "OVL", 75.02m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("40a73698-d3af-49dd-9641-950b60df9858"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 14, 20, 23, 0, 0, DateTimeKind.Utc), null, null, 26.39m, 0.51m, "XAU", 51.74m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("51df1eab-32c2-47e8-b5df-82788cd6264a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 1, 16, 32, 0, 0, DateTimeKind.Utc), null, null, 25.19m, 4.77m, "QSW", 5.28m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3e3bb18a-adcb-4886-9e1a-55f52bb76035"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 8, 20, 35, 0, 0, DateTimeKind.Utc), null, null, 6.21m, 0.94m, "U", 6.61m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f9080741-d641-4351-b3c3-53e213262084"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 7, 20, 50, 0, 0, DateTimeKind.Utc), null, null, 260.24m, 3.10m, "A", 83.95m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fc3e3704-2e0b-4e86-8b5a-0996ec3df612"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 23, 20, 41, 0, 0, DateTimeKind.Utc), null, null, 87.09m, 0.96m, "HY", 90.72m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("07c75b7d-f414-4f0b-8f58-44c6c36288e9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 22, 20, 31, 0, 0, DateTimeKind.Utc), null, null, 195.98m, 1.96m, "TJ", 99.99m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("910544a5-42d3-4574-bcb3-7d29cdae4ca9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 4, 15, 42, 0, 0, DateTimeKind.Utc), null, null, 8.67m, 0.12m, "EPE", 72.21m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f620eb04-f8e7-4db5-a0ec-ac78194e0894"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 11, 15, 14, 0, 0, DateTimeKind.Utc), null, null, 63.22m, 4.33m, "CE", 14.6m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7609c506-5fa6-41eb-be4f-ed7ead08ab28"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 9, 20, 13, 0, 0, DateTimeKind.Utc), null, null, 200.40m, 2.66m, "H", 75.34m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f3c356db-fe5d-4cd4-aa2b-10c28a1e2d49"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 17, 19, 37, 0, 0, DateTimeKind.Utc), null, null, 384.07m, 3.94m, "LQ", 97.48m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7bcbe934-1bcf-4a2a-acd6-c5afbc831f68"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 5, 15, 52, 0, 0, DateTimeKind.Utc), null, null, 47.76m, 1.79m, "UP", 26.68m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("80795f27-fe11-4724-92ec-bc2733189010"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 20, 19, 0, 0, DateTimeKind.Utc), null, null, 58.98m, 0.79m, "G", 74.66m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("448d3d8c-3109-4639-8032-4c2a7df1e210"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 21, 17, 47, 0, 0, DateTimeKind.Utc), null, null, 57.80m, 0.89m, "P", 64.94m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d443066a-4db9-4dc1-82b2-c91ceb0b8ebf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 4, 18, 7, 0, 0, DateTimeKind.Utc), null, null, 313.66m, 4.78m, "Z", 65.62m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3e370a41-c328-42b8-bc96-d02a4c247307"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 16, 17, 15, 0, 0, DateTimeKind.Utc), null, null, 200.30m, 2.54m, "SR", 78.86m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("71381d31-3e3d-442f-a832-520ac791470f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 31, 20, 28, 0, 0, DateTimeKind.Utc), null, null, 16.58m, 1.66m, "JVB", 9.99m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("99e9d83e-c6eb-4713-8345-9a5766b5aa70"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 4, 19, 29, 0, 0, DateTimeKind.Utc), null, null, 41.77m, 0.85m, "DU", 49.14m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3d1016ce-a391-42b8-ac36-e56bc2fa8906"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 17, 19, 34, 0, 0, DateTimeKind.Utc), null, null, 68.31m, 4.39m, "PSP", 15.56m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("211d7898-1d8d-4a2a-b0ef-a760ab3901ee"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 17, 17, 37, 0, 0, DateTimeKind.Utc), null, null, 133.86m, 1.37m, "C", 97.71m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("09329adc-718d-4cab-8303-9ec8c78392e5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 7, 18, 58, 0, 0, DateTimeKind.Utc), null, null, 34.50m, 2.22m, "WQ", 15.54m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e6f03b43-1457-48f7-9b83-63f772ff0eb6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 16, 20, 25, 0, 0, DateTimeKind.Utc), null, null, 25.24m, 3.50m, "FPH", 7.21m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9df84213-111a-47d5-9bf6-4fbb3ddb87ec"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 24, 19, 42, 0, 0, DateTimeKind.Utc), null, null, 33.14m, 0.78m, "GYR", 42.49m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a597c726-a859-4cc0-9331-cfda3c642ae2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 13, 17, 44, 0, 0, DateTimeKind.Utc), null, null, 204.94m, 2.44m, "S", 83.99m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("85b84bea-4a26-4873-a3b5-433b9c0c58aa"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 17, 18, 10, 0, 0, DateTimeKind.Utc), null, null, 284.35m, 3.45m, "GQH", 82.42m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4bcfedf7-ff55-4e08-868a-273e3905cc69"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 3, 20, 33, 0, 0, DateTimeKind.Utc), null, null, 35.42m, 2.01m, "F", 17.62m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("805b0a80-8d4a-4127-b55c-1d5a7360fb26"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 9, 15, 38, 0, 0, DateTimeKind.Utc), null, null, 70.78m, 1.19m, "ET", 59.48m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4a8dcaae-1cd1-4a69-87d5-11276c8f0170"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 3, 18, 27, 0, 0, DateTimeKind.Utc), null, null, 332.32m, 4.53m, "IEY", 73.36m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d525f6ba-06db-40ad-a7e7-658ceb96e0e0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 10, 18, 55, 0, 0, DateTimeKind.Utc), null, null, 37.60m, 0.68m, "AX", 55.3m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e1f7712a-08f7-425f-9ce1-94c7157b2d05"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 22, 20, 59, 0, 0, DateTimeKind.Utc), null, null, 459.41m, 4.84m, "MW", 94.92m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5756f30f-d8f5-4188-8c16-d5c33d891b13"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 8, 20, 52, 0, 0, DateTimeKind.Utc), null, null, 235.85m, 4.87m, "BM", 48.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4fc22687-4170-44ff-b6d3-9bcc46ef39cd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 24, 20, 56, 0, 0, DateTimeKind.Utc), null, null, 95.89m, 2.87m, "S", 33.41m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5877c2d4-348e-4fd1-9da9-a7316ca74789"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 29, 20, 37, 0, 0, DateTimeKind.Utc), null, null, 253.05m, 3.83m, "I", 66.07m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("21a0a0b9-ad02-4935-8ee2-2c0357aabca2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 10, 20, 17, 0, 0, DateTimeKind.Utc), null, null, 7.31m, 3.73m, "Q", 1.96m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9826a2e4-260f-47e9-9aed-43960fe842b3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 22, 16, 19, 0, 0, DateTimeKind.Utc), null, null, 145.25m, 2.11m, "JVY", 68.84m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("22fc1578-44fa-440b-a31c-126f97f98619"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 14, 15, 48, 0, 0, DateTimeKind.Utc), null, null, 38.54m, 1.78m, "OY", 21.65m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("80364867-e37e-4498-96d5-100c0364dc41"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 27, 17, 30, 0, 0, DateTimeKind.Utc), null, null, 283.98m, 3.28m, "CH", 86.58m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c1085f69-173d-4203-bc36-90294a46dc12"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 29, 17, 18, 0, 0, DateTimeKind.Utc), null, null, 189.77m, 3.74m, "SZ", 50.74m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("675ad417-07eb-4d86-8341-931ad6155095"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 6, 17, 9, 0, 0, DateTimeKind.Utc), null, null, 258.52m, 3.35m, "VMN", 77.17m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fe119a80-f0da-4d9b-b212-727fc67a1134"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 21, 19, 41, 0, 0, DateTimeKind.Utc), null, null, 57.52m, 0.81m, "W", 71.01m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("df7e5e43-05d4-420b-8ef7-ddc0ec1fc760"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 12, 15, 37, 0, 0, DateTimeKind.Utc), null, null, 35.22m, 4.47m, "ZV", 7.88m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6a074062-a4cb-4efa-9994-57f780e79f05"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 4, 18, 34, 0, 0, DateTimeKind.Utc), null, null, 246.07m, 4.38m, "ZN", 56.18m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8625b85a-ded1-477b-9b14-31903d99503e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 2, 20, 5, 0, 0, DateTimeKind.Utc), null, null, 167.31m, 3.38m, "QKJ", 49.5m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f475ec2f-c78e-42ed-8d98-b4c6704063cb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 22, 15, 28, 0, 0, DateTimeKind.Utc), null, null, 70.39m, 3.97m, "UMS", 17.73m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("27e0d84c-b3fe-4b74-ac39-7c616ec05283"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 8, 17, 55, 0, 0, DateTimeKind.Utc), null, null, 412.20m, 4.92m, "LIX", 83.78m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("35ee8cc4-79ed-4960-92c2-dc643cc01878"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 11, 16, 4, 0, 0, DateTimeKind.Utc), null, null, 171.29m, 2.38m, "P", 71.97m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("38f68c3e-0ae4-4117-93cf-89c9d8508a4e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 15, 48, 0, 0, DateTimeKind.Utc), null, null, 23.63m, 0.62m, "XW", 38.12m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7029d089-6d97-433b-ad92-b2bb15f8aa75"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 6, 14, 53, 0, 0, DateTimeKind.Utc), null, null, 53.50m, 1.90m, "BK", 28.16m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e1b157c1-3c10-4d70-b673-1b756cded5b1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 25, 20, 48, 0, 0, DateTimeKind.Utc), null, null, 0.67m, 0.30m, "AYC", 2.23m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3e461513-28f5-4bfa-b5e7-1e1f4fc8560a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 25, 20, 7, 0, 0, DateTimeKind.Utc), null, null, 71.18m, 3.97m, "GNR", 17.93m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b4502530-21b6-4881-aa4d-c8bbe8f15524"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 6, 14, 32, 0, 0, DateTimeKind.Utc), null, null, 120.09m, 4.85m, "ARM", 24.76m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("05fdb2f2-d614-45f5-8b43-ed4a145ea5d8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 4, 14, 39, 0, 0, DateTimeKind.Utc), null, null, 46.42m, 0.53m, "I", 87.59m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c3c0a9d1-b209-4c7c-aec3-984c19e17b79"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 18, 19, 45, 0, 0, DateTimeKind.Utc), null, null, 405.53m, 4.12m, "SF", 98.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4b0b6b1e-73ee-426c-909a-121ed32f48bf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 27, 20, 22, 0, 0, DateTimeKind.Utc), null, null, 149.09m, 3.73m, "GO", 39.97m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("81e86f16-c3cf-4291-a6af-e94e35ea2109"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 16, 15, 26, 0, 0, DateTimeKind.Utc), null, null, 112.63m, 1.24m, "WJJ", 90.83m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3d4a2575-09ea-4f47-9a4c-02ce1ccb8349"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 22, 15, 5, 0, 0, DateTimeKind.Utc), null, null, 76.28m, 2.48m, "UR", 30.76m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("51e3f5d2-93f8-416a-a5ae-7d19a28c003c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 29, 17, 35, 0, 0, DateTimeKind.Utc), null, null, 212.97m, 2.28m, "KA", 93.41m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8b70c9ce-f9b8-429a-b320-a42ada968c86"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 24, 16, 56, 0, 0, DateTimeKind.Utc), null, null, 350.21m, 4.33m, "XYH", 80.88m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a891801a-7138-443c-a708-970380931d39"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 22, 16, 30, 0, 0, DateTimeKind.Utc), null, null, 26.99m, 0.92m, "LZ", 29.34m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("416813ac-ccf2-4a6d-84b0-6bffa82f9cb6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 21, 19, 15, 0, 0, DateTimeKind.Utc), null, null, 18.97m, 1.23m, "C", 15.42m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9d6adf2c-1909-4660-9138-ba9b54762a2f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 4, 17, 23, 0, 0, DateTimeKind.Utc), null, null, 57.06m, 0.65m, "P", 87.78m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e8daf5f1-6b23-438f-bbd4-12a82465cc95"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 26, 18, 32, 0, 0, DateTimeKind.Utc), null, null, 189.07m, 4.06m, "SF", 46.57m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f311802f-8b22-4785-8107-263036db8505"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 17, 20, 59, 0, 0, DateTimeKind.Utc), null, null, 219.24m, 4.35m, "KZB", 50.4m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d190dcbb-ea99-4348-b70e-4790426bcc0e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 30, 20, 4, 0, 0, DateTimeKind.Utc), null, null, 28.38m, 1.18m, "FG", 24.05m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5eebd8be-b63a-4dd0-8c70-0b7bda54d3cc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 25, 17, 37, 0, 0, DateTimeKind.Utc), null, null, 301.83m, 3.05m, "I", 98.96m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3656d619-2d11-4f48-afca-f810188e8ed1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 22, 19, 45, 0, 0, DateTimeKind.Utc), null, null, 67.25m, 4.60m, "WC", 14.62m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5e66beaa-bfcd-4035-a4c0-beb2d7dfc719"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 19, 15, 8, 0, 0, DateTimeKind.Utc), null, null, 286.67m, 3.71m, "TGN", 77.27m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("35ed450f-9c6c-4036-9e92-abb90361fc48"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 22, 19, 2, 0, 0, DateTimeKind.Utc), null, null, 187.54m, 3.75m, "DY", 50.01m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fa4ade2e-b842-4a05-b359-a7df1c4ae2b6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 13, 20, 51, 0, 0, DateTimeKind.Utc), null, null, 12.47m, 0.23m, "DHV", 54.23m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("47d50f00-a8c2-4734-b777-835e16557005"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 27, 20, 11, 0, 0, DateTimeKind.Utc), null, null, 145.49m, 2.83m, "AAH", 51.41m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0ca4f3cf-8a3e-45e0-b409-2a01d07b0248"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 1, 17, 34, 0, 0, DateTimeKind.Utc), null, null, 71.86m, 2.90m, "U", 24.78m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ab2ca6a2-ea56-4a01-9bcc-ab46df12553d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 25, 20, 48, 0, 0, DateTimeKind.Utc), null, null, 64.90m, 1.68m, "UWW", 38.63m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6f9a06f5-824e-4a41-beb8-f080400c887d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 29, 15, 31, 0, 0, DateTimeKind.Utc), null, null, 72.32m, 4.88m, "Q", 14.82m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("45394df0-c4d4-48f3-8316-b37a50f7356e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 30, 17, 40, 0, 0, DateTimeKind.Utc), null, null, 486.34m, 4.93m, "X", 98.65m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("485fd6c8-3449-4570-a699-09ca1ae672b9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 7, 18, 41, 0, 0, DateTimeKind.Utc), null, null, 56.18m, 2.15m, "WA", 26.13m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ef219cd5-9a14-42b5-ac48-9c6cbfd81231"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 8, 18, 1, 0, 0, DateTimeKind.Utc), null, null, 77.95m, 4.29m, "WW", 18.17m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("16050193-7090-4c4e-8536-8637a845bc21"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 9, 19, 0, 0, 0, DateTimeKind.Utc), null, null, 336.41m, 3.85m, "D", 87.38m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5b62ed57-bffb-4839-ac0e-1e4fa291461e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 15, 17, 30, 0, 0, DateTimeKind.Utc), null, null, 50.92m, 2.93m, "KUT", 17.38m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2c33e291-f208-42f6-8790-03d03c657398"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 24, 17, 43, 0, 0, DateTimeKind.Utc), null, null, 289.84m, 3.49m, "HI", 83.05m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("298df2e9-f7a2-4788-9db6-624119fd55db"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 2, 14, 45, 0, 0, DateTimeKind.Utc), null, null, 23.12m, 1.86m, "TDF", 12.43m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9fce838f-ece7-4348-bf78-f7313f369f3e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 18, 20, 27, 0, 0, DateTimeKind.Utc), null, null, 410.69m, 4.37m, "Y", 93.98m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("866a39e3-db40-479b-9c3e-dcec83f5dd59"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 12, 16, 23, 0, 0, DateTimeKind.Utc), null, null, 93.46m, 3.49m, "AWQ", 26.78m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5e46ec33-500c-4329-a833-4b816307c7ea"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 11, 19, 4, 0, 0, DateTimeKind.Utc), null, null, 131.70m, 3.33m, "BQF", 39.55m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1e86c2dc-2a99-4ebf-a13f-3bafab2d8f62"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 28, 16, 15, 0, 0, DateTimeKind.Utc), null, null, 392.14m, 4.66m, "CES", 84.15m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("05140f7c-984f-4207-a6be-8e2df1fc57b9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 19, 15, 48, 0, 0, DateTimeKind.Utc), null, null, 139.29m, 2.33m, "IHV", 59.78m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b9868e7b-e79b-4284-973d-15af85e4025a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 14, 19, 3, 0, 0, DateTimeKind.Utc), null, null, 129.82m, 1.89m, "GB", 68.69m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e462fb07-9ab6-47f2-a8cd-34e97033a4a5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 3, 19, 47, 0, 0, DateTimeKind.Utc), null, null, 65.68m, 0.71m, "RJF", 92.51m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("15f639e4-e0be-4047-930f-749f05c8bfd6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 4, 18, 58, 0, 0, DateTimeKind.Utc), null, null, 324.22m, 3.76m, "S", 86.23m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("17ee5812-1652-4e8a-a7d5-91294bd66956"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 23, 17, 5, 0, 0, DateTimeKind.Utc), null, null, 16.43m, 0.39m, "IHY", 42.12m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("35726eb8-f131-4f18-9c74-a7b00d18f4d9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 11, 17, 11, 0, 0, DateTimeKind.Utc), null, null, 291.47m, 4.68m, "L", 62.28m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("19b4bf39-9187-4627-a3af-ba4c29ca466c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 18, 18, 17, 0, 0, DateTimeKind.Utc), null, null, 87.96m, 0.89m, "I", 98.83m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("75ab2c4b-e7bd-4820-b69c-e61e09f49b1f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 25, 19, 2, 0, 0, DateTimeKind.Utc), null, null, 87.02m, 4.20m, "O", 20.72m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b34e9680-ed4e-4b5c-af78-1e4cb8e803dd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 8, 18, 56, 0, 0, DateTimeKind.Utc), null, null, 29.65m, 1.62m, "RIB", 18.3m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0c48386e-bcbb-4afe-8f84-8a04c897b1a6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 17, 19, 42, 0, 0, DateTimeKind.Utc), null, null, 196.08m, 3.77m, "M", 52.01m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b4164811-6da7-440b-8772-3afc32a8d848"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 15, 15, 30, 0, 0, DateTimeKind.Utc), null, null, 168.83m, 3.63m, "HN", 46.51m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f201b8e2-534c-46d8-8855-74bf6b378b07"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 13, 20, 24, 0, 0, DateTimeKind.Utc), null, null, 45.95m, 2.07m, "YDN", 22.2m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("761ee44c-5421-4b80-a2c0-be397b10f637"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 1, 16, 3, 0, 0, DateTimeKind.Utc), null, null, 185.59m, 4.47m, "GVM", 41.52m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f59ab107-1b9c-4f91-b1d1-8aad94da7997"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 24, 20, 30, 0, 0, DateTimeKind.Utc), null, null, 89.62m, 0.95m, "X", 94.34m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("20f89af9-6c84-41bd-95a2-c46c48144892"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 14, 18, 21, 0, 0, DateTimeKind.Utc), null, null, 88.51m, 0.92m, "OIL", 96.21m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4257d01c-5a95-4135-8fab-063f570a12a4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 5, 18, 59, 0, 0, DateTimeKind.Utc), null, null, 122.60m, 2.95m, "E", 41.56m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("796488c4-b819-453b-bf38-d0826b4c303e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 1, 20, 15, 0, 0, DateTimeKind.Utc), null, null, 298.85m, 4.34m, "ONB", 68.86m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f170638d-eed0-40ec-b45c-3838bc76027e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 13, 17, 56, 0, 0, DateTimeKind.Utc), null, null, 323.43m, 3.81m, "NH", 84.89m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("592f4bec-1f32-4e3b-b785-72d1e572d843"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 21, 19, 59, 0, 0, DateTimeKind.Utc), null, null, 98.49m, 3.96m, "L", 24.87m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("649699fc-ef4f-4cf8-9243-f0d6b00ce26d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 14, 16, 23, 0, 0, DateTimeKind.Utc), null, null, 218.19m, 3.08m, "IB", 70.84m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("84474e69-852e-47fc-a420-88b0df49d6eb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 25, 14, 37, 0, 0, DateTimeKind.Utc), null, null, 12.65m, 3.02m, "Z", 4.19m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dbec954b-b61e-4256-9744-aab06c06971c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 2, 15, 2, 0, 0, DateTimeKind.Utc), null, null, 83.63m, 0.93m, "SXR", 89.92m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("742def39-18bc-4aee-ae51-9a2fb16e021e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 28, 18, 20, 0, 0, DateTimeKind.Utc), null, null, 11.21m, 3.23m, "K", 3.47m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("536f583b-f336-49c2-a75d-0a8ddfae486e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 24, 20, 1, 0, 0, DateTimeKind.Utc), null, null, 219.36m, 3.46m, "L", 63.4m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cf3badd0-c7a2-4bd9-979c-a7d308d84408"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 25, 18, 10, 0, 0, DateTimeKind.Utc), null, null, 43.64m, 2.75m, "C", 15.87m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a99bcaf4-6c2d-4066-a00d-91af48d92013"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 7, 15, 55, 0, 0, DateTimeKind.Utc), null, null, 199.01m, 3.68m, "QJ", 54.08m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("74f23d10-49a9-47e6-89a3-5cce6e0fe07b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 9, 15, 7, 0, 0, DateTimeKind.Utc), null, null, 155.63m, 1.60m, "H", 97.27m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ef60e7ea-2d39-4c2e-9ceb-fcf893734150"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 20, 17, 55, 0, 0, DateTimeKind.Utc), null, null, 32.40m, 1.11m, "H", 29.19m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("22a8422a-9d9c-4e15-8fae-16ec241465cc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 27, 16, 27, 0, 0, DateTimeKind.Utc), null, null, 23.91m, 2.48m, "A", 9.64m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7e9e679f-10be-49cd-b9c1-501e5fee4835"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 10, 16, 1, 0, 0, DateTimeKind.Utc), null, null, 332.74m, 3.84m, "Y", 86.65m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f94e77bf-4de9-449d-bf98-d2ce609494fb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 22, 15, 2, 0, 0, DateTimeKind.Utc), null, null, 254.85m, 3.23m, "ZI", 78.9m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("25daae7b-89a5-4b8a-a70a-d9fb17fe8644"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 16, 20, 42, 0, 0, DateTimeKind.Utc), null, null, 11.65m, 0.28m, "EIT", 41.59m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5652447c-3f9d-4ad1-9bb6-8cbd1db58de3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 5, 19, 1, 0, 0, DateTimeKind.Utc), null, null, 71.72m, 1.84m, "NK", 38.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("470a1aeb-296c-4a8b-9e43-be8cecd31855"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 3, 16, 53, 0, 0, DateTimeKind.Utc), null, null, 92.95m, 1.15m, "RQ", 80.83m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("282641ba-a8da-4336-9df9-ca769f05abfc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 13, 19, 36, 0, 0, DateTimeKind.Utc), null, null, 171.86m, 2.60m, "YB", 66.1m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("70c64928-f6a8-4b64-92fd-62eef5374fa4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 22, 19, 39, 0, 0, DateTimeKind.Utc), null, null, 414.90m, 4.58m, "EOC", 90.59m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("38b1abd6-6d95-4308-a790-d69a98c72e40"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 15, 31, 0, 0, DateTimeKind.Utc), null, null, 132.59m, 1.43m, "TPZ", 92.72m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a7d1e3b6-b9a1-4080-b751-9ff462d704ed"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 25, 16, 17, 0, 0, DateTimeKind.Utc), null, null, 215.87m, 2.64m, "H", 81.77m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fd241f66-afb8-4b4b-ad25-448373c4c171"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 17, 42, 0, 0, DateTimeKind.Utc), null, null, 19.09m, 0.24m, "ME", 79.53m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("765e8e8f-07a1-4259-91c4-274a3cc8a5d8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 28, 17, 28, 0, 0, DateTimeKind.Utc), null, null, 80.77m, 2.26m, "BF", 35.74m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5c5f606f-efeb-49a0-86a2-4dc80c058e59"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 25, 19, 30, 0, 0, DateTimeKind.Utc), null, null, 231.41m, 2.82m, "FWL", 82.06m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8a7827c7-eac4-45e7-a38c-ce29138911fe"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 22, 19, 40, 0, 0, DateTimeKind.Utc), null, null, 28.68m, 0.56m, "JG", 51.21m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9f869852-a330-4eb9-9b5e-e8aedd1913e1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 26, 18, 26, 0, 0, DateTimeKind.Utc), null, null, 136.27m, 1.85m, "K", 73.66m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("db9e487c-7902-4278-9319-c93f5ae96aaa"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 20, 20, 19, 0, 0, DateTimeKind.Utc), null, null, 170.36m, 2.41m, "I", 70.69m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d185764c-a557-497a-bac2-1bf9c6eba1dd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 11, 19, 52, 0, 0, DateTimeKind.Utc), null, null, 13.89m, 2.17m, "NKQ", 6.4m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d5fa6487-49d9-4882-8af4-89a6f89eba4b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 7, 15, 24, 0, 0, DateTimeKind.Utc), null, null, 214.91m, 3.42m, "I", 62.84m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2185e52d-f124-4c48-9649-199540bf8c7d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 17, 20, 39, 0, 0, DateTimeKind.Utc), null, null, 1.42m, 0.10m, "TT", 14.23m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1fc5bccf-ae1a-45eb-97bf-a1e36c0b0a5d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 27, 19, 53, 0, 0, DateTimeKind.Utc), null, null, 51.71m, 1.61m, "OYM", 32.12m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dd2578d6-3f5c-47e3-9fe1-c798dc6076fd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 22, 18, 6, 0, 0, DateTimeKind.Utc), null, null, 479.46m, 4.97m, "HC", 96.47m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("03182b1c-1284-4b78-8d2c-dd8c8bd3d9dc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 24, 17, 41, 0, 0, DateTimeKind.Utc), null, null, 36.97m, 1.39m, "QN", 26.6m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("22ffb732-87c2-4849-a5df-0817ea357f3c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 14, 20, 59, 0, 0, DateTimeKind.Utc), null, null, 201.63m, 2.97m, "S", 67.89m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("55cab621-e970-42bd-9467-8e8e4e22e1bc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 16, 5, 0, 0, DateTimeKind.Utc), null, null, 132.45m, 4.13m, "TMM", 32.07m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("54d82e06-0266-4968-bf8d-e82caec5df91"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 5, 15, 8, 0, 0, DateTimeKind.Utc), null, null, 147.42m, 3.13m, "K", 47.1m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d5688b99-3c12-474f-95a6-9932629cca11"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 22, 18, 11, 0, 0, DateTimeKind.Utc), null, null, 267.31m, 3.42m, "QK", 78.16m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("eaf7520a-346d-40f2-a79a-c67f3739ca10"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 30, 17, 44, 0, 0, DateTimeKind.Utc), null, null, 76.54m, 1.29m, "Q", 59.33m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b84da7af-0ee2-4177-8caf-ccdda15c6f78"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 18, 17, 27, 0, 0, DateTimeKind.Utc), null, null, 94.27m, 3.59m, "SE", 26.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3d98791f-327a-43bb-abca-eede57f412db"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 21, 14, 52, 0, 0, DateTimeKind.Utc), null, null, 183.66m, 2.60m, "RRS", 70.64m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b5300727-0445-4f60-8136-bdb11868a54c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 21, 18, 16, 0, 0, DateTimeKind.Utc), null, null, 314.12m, 3.15m, "JV", 99.72m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b37f3acb-bd5c-48a1-88f0-8e5288bf55fb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 14, 17, 33, 0, 0, DateTimeKind.Utc), null, null, 115.91m, 3.94m, "DR", 29.42m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5506b54f-6542-401b-8f79-5111f2bee6ac"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 8, 18, 35, 0, 0, DateTimeKind.Utc), null, null, 79.65m, 3.57m, "NAY", 22.31m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5c708282-fb40-49e5-b09a-f6d2eb98ab7b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 7, 20, 11, 0, 0, DateTimeKind.Utc), null, null, 94.29m, 1.31m, "IY", 71.98m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6f472f9e-4bce-4614-9d93-dff627b108a5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 2, 19, 4, 0, 0, DateTimeKind.Utc), null, null, 167.19m, 1.98m, "PU", 84.44m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6c16ab52-4296-4630-ab78-a69bf349770f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 2, 20, 52, 0, 0, DateTimeKind.Utc), null, null, 23.97m, 1.09m, "VSK", 21.99m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c03f2644-385f-45cb-acbb-32394de10be2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 7, 20, 29, 0, 0, DateTimeKind.Utc), null, null, 47.42m, 1.22m, "TPQ", 38.87m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("11bb7b2a-776e-46db-accb-4316c6f43b1c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 15, 19, 14, 0, 0, DateTimeKind.Utc), null, null, 174.84m, 1.99m, "JY", 87.86m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("47d8a0d1-fe2d-49cd-885b-1a3eec0ea6af"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 19, 20, 17, 0, 0, DateTimeKind.Utc), null, null, 37.03m, 2.55m, "ZA", 14.52m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d03506c4-f5ed-4b31-91b0-4cd30deef45f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 15, 14, 0, 0, DateTimeKind.Utc), null, null, 9.22m, 0.54m, "AN", 17.08m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("857e2453-22de-4b87-aacf-e0769aef1500"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 5, 18, 17, 0, 0, DateTimeKind.Utc), null, null, 52.06m, 2.00m, "LDD", 26.03m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("47aa441e-3a6c-4887-9d75-753ac217df68"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 28, 18, 31, 0, 0, DateTimeKind.Utc), null, null, 1.94m, 1.00m, "A", 1.94m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ce1b6bb7-ea21-415c-92d8-53cadcfb588f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 18, 17, 27, 0, 0, DateTimeKind.Utc), null, null, 254.35m, 4.74m, "ASG", 53.66m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("936ec18e-e034-46bb-90a5-7ee8e58d8e5f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 25, 19, 7, 0, 0, DateTimeKind.Utc), null, null, 5.61m, 2.27m, "OOW", 2.47m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5c08e057-beab-4d15-95c3-38e0d41bfb9e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 13, 16, 51, 0, 0, DateTimeKind.Utc), null, null, 117.30m, 1.83m, "RL", 64.1m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fb7d1640-2f2d-408c-81b6-d839f95751aa"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 5, 15, 59, 0, 0, DateTimeKind.Utc), null, null, 59.23m, 2.68m, "E", 22.1m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1868dff3-911e-4191-9440-e32eb9ce9cdd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 26, 15, 48, 0, 0, DateTimeKind.Utc), null, null, 23.56m, 3.94m, "LV", 5.98m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("43fb8d22-75c4-46b4-9f03-8440585018f0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 18, 16, 30, 0, 0, DateTimeKind.Utc), null, null, 26.72m, 0.94m, "QZJ", 28.43m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("78de253c-40ec-466a-8890-3f61c10a133d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 26, 20, 3, 0, 0, DateTimeKind.Utc), null, null, 76.31m, 1.23m, "P", 62.04m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("16b82871-4739-47db-89ab-db182ac5bae3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 24, 18, 7, 0, 0, DateTimeKind.Utc), null, null, 23.34m, 0.32m, "F", 72.93m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("940ed89c-1448-461c-87f3-fe6df3037e4d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 6, 16, 9, 0, 0, DateTimeKind.Utc), null, null, 5.17m, 0.09m, "JKY", 57.4m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cb8dced3-27e6-442a-a62d-a47b526861e7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 23, 16, 59, 0, 0, DateTimeKind.Utc), null, null, 167.93m, 4.17m, "P", 40.27m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("660ed35c-059d-4789-a064-a154fe38ab0a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 27, 15, 35, 0, 0, DateTimeKind.Utc), null, null, 47.97m, 2.61m, "HF", 18.38m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0456e874-b8bd-4ff9-bc88-b47cdc08b446"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 6, 16, 22, 0, 0, DateTimeKind.Utc), null, null, 48.45m, 1.30m, "TWL", 37.27m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b2410f7a-8a0b-469d-8c29-b1a583504bfa"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 5, 14, 55, 0, 0, DateTimeKind.Utc), null, null, 26.48m, 1.45m, "QKX", 18.26m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d2d762e3-f51d-461b-b21c-3e20feffd082"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 24, 19, 41, 0, 0, DateTimeKind.Utc), null, null, 74.00m, 2.19m, "HQA", 33.79m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c0c43ce9-e29d-4696-9ee2-d13ca194a192"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 29, 14, 55, 0, 0, DateTimeKind.Utc), null, null, 5.99m, 0.55m, "PYC", 10.89m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e50e7a1f-0e4b-4e04-9eae-b1f46b65bda8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 20, 16, 31, 0, 0, DateTimeKind.Utc), null, null, 123.06m, 1.90m, "OLA", 64.77m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("55e64452-d173-46eb-8046-ad9dc468807e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 30, 15, 41, 0, 0, DateTimeKind.Utc), null, null, 241.73m, 2.65m, "HK", 91.22m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("77b7649b-79a0-453b-bbce-f6578dd90660"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 27, 20, 52, 0, 0, DateTimeKind.Utc), null, null, 3.45m, 0.97m, "UP", 3.56m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e355cb7a-1544-4eac-a7cd-8a86a8da8ebc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 25, 19, 16, 0, 0, DateTimeKind.Utc), null, null, 219.17m, 3.34m, "NFH", 65.62m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6b92fbb2-c0f8-41f5-9cac-c34e34d87a67"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 18, 15, 24, 0, 0, DateTimeKind.Utc), null, null, 45.03m, 1.33m, "WZ", 33.86m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2d2fa608-0d8c-4e5a-9ad4-d74bd04c156b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 13, 17, 56, 0, 0, DateTimeKind.Utc), null, null, 10.28m, 0.27m, "RBR", 38.09m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e104b5bb-4257-4621-8225-bad376fcc5d5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 19, 20, 0, 0, 0, DateTimeKind.Utc), null, null, 86.35m, 2.99m, "T", 28.88m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d1ef1228-84fd-4c6f-b9b7-a0a52c419abd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 6, 15, 43, 0, 0, DateTimeKind.Utc), null, null, 85.31m, 3.99m, "TFL", 21.38m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("01fb3e88-fb31-41b5-b129-7a970603fa8f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 22, 20, 4, 0, 0, DateTimeKind.Utc), null, null, 318.96m, 4.43m, "M", 72m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("97f6c8ca-2610-4382-bcfe-666b35f1ac2e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 24, 19, 12, 0, 0, DateTimeKind.Utc), null, null, 42.01m, 3.14m, "KO", 13.38m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("685c503a-46c3-426b-b041-22ba56c0ba77"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 6, 16, 9, 0, 0, DateTimeKind.Utc), null, null, 30.30m, 2.78m, "B", 10.9m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e421b0f2-5f16-42c7-98fa-fed943ebf2c3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 1, 19, 0, 0, 0, DateTimeKind.Utc), null, null, 40.02m, 3.10m, "C", 12.91m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1eb1e2d0-c3f3-4f4c-837e-fb881a2f3c03"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 5, 17, 53, 0, 0, DateTimeKind.Utc), null, null, 14.48m, 0.30m, "Q", 48.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6aa5677b-99f6-4752-a697-fff9f540e53b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 7, 15, 26, 0, 0, DateTimeKind.Utc), null, null, 26.08m, 0.36m, "HOK", 72.44m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ef60e104-b6e5-44c6-8322-072bfff2705c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 13, 15, 53, 0, 0, DateTimeKind.Utc), null, null, 77.95m, 3.17m, "EV", 24.59m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b83e73b5-adbc-48e8-b5a4-c4b71602497c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 17, 19, 19, 0, 0, DateTimeKind.Utc), null, null, 45.85m, 3.98m, "XQF", 11.52m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("25ea2f47-9478-4c4e-b76c-9a41bcb9636e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 29, 15, 38, 0, 0, DateTimeKind.Utc), null, null, 14.18m, 0.67m, "VZO", 21.17m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("aec80208-121e-4274-b0c3-957f2880395c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 27, 19, 44, 0, 0, DateTimeKind.Utc), null, null, 241.13m, 4.53m, "CCN", 53.23m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9e16b449-5be7-47d0-81c3-2c475b95b5bb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 29, 16, 42, 0, 0, DateTimeKind.Utc), null, null, 39.41m, 1.18m, "H", 33.4m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("767dddc7-5ad8-4498-a718-0bebbde37990"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 13, 15, 32, 0, 0, DateTimeKind.Utc), null, null, 77.68m, 1.00m, "YY", 77.68m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3daab304-f940-4fbf-a4aa-479307f904f1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 29, 20, 24, 0, 0, DateTimeKind.Utc), null, null, 164.06m, 4.94m, "D", 33.21m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8ffc4a73-0926-4e94-baff-4a48c780e22c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 6, 16, 0, 0, 0, DateTimeKind.Utc), null, null, 135.12m, 1.97m, "VI", 68.59m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("696a0d1c-503a-4d4d-a0ba-e97cf812d028"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 21, 18, 58, 0, 0, DateTimeKind.Utc), null, null, 413.58m, 4.75m, "A", 87.07m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3069c7d2-d7d3-4d76-99d4-6a904b9c2b77"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 7, 16, 44, 0, 0, DateTimeKind.Utc), null, null, 212.20m, 3.11m, "BO", 68.23m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("18be7f03-732d-413d-a9d4-3f6a1a50107f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 28, 20, 23, 0, 0, DateTimeKind.Utc), null, null, 194.21m, 2.57m, "PUJ", 75.57m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6a03aa0a-be17-45be-92a4-690059b277b7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 20, 20, 57, 0, 0, DateTimeKind.Utc), null, null, 374.13m, 4.83m, "VAP", 77.46m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("91061dce-eb8f-4874-a84e-b805c3dc36e4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 5, 20, 12, 0, 0, DateTimeKind.Utc), null, null, 91.84m, 1.94m, "M", 47.34m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6720342d-37ac-462f-a3e5-e568dd70f202"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 20, 17, 38, 0, 0, DateTimeKind.Utc), null, null, 20.60m, 1.26m, "V", 16.35m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("926c3307-435a-4e2c-9e48-e81b1a0664f5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 7, 15, 49, 0, 0, DateTimeKind.Utc), null, null, 317.48m, 3.98m, "T", 79.77m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("13ca1c64-2bef-476a-86f8-410500e184d6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 13, 19, 36, 0, 0, DateTimeKind.Utc), null, null, 117.80m, 3.31m, "Y", 35.59m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d1d5359f-b096-484a-9379-f07d542ca02c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 5, 16, 15, 0, 0, DateTimeKind.Utc), null, null, 215.56m, 2.94m, "TU", 73.32m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a7253b37-f0cd-45a7-bab5-32c66ebfcaa6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 30, 19, 25, 0, 0, DateTimeKind.Utc), null, null, 281.10m, 3.74m, "ZYO", 75.16m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ee683c33-be3e-4e59-936b-352b20d6d064"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 25, 20, 18, 0, 0, DateTimeKind.Utc), null, null, 35.97m, 4.43m, "AZE", 8.12m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("43510703-5078-4d23-b8cd-2384efa1e1c2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 30, 17, 49, 0, 0, DateTimeKind.Utc), null, null, 104.98m, 3.38m, "SV", 31.06m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9b611415-c39e-4520-bfa0-49a0c0bee245"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 11, 14, 41, 0, 0, DateTimeKind.Utc), null, null, 59.50m, 0.75m, "A", 79.34m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1535300a-3f70-42e1-b4cf-ba8bc6479d6d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 8, 17, 44, 0, 0, DateTimeKind.Utc), null, null, 62.73m, 3.96m, "T", 15.84m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("09b3d68e-575b-4782-86d2-607d0a878d49"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 28, 16, 34, 0, 0, DateTimeKind.Utc), null, null, 82.94m, 0.87m, "M", 95.33m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f02a31a7-d0e4-4454-8f42-e17a1ac11840"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 2, 15, 56, 0, 0, DateTimeKind.Utc), null, null, 91.41m, 1.49m, "P", 61.35m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("60195d39-60c9-45bc-b588-c22331bf973c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 25, 19, 1, 0, 0, DateTimeKind.Utc), null, null, 90.54m, 3.03m, "IX", 29.88m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("05d8dfc3-0f35-4228-9c4e-9782d98d4531"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 4, 19, 58, 0, 0, DateTimeKind.Utc), null, null, 8.83m, 1.08m, "PNH", 8.18m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a857e698-b7aa-4504-9c26-5c2bc4206a9c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 21, 16, 55, 0, 0, DateTimeKind.Utc), null, null, 122.89m, 2.84m, "M", 43.27m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e2a62382-3ec3-419e-a261-34461c973901"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 23, 16, 15, 0, 0, DateTimeKind.Utc), null, null, 333.56m, 3.88m, "GGT", 85.97m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d2d28ea3-7729-452a-b744-8cff36c74d80"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 15, 16, 44, 0, 0, DateTimeKind.Utc), null, null, 90.56m, 3.73m, "BHY", 24.28m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1d83d6de-61ed-4bfb-a985-74f9fa606155"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 6, 18, 16, 0, 0, DateTimeKind.Utc), null, null, 29.86m, 0.63m, "KC", 47.4m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2a948753-f52d-48a4-bdd1-31c2d137af04"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 5, 19, 34, 0, 0, DateTimeKind.Utc), null, null, 375.73m, 4.26m, "AP", 88.2m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("62c41d46-5bc9-42ee-8097-bb563084984a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 27, 16, 53, 0, 0, DateTimeKind.Utc), null, null, 8.69m, 1.60m, "YW", 5.43m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4ac18ad8-8e86-4f98-98a5-44ba04a18ed0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 7, 16, 30, 0, 0, DateTimeKind.Utc), null, null, 51.58m, 1.20m, "F", 42.98m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dc9ff86d-da3b-4394-a30d-e0413025c1f2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 15, 19, 6, 0, 0, DateTimeKind.Utc), null, null, 241.21m, 3.14m, "BWQ", 76.82m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("03d15447-a505-45a5-80d9-9c826107edc3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 11, 14, 59, 0, 0, DateTimeKind.Utc), null, null, 37.35m, 4.42m, "L", 8.45m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bffa3869-3d69-44fa-a796-87ab4855abda"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 7, 18, 44, 0, 0, DateTimeKind.Utc), null, null, 227.61m, 3.13m, "QWC", 72.72m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4c1c56f3-93f8-4dc1-b8a4-f3227692fa6d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 25, 19, 36, 0, 0, DateTimeKind.Utc), null, null, 24.27m, 1.85m, "E", 13.12m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9910808f-07d8-4675-838f-a61d81a171fc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 29, 19, 34, 0, 0, DateTimeKind.Utc), null, null, 195.82m, 2.50m, "OX", 78.33m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("428a30c1-b809-4e72-a57a-0db6a98ee7b5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 17, 18, 25, 0, 0, DateTimeKind.Utc), null, null, 177.94m, 2.95m, "K", 60.32m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("00dfbfb7-3582-4907-b124-73c497882553"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 9, 18, 40, 0, 0, DateTimeKind.Utc), null, null, 145.75m, 1.86m, "ZO", 78.36m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7fcb1a1b-eab7-4f73-b5fe-c1c20e155070"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 2, 20, 40, 0, 0, DateTimeKind.Utc), null, null, 100.26m, 1.16m, "L", 86.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a8409a5b-cc6f-4e6a-823a-012e0c182d6f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 17, 17, 11, 0, 0, DateTimeKind.Utc), null, null, 193.39m, 1.96m, "CRY", 98.67m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7021b4f0-4016-4277-8fbf-6e212777ad75"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 30, 16, 32, 0, 0, DateTimeKind.Utc), null, null, 13.22m, 3.90m, "GBI", 3.39m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("00b89798-e2e2-44f8-9f94-51ae153a43f1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 8, 19, 16, 0, 0, DateTimeKind.Utc), null, null, 119.49m, 3.06m, "OTJ", 39.05m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ff0dbf88-3771-490a-9e8e-11d7f62b6a6f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 14, 16, 21, 0, 0, DateTimeKind.Utc), null, null, 0.64m, 0.38m, "LZ", 1.68m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("85d652ce-8f8d-4fc4-9dd7-884187de2890"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 6, 20, 23, 0, 0, DateTimeKind.Utc), null, null, 121.45m, 4.07m, "DLP", 29.84m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6889035d-e827-4fb0-bd85-22b82922385a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 6, 14, 33, 0, 0, DateTimeKind.Utc), null, null, 101.16m, 1.35m, "WSW", 74.93m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f4cb8d4e-e178-4e12-abf6-bd66d76ffa91"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 11, 20, 22, 0, 0, DateTimeKind.Utc), null, null, 71.97m, 1.37m, "AP", 52.53m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9fcd9f45-4d73-4134-9725-92d92df44711"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 18, 20, 12, 0, 0, DateTimeKind.Utc), null, null, 58.21m, 1.93m, "WW", 30.16m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("72344c31-9202-4d0f-a7af-ada2eda0033d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 4, 17, 31, 0, 0, DateTimeKind.Utc), null, null, 160.39m, 4.89m, "IK", 32.8m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6fba1a0a-4410-4422-9b44-f722f84b7139"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 18, 18, 33, 0, 0, DateTimeKind.Utc), null, null, 245.71m, 3.23m, "DQD", 76.07m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9977293b-f228-4939-a193-1ced2845edc9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 21, 16, 19, 0, 0, DateTimeKind.Utc), null, null, 61.82m, 0.73m, "L", 84.68m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2e96c68f-b61d-4d1d-9a1b-23bf352d4662"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 7, 14, 44, 0, 0, DateTimeKind.Utc), null, null, 83.59m, 1.07m, "VI", 78.12m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1ae27ce1-e5d7-4095-8c3f-1d8d0911f397"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 2, 19, 11, 0, 0, DateTimeKind.Utc), null, null, 298.17m, 3.65m, "XMH", 81.69m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ce9cf84a-291a-47a3-806a-2d07bd6dd62f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 24, 14, 45, 0, 0, DateTimeKind.Utc), null, null, 17.99m, 2.21m, "SR", 8.14m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("61b895ba-1ba5-4d8c-a762-ada5d5872ce8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 5, 20, 8, 0, 0, DateTimeKind.Utc), null, null, 8.00m, 0.62m, "W", 12.9m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0ce57214-e55d-4203-b476-7e4862998425"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 13, 17, 31, 0, 0, DateTimeKind.Utc), null, null, 168.47m, 2.53m, "A", 66.59m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("57412b93-6a17-431c-80cc-3ab189f1a1f9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 12, 14, 50, 0, 0, DateTimeKind.Utc), null, null, 16.78m, 1.99m, "Y", 8.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7eff359e-d305-493d-8f97-17587c692882"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 2, 18, 30, 0, 0, DateTimeKind.Utc), null, null, 155.58m, 2.67m, "B", 58.27m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9a9784ff-946d-4ed4-9d42-4c36a30f4bed"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 2, 14, 55, 0, 0, DateTimeKind.Utc), null, null, 120.86m, 3.82m, "B", 31.64m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7d749f3e-09de-4488-b5af-2f832bd778e7"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 30, 16, 32, 0, 0, DateTimeKind.Utc), null, null, 75.94m, 0.80m, "IZ", 94.92m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("72137924-c0dd-468d-883a-e1c36ce6ed82"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 24, 20, 15, 0, 0, DateTimeKind.Utc), null, null, 251.20m, 3.05m, "V", 82.36m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c495dfc4-bfb5-4b54-833e-5c823c85e5de"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 12, 15, 35, 0, 0, DateTimeKind.Utc), null, null, 189.44m, 3.91m, "JM", 48.45m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9bcc9d45-68bf-4ed0-a13b-fb75e6f5c446"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 13, 17, 47, 0, 0, DateTimeKind.Utc), null, null, 59.49m, 1.00m, "CU", 59.49m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b53799e1-7bd3-4456-a03a-61420ee3fd9a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 16, 19, 17, 0, 0, DateTimeKind.Utc), null, null, 62.11m, 1.38m, "QB", 45.01m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c299d757-d3bc-4fec-aad1-31512c1e83a4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 19, 15, 54, 0, 0, DateTimeKind.Utc), null, null, 30.37m, 0.37m, "GZS", 82.09m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f46c8501-1f62-408d-b2ba-c47bcfba5874"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 27, 19, 4, 0, 0, DateTimeKind.Utc), null, null, 63.52m, 2.28m, "IIN", 27.86m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ad38dc59-538e-451b-a163-c877ecd64e36"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 30, 18, 19, 0, 0, DateTimeKind.Utc), null, null, 156.20m, 3.21m, "U", 48.66m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5a64420b-b5fe-4dc5-b76f-b4a75e5d5a3c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 22, 19, 4, 0, 0, DateTimeKind.Utc), null, null, 4.22m, 0.92m, "UOI", 4.59m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fe0c54cc-a430-4e55-a519-8d5cb22d18a4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 11, 15, 10, 0, 0, DateTimeKind.Utc), null, null, 250.81m, 3.50m, "OUW", 71.66m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("10e4aca5-70d4-4f28-8863-ef61345b4413"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 21, 16, 52, 0, 0, DateTimeKind.Utc), null, null, 171.30m, 1.82m, "U", 94.12m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ff2f7a81-e50a-45fc-ae0b-82abd03cc61c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 15, 20, 56, 0, 0, DateTimeKind.Utc), null, null, 253.77m, 4.18m, "FGT", 60.71m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c5bf78fe-b083-4687-b986-5d75cddd13a8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 5, 18, 34, 0, 0, DateTimeKind.Utc), null, null, 244.75m, 3.97m, "N", 61.65m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("32438f36-ccfd-4102-a1d5-994f0e4d26c1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 11, 20, 11, 0, 0, DateTimeKind.Utc), null, null, 294.88m, 4.06m, "KMX", 72.63m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("58db9071-ba9b-4fe1-bd3b-4aa915fcc9c0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 4, 19, 35, 0, 0, DateTimeKind.Utc), null, null, 286.33m, 4.28m, "HA", 66.9m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("59c6136e-bd63-4337-a381-d0b167311693"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 27, 19, 11, 0, 0, DateTimeKind.Utc), null, null, 80.91m, 4.13m, "E", 19.59m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a81e9599-7317-4f1f-b2c7-fd1f5643442c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 21, 15, 48, 0, 0, DateTimeKind.Utc), null, null, 43.68m, 1.41m, "UGG", 30.98m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("95d30fbd-cbfe-459f-9431-6b536e1d29a8"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 22, 20, 54, 0, 0, DateTimeKind.Utc), null, null, 35.26m, 0.70m, "GNX", 50.37m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3de7c032-ab59-4f83-a6b1-cef262aeb810"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 12, 20, 41, 0, 0, DateTimeKind.Utc), null, null, 31.26m, 1.76m, "IVC", 17.76m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("43ee5d41-8147-4d52-a816-c66574141d84"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 15, 18, 29, 0, 0, DateTimeKind.Utc), null, null, 109.55m, 1.35m, "R", 81.15m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("372c915d-f28d-47bd-9ad8-be231fc89683"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 31, 19, 1, 0, 0, DateTimeKind.Utc), null, null, 114.22m, 3.52m, "OX", 32.45m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ce61610f-77b2-45f2-9a31-b3034ceed74c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 17, 18, 0, 0, DateTimeKind.Utc), null, null, 16.34m, 0.27m, "H", 60.52m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1df846d6-9cf6-4fe2-a218-d8777fc79463"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 27, 16, 40, 0, 0, DateTimeKind.Utc), null, null, 89.11m, 2.24m, "SRH", 39.78m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("63ea6d91-491a-4ce0-85b7-a322ba97b1eb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 17, 21, 0, 0, DateTimeKind.Utc), null, null, 89.95m, 2.95m, "V", 30.49m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e0593eda-9e15-42eb-8e50-f57e409261b1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 2, 16, 52, 0, 0, DateTimeKind.Utc), null, null, 282.12m, 4.44m, "LN", 63.54m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("abc8ea41-0be7-4f64-8546-8913ebba91ec"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 13, 19, 45, 0, 0, DateTimeKind.Utc), null, null, 51.01m, 1.33m, "FMU", 38.35m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4176cb38-07d1-459c-97d8-6e7022e8c17c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 10, 20, 17, 0, 0, DateTimeKind.Utc), null, null, 79.87m, 1.13m, "GQW", 70.68m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9e527fca-33a1-4952-ae4a-dfe8ad53dcd5"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 27, 15, 21, 0, 0, DateTimeKind.Utc), null, null, 47.15m, 1.55m, "GO", 30.42m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8560e6ca-f10d-416b-bb09-c8f83698fb3e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 6, 20, 49, 0, 0, DateTimeKind.Utc), null, null, 27.43m, 0.71m, "Q", 38.63m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2632b964-5861-4098-8809-085e84ccbe83"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 27, 17, 5, 0, 0, DateTimeKind.Utc), null, null, 44.99m, 4.54m, "I", 9.91m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ec7fb5d7-7743-4542-a969-a9a9880507e0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 16, 43, 0, 0, DateTimeKind.Utc), null, null, 235.54m, 2.46m, "RI", 95.75m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f5a53f1a-aa6f-495d-8fdc-402f07adda40"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 26, 16, 10, 0, 0, DateTimeKind.Utc), null, null, 45.43m, 1.52m, "H", 29.89m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a7afa122-2b44-41cb-b243-995856e30e41"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 21, 15, 52, 0, 0, DateTimeKind.Utc), null, null, 336.21m, 4.16m, "GC", 80.82m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("396f0452-7855-4bf2-a66b-386a69b42901"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 12, 19, 31, 0, 0, DateTimeKind.Utc), null, null, 4.83m, 0.68m, "FS", 7.11m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9d9bcf62-a11d-4eb5-bf78-08c2ab61bafe"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 12, 15, 32, 0, 0, DateTimeKind.Utc), null, null, 31.37m, 2.15m, "V", 14.59m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("57a34cbd-7e2d-4c91-8b7f-7808e56db835"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 16, 15, 21, 0, 0, DateTimeKind.Utc), null, null, 177.70m, 4.54m, "LNM", 39.14m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9cf7d181-fa66-47b5-a9aa-8b2691bc0a13"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 27, 19, 30, 0, 0, DateTimeKind.Utc), null, null, 98.42m, 2.96m, "RR", 33.25m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c62994a2-d3f9-44ef-bbe0-e6e9e281b3a0"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 4, 15, 8, 0, 0, DateTimeKind.Utc), null, null, 11.31m, 0.77m, "HD", 14.69m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("47ae5741-121d-4ee5-9158-44daf687fb34"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 30, 15, 21, 0, 0, DateTimeKind.Utc), null, null, 172.76m, 3.93m, "Q", 43.96m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("32b4da4e-bf8a-415b-8817-158bcec31e8e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 8, 18, 1, 0, 0, DateTimeKind.Utc), null, null, 163.34m, 2.43m, "W", 67.22m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6cad7cd0-05cb-4e8f-85a7-86a6f6468239"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 1, 16, 33, 0, 0, DateTimeKind.Utc), null, null, 88.31m, 0.95m, "FJH", 92.96m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("45d55eed-2f36-4b00-981b-ef8a4ca534fa"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 15, 16, 33, 0, 0, DateTimeKind.Utc), null, null, 4.33m, 3.55m, "Y", 1.22m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("40fb9c36-25cb-42a9-9172-4b18a765e60e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 4, 17, 1, 0, 0, DateTimeKind.Utc), null, null, 1.62m, 0.06m, "S", 26.92m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1b500478-7d9e-4684-84f5-3c0754b01b6a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 25, 18, 42, 0, 0, DateTimeKind.Utc), null, null, 62.08m, 2.80m, "IY", 22.17m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("74702151-3c23-4364-a521-781ebb098a56"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 26, 15, 36, 0, 0, DateTimeKind.Utc), null, null, 178.61m, 2.56m, "Y", 69.77m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8db75179-0bec-4dc4-804c-731c6311f99f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 13, 20, 3, 0, 0, DateTimeKind.Utc), null, null, 29.18m, 2.31m, "K", 12.63m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("08d705b9-58af-4d26-9c8c-50964fed0415"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 8, 17, 48, 0, 0, DateTimeKind.Utc), null, null, 104.05m, 4.60m, "X", 22.62m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cd5096e6-d7b8-4ec9-9b8c-bc10d1b4cdac"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 30, 14, 52, 0, 0, DateTimeKind.Utc), null, null, 11.43m, 2.30m, "UMJ", 4.97m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("93917bc5-7962-49b6-b4a7-1fbd3277815b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 3, 15, 31, 0, 0, DateTimeKind.Utc), null, null, 160.20m, 2.35m, "SLA", 68.17m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d0bdf560-3aa8-45ef-a9d1-f2aa816215b9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 11, 20, 56, 0, 0, DateTimeKind.Utc), null, null, 334.77m, 4.83m, "WFE", 69.31m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f114e6da-f14c-4ae7-94c3-47301a6ddc03"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 1, 18, 42, 0, 0, DateTimeKind.Utc), null, null, 169.04m, 2.64m, "YHX", 64.03m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("58f1c03e-d123-4059-9708-5bdb26ce6615"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 18, 15, 9, 0, 0, DateTimeKind.Utc), null, null, 91.21m, 1.54m, "NJ", 59.23m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d3c5e249-d284-4e15-8057-8c1e952a93ad"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 4, 20, 37, 0, 0, DateTimeKind.Utc), null, null, 95.57m, 1.85m, "MH", 51.66m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("07443290-7c7b-4287-8b96-2d8283c822a1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 7, 15, 39, 0, 0, DateTimeKind.Utc), null, null, 29.05m, 0.74m, "VUG", 39.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("953b87d6-099e-4755-860b-ea5e98da823d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 4, 17, 4, 0, 0, DateTimeKind.Utc), null, null, 110.64m, 1.30m, "LV", 85.11m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("297c64be-7078-4fa0-aa5b-c8f53d32bada"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 7, 20, 53, 0, 0, DateTimeKind.Utc), null, null, 177.17m, 1.91m, "DOH", 92.76m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("984c3d7a-cb4c-4564-b0fb-53457d06833c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 14, 35, 0, 0, DateTimeKind.Utc), null, null, 42.53m, 1.96m, "YL", 21.7m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("55e6d916-91a9-4d05-8f55-8ab3610502d1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 10, 20, 4, 0, 0, DateTimeKind.Utc), null, null, 31.12m, 0.40m, "FD", 77.81m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f508042a-bc2d-467d-b371-984deb6b52bf"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 29, 20, 27, 0, 0, DateTimeKind.Utc), null, null, 37.49m, 4.40m, "LBJ", 8.52m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("00d92948-fffa-42d1-b3ff-82ba16e46796"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 4, 19, 56, 0, 0, DateTimeKind.Utc), null, null, 239.24m, 4.66m, "FEO", 51.34m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b6cbab48-a5fd-466b-b65d-131902ca363d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 16, 16, 44, 0, 0, DateTimeKind.Utc), null, null, 117.32m, 1.23m, "Q", 95.38m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("62044b08-24c9-42c0-80f9-6516485f606f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 20, 17, 47, 0, 0, DateTimeKind.Utc), null, null, 45.97m, 3.40m, "GRL", 13.52m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3ed3845f-96c6-4c0e-a3a8-4c8d95d3c670"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 17, 16, 9, 0, 0, DateTimeKind.Utc), null, null, 127.63m, 4.41m, "JZ", 28.94m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0a17674f-62ff-4415-816e-a33e2985a82a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 6, 18, 49, 0, 0, DateTimeKind.Utc), null, null, 96.26m, 1.94m, "ST", 49.62m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d7a3bc9b-eaaa-486f-8c15-2d7a8d3fb790"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 23, 20, 54, 0, 0, DateTimeKind.Utc), null, null, 101.99m, 1.13m, "EY", 90.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f3f557aa-aba3-46be-9295-4c38d7c08f4f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 28, 19, 0, 0, 0, DateTimeKind.Utc), null, null, 107.22m, 2.06m, "FHQ", 52.05m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("887c3003-abf4-4127-acc0-3a4ffb74eba6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 28, 17, 31, 0, 0, DateTimeKind.Utc), null, null, 11.09m, 1.53m, "Y", 7.25m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("43c40814-4832-4356-97f4-294ea086da6c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 13, 16, 14, 0, 0, DateTimeKind.Utc), null, null, 356.62m, 4.79m, "P", 74.45m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b08cd3ff-c5a6-4ba8-b4f6-ff9615c17195"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 14, 17, 13, 0, 0, DateTimeKind.Utc), null, null, 268.32m, 3.21m, "N", 83.59m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("156bb881-7c70-4168-ade9-8ae8a010afab"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 24, 15, 33, 0, 0, DateTimeKind.Utc), null, null, 24.97m, 3.65m, "CP", 6.84m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f826b75b-8ac2-4ab1-a7fc-d7aa04b4a876"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 30, 19, 54, 0, 0, DateTimeKind.Utc), null, null, 4.78m, 1.32m, "J", 3.62m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("91457078-ed4d-4960-808d-9cbdc68e556e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 8, 20, 8, 0, 0, DateTimeKind.Utc), null, null, 197.93m, 3.21m, "WO", 61.66m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c4c94371-8a0c-42f3-90eb-0df87fb1d26b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 23, 15, 19, 0, 0, DateTimeKind.Utc), null, null, 152.82m, 4.96m, "BXW", 30.81m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1873a274-dae9-49ec-9b94-b1b83cf1379e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 22, 18, 42, 0, 0, DateTimeKind.Utc), null, null, 40.96m, 1.63m, "ZQB", 25.13m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1fecf11a-9ac8-4553-95ca-db5c8b51f98f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 31, 19, 21, 0, 0, DateTimeKind.Utc), null, null, 9.70m, 1.83m, "JM", 5.3m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2c0af4bd-5ac8-4d2f-b07a-54411c05ab24"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 10, 18, 49, 0, 0, DateTimeKind.Utc), null, null, 121.85m, 2.30m, "H", 52.98m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cb2e4ea4-0c3e-475b-ae6e-b59180f1fbfe"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 10, 20, 55, 0, 0, DateTimeKind.Utc), null, null, 53.67m, 1.00m, "V", 53.67m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5707936c-3791-4650-815f-94b5ebd9be34"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 24, 19, 53, 0, 0, DateTimeKind.Utc), null, null, 29.78m, 0.36m, "H", 82.71m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d89d23a9-f0db-418f-a1f7-c6d53b0cb946"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 11, 19, 45, 0, 0, DateTimeKind.Utc), null, null, 44.77m, 1.71m, "XI", 26.18m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b389edab-4e61-409d-abde-7cfc7a156a1a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 8, 17, 54, 0, 0, DateTimeKind.Utc), null, null, 56.20m, 1.81m, "I", 31.05m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bd9e71ff-7929-4c4e-89f6-2efa380c1b91"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 6, 17, 20, 0, 0, DateTimeKind.Utc), null, null, 21.26m, 0.81m, "C", 26.25m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bc8165a9-df9a-4c1e-ae3b-b28d5f98f66a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 13, 18, 49, 0, 0, DateTimeKind.Utc), null, null, 161.76m, 2.47m, "J", 65.49m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3e4da32f-4620-4882-bda8-7d1d56c87f54"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 12, 20, 28, 0, 0, DateTimeKind.Utc), null, null, 175.75m, 3.60m, "XB", 48.82m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("27a76d63-4b55-4cc5-9241-1c13e90825a2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 15, 13, 0, 0, DateTimeKind.Utc), null, null, 52.21m, 1.63m, "P", 32.03m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e4ab1d4e-62c7-42fe-9fe3-72dc896b9044"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 7, 20, 7, 0, 0, DateTimeKind.Utc), null, null, 106.05m, 3.69m, "MN", 28.74m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4248c49c-fa8a-4434-8911-05211946b03b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 30, 16, 29, 0, 0, DateTimeKind.Utc), null, null, 163.99m, 1.73m, "XY", 94.79m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8dd30585-5496-4a2d-ac74-86d873cc3e69"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 17, 20, 43, 0, 0, DateTimeKind.Utc), null, null, 276.22m, 4.49m, "U", 61.52m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3b7ec57f-a859-4e99-be3c-111b23d746a4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 27, 14, 37, 0, 0, DateTimeKind.Utc), null, null, 7.06m, 1.63m, "EL", 4.33m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("65ee88b8-e6ea-483e-9ff3-7eaa8c2ba247"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 8, 16, 40, 0, 0, DateTimeKind.Utc), null, null, 50.14m, 1.27m, "AU", 39.48m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7b25fa2e-3485-4160-867f-378fafefca74"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 5, 16, 38, 0, 0, DateTimeKind.Utc), null, null, 320.12m, 3.43m, "VYG", 93.33m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8baa9c08-6d99-416b-a512-81400c567fc1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 3, 19, 31, 0, 0, DateTimeKind.Utc), null, null, 175.65m, 2.30m, "G", 76.37m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("eb2bbd2a-f8c2-413c-9bb9-bedf6100c0cc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 24, 17, 44, 0, 0, DateTimeKind.Utc), null, null, 120.35m, 1.80m, "J", 66.86m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5165e725-989d-48d4-8e2b-6ed46abc3edd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 21, 17, 16, 0, 0, DateTimeKind.Utc), null, null, 36.10m, 1.30m, "J", 27.77m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fb7789ee-6d64-4d0f-9cb9-db38d79e741d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 7, 17, 2, 0, 0, DateTimeKind.Utc), null, null, 338.50m, 4.91m, "HB", 68.94m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("554f7152-00d6-4f9e-ba2b-f9f23b9f4c39"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 23, 16, 25, 0, 0, DateTimeKind.Utc), null, null, 259.24m, 4.43m, "PBH", 58.52m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ca09131f-aea6-49b1-9476-207968875c0f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 3, 20, 28, 0, 0, DateTimeKind.Utc), null, null, 55.78m, 1.85m, "W", 30.15m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a82b5b90-e98d-4977-b280-05fa5075ccb2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 6, 17, 46, 0, 0, DateTimeKind.Utc), null, null, 37.36m, 2.10m, "NA", 17.79m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("24551dbe-3ef1-47b7-95fa-249d26afcc42"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 20, 34, 0, 0, DateTimeKind.Utc), null, null, 34.56m, 0.46m, "YSE", 75.13m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2efe2a82-1d1d-4b11-b8c1-c223989730e2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 2, 18, 37, 0, 0, DateTimeKind.Utc), null, null, 73.20m, 2.02m, "PCH", 36.24m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7c5ccc9d-c772-4861-9bce-bd6fb1c547a3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 27, 17, 0, 0, 0, DateTimeKind.Utc), null, null, 154.98m, 3.89m, "F", 39.84m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7519bf36-f3f1-4c9b-9493-7c524449749d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 8, 17, 5, 0, 0, DateTimeKind.Utc), null, null, 14.48m, 4.51m, "OEZ", 3.21m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("192ab9b8-0395-4cd8-a1c7-976c005dfa2e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 22, 16, 17, 0, 0, DateTimeKind.Utc), null, null, 307.44m, 4.20m, "ACL", 73.2m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b672de65-c42d-4c1f-835c-62cede3786ea"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 9, 18, 56, 0, 0, DateTimeKind.Utc), null, null, 33.96m, 3.04m, "ZDP", 11.17m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("531a9fe6-4fa7-49c4-a2d8-37645680746e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 5, 17, 14, 0, 0, DateTimeKind.Utc), null, null, 75.61m, 2.27m, "RR", 33.31m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4a47e394-5cc7-4461-a1ba-327376bb8653"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 30, 14, 52, 0, 0, DateTimeKind.Utc), null, null, 197.50m, 2.09m, "QQ", 94.5m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("703be859-95fb-4729-9c00-9c09306a0b7b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 24, 15, 7, 0, 0, DateTimeKind.Utc), null, null, 149.11m, 1.71m, "HYQ", 87.2m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3e68647d-7f47-4036-9e8e-0a3df204ea02"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 14, 19, 14, 0, 0, DateTimeKind.Utc), null, null, 155.93m, 4.85m, "TXG", 32.15m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e3392358-51b8-47c4-a428-6e32cccebfbb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 1, 17, 23, 0, 0, DateTimeKind.Utc), null, null, 196.03m, 2.52m, "ZJU", 77.79m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("aa8d1be5-e768-47c8-afa3-1768de27aacc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 13, 16, 18, 0, 0, DateTimeKind.Utc), null, null, 111.30m, 4.38m, "TC", 25.41m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bcb212ef-bd9e-47ba-bf23-b007dee5c86b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 1, 17, 5, 0, 0, DateTimeKind.Utc), null, null, 24.37m, 0.25m, "EZ", 97.47m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6eb30ef9-609c-4518-b0df-d5e0fe6ebf52"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 18, 17, 23, 0, 0, DateTimeKind.Utc), null, null, 25.42m, 0.37m, "BVV", 68.71m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("dd04cc9c-27b7-404d-87cb-7dfbd5524832"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 31, 19, 4, 0, 0, DateTimeKind.Utc), null, null, 34.16m, 0.78m, "T", 43.8m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6b0f1cd9-956e-429c-b4c6-4a6960f69770"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 19, 19, 50, 0, 0, DateTimeKind.Utc), null, null, 29.59m, 2.48m, "XP", 11.93m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ec197512-ca76-4c13-b0e3-f906a58da87a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 25, 14, 38, 0, 0, DateTimeKind.Utc), null, null, 241.10m, 2.43m, "X", 99.22m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8e99ad61-e95e-4f3d-b21a-c4ee9ce61f08"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 5, 20, 55, 0, 0, DateTimeKind.Utc), null, null, 187.74m, 2.26m, "I", 83.07m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ebb2c7f3-a61b-4ec0-88e3-a7a6034fa627"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 22, 17, 28, 0, 0, DateTimeKind.Utc), null, null, 60.22m, 2.73m, "C", 22.06m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("80589364-19df-495e-ad71-30f7f16cb736"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 3, 17, 38, 0, 0, DateTimeKind.Utc), null, null, 57.83m, 3.85m, "ZK", 15.02m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("47e2c205-36a6-4f8f-8865-2a336a2b84fe"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 18, 17, 28, 0, 0, DateTimeKind.Utc), null, null, 31.15m, 1.38m, "LGI", 22.57m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("09270ffa-dd46-4692-8c5a-ab25d021020d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 16, 18, 19, 0, 0, DateTimeKind.Utc), null, null, 317.94m, 4.20m, "C", 75.7m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b7133d68-3662-4996-945f-13a7898a85db"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 14, 16, 19, 0, 0, DateTimeKind.Utc), null, null, 9.88m, 3.03m, "ZUB", 3.26m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f9c7a161-9cde-4ce5-9b30-1bcffad6394f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 23, 18, 39, 0, 0, DateTimeKind.Utc), null, null, 21.32m, 4.79m, "MSY", 4.45m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3e5adcbf-0d24-4ec4-94e9-bca351ea4e1f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 30, 16, 16, 0, 0, DateTimeKind.Utc), null, null, 220.08m, 2.61m, "AV", 84.32m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b745beec-9232-4581-b8dd-06360c487abd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 9, 17, 44, 0, 0, DateTimeKind.Utc), null, null, 102.01m, 4.33m, "MIR", 23.56m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a39cadc4-7607-423a-a9f7-558f75ed6149"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 20, 19, 37, 0, 0, DateTimeKind.Utc), null, null, 176.75m, 3.39m, "VYX", 52.14m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ae97f6c1-6e0d-4ed8-817a-e92ae016f6fd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 9, 16, 1, 0, 0, DateTimeKind.Utc), null, null, 98.26m, 3.40m, "E", 28.9m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e8684d09-23eb-43f8-af5d-7db6bc49dbb6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 1, 17, 51, 0, 0, DateTimeKind.Utc), null, null, 106.44m, 2.79m, "X", 38.15m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("83f3976e-8b51-4b29-9a02-961cc17791cc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 26, 18, 2, 0, 0, DateTimeKind.Utc), null, null, 148.11m, 2.69m, "N", 55.06m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("33fac087-ca73-42aa-84e0-aa455bc5c0cc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 13, 16, 48, 0, 0, DateTimeKind.Utc), null, null, 231.00m, 2.33m, "YK", 99.14m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("43992eba-2c06-495f-939d-1e3dd2d8e8c2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 27, 15, 41, 0, 0, DateTimeKind.Utc), null, null, 61.39m, 1.60m, "C", 38.37m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("da3c2de6-7300-4fc4-bd14-ccd6711b8ad1"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 8, 15, 46, 0, 0, DateTimeKind.Utc), null, null, 271.59m, 2.87m, "ON", 94.63m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("da5c8251-128f-4a56-987c-9d356c90847b"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 9, 16, 1, 0, 0, DateTimeKind.Utc), null, null, 71.84m, 0.74m, "GWK", 97.08m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5a44b4b3-56ad-49fd-b51f-322329b0e886"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 24, 16, 3, 0, 0, DateTimeKind.Utc), null, null, 331.21m, 4.92m, "K", 67.32m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("26194e53-6064-4d82-9561-05ab088a9205"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 6, 20, 9, 0, 0, DateTimeKind.Utc), null, null, 79.43m, 0.87m, "F", 91.3m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fe2d5402-a1bb-4499-a011-d7159e336671"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 12, 20, 18, 0, 0, DateTimeKind.Utc), null, null, 157.01m, 3.17m, "UGS", 49.53m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c5c1c3e8-f945-4e85-bcfb-59532d31ea38"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 13, 18, 50, 0, 0, DateTimeKind.Utc), null, null, 100.67m, 4.68m, "SFA", 21.51m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e0ab3023-285f-478e-bc6c-fbc88aea721c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 27, 15, 54, 0, 0, DateTimeKind.Utc), null, null, 23.37m, 2.73m, "ZWN", 8.56m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e4165b32-7368-4edc-bf5c-3adc20a4efc2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 13, 19, 30, 0, 0, DateTimeKind.Utc), null, null, 8.96m, 0.44m, "C", 20.36m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fa48ad30-b39b-4ab4-9631-bf90298ff450"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 30, 15, 26, 0, 0, DateTimeKind.Utc), null, null, 244.05m, 3.93m, "PS", 62.1m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("545a9142-4231-4553-8129-12bdd4bf0ab6"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 25, 17, 35, 0, 0, DateTimeKind.Utc), null, null, 77.82m, 0.95m, "I", 81.92m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4720527c-848e-4901-b42d-28e65845090e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 23, 15, 59, 0, 0, DateTimeKind.Utc), null, null, 28.95m, 1.10m, "ZMY", 26.32m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bbde7bbc-b17a-4c42-89c3-e989fc215607"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 19, 54, 0, 0, DateTimeKind.Utc), null, null, 171.36m, 3.24m, "WBC", 52.89m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9b52cfd6-3a42-43a2-a41c-687731e81ecd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 6, 5, 20, 13, 0, 0, DateTimeKind.Utc), null, null, 299.59m, 4.97m, "PF", 60.28m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d5f9bd9c-d93c-445e-9a67-c785b499382e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 25, 17, 4, 0, 0, DateTimeKind.Utc), null, null, 187.82m, 2.58m, "T", 72.8m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a1a56c2b-f559-4093-883b-11243892d62e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 29, 17, 24, 0, 0, DateTimeKind.Utc), null, null, 1.49m, 0.47m, "P", 3.17m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1481df76-68c3-4385-95c2-aa5a803f59fe"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 5, 15, 3, 0, 0, DateTimeKind.Utc), null, null, 114.45m, 1.93m, "V", 59.3m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a2d638a7-3e53-47f7-80ee-e6e357b4bb1d"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 5, 19, 37, 0, 0, DateTimeKind.Utc), null, null, 1.66m, 0.14m, "RH", 11.83m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b6581b67-53a9-4090-b24b-212415b1d718"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 20, 16, 57, 0, 0, DateTimeKind.Utc), null, null, 169.16m, 3.55m, "PS", 47.65m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("28e16992-066b-4421-8f5f-89bc4d09e727"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 2, 16, 19, 0, 0, DateTimeKind.Utc), null, null, 6.27m, 0.20m, "SF", 31.35m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("afacc7b7-7445-4919-811c-3bba11226a72"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 1, 20, 29, 0, 0, DateTimeKind.Utc), null, null, 247.67m, 3.39m, "FIP", 73.06m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("79094529-cc58-46ae-8660-35251aa8cedc"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 15, 31, 0, 0, DateTimeKind.Utc), null, null, 9.81m, 2.81m, "XFB", 3.49m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("97c47f8d-b659-4e3d-ac50-b4bde23a2906"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 15, 19, 26, 0, 0, DateTimeKind.Utc), null, null, 124.05m, 2.05m, "QXE", 60.51m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d94df4be-e053-490f-8f83-9fb1847014f9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 21, 18, 25, 0, 0, DateTimeKind.Utc), null, null, 62.94m, 1.29m, "MWG", 48.79m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("009b99c4-311a-408e-88d0-7f6431e64a58"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 19, 20, 58, 0, 0, DateTimeKind.Utc), null, null, 61.84m, 1.04m, "FSY", 59.46m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c75c336e-2ab1-4377-880e-d77f8ac0af57"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 21, 17, 55, 0, 0, DateTimeKind.Utc), null, null, 161.15m, 3.79m, "F", 42.52m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("40811921-8c31-4d08-917c-f839b287edcd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 28, 17, 57, 0, 0, DateTimeKind.Utc), null, null, 106.14m, 4.82m, "NAL", 22.02m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2760f220-aea0-4c53-8392-00cf62c98dfa"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 17, 20, 26, 0, 0, DateTimeKind.Utc), null, null, 393.19m, 4.64m, "JN", 84.74m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("362f10ee-5d16-4f9d-9933-c6237b42ea0e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 1, 19, 39, 0, 0, DateTimeKind.Utc), null, null, 411.28m, 4.58m, "RF", 89.8m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ebb95278-b10b-47ba-a2f2-ee8a018f2b86"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 22, 19, 56, 0, 0, DateTimeKind.Utc), null, null, 219.22m, 3.19m, "YB", 68.72m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("54b49cb2-9416-40dc-9df9-250c49236a15"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 19, 18, 31, 0, 0, DateTimeKind.Utc), null, null, 375.36m, 3.76m, "O", 99.83m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1a9f2768-4671-4ce8-88f7-6b0769186b4f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 18, 20, 24, 0, 0, DateTimeKind.Utc), null, null, 61.11m, 1.08m, "W", 56.58m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e5b711ba-73b6-43e0-af3e-1d38c92237e9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 14, 14, 46, 0, 0, DateTimeKind.Utc), null, null, 85.72m, 2.53m, "YQ", 33.88m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("80783fbc-107d-4c82-a928-f5b2af193b83"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 4, 19, 58, 0, 0, DateTimeKind.Utc), null, null, 275.28m, 3.22m, "JO", 85.49m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("69688039-ff02-4a30-8704-bc680db43549"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 5, 20, 8, 0, 0, DateTimeKind.Utc), null, null, 199.77m, 4.34m, "OI", 46.03m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3538fd2f-990a-46f1-9a67-d0a14654313a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 31, 20, 24, 0, 0, DateTimeKind.Utc), null, null, 18.03m, 2.45m, "G", 7.36m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fa3d337e-63e1-464c-ba19-0859e7ecb7e4"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 9, 18, 34, 0, 0, DateTimeKind.Utc), null, null, 37.20m, 0.38m, "X", 97.89m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9f6379b5-7d55-468e-a650-768a2cb825d2"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 28, 16, 56, 0, 0, DateTimeKind.Utc), null, null, 11.77m, 0.93m, "Z", 12.66m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9e0f801b-8e31-430d-83d1-cac5d562e6bb"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 8, 15, 36, 0, 0, DateTimeKind.Utc), null, null, 63.22m, 1.01m, "AYS", 62.59m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("47087326-3246-4b8a-a579-9c621085dc7a"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 12, 20, 35, 0, 0, DateTimeKind.Utc), null, null, 38.03m, 1.22m, "Z", 31.17m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7779ba17-bd64-4105-9eca-199c7e15ea48"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 8, 14, 46, 0, 0, DateTimeKind.Utc), null, null, 92.64m, 0.96m, "OT", 96.5m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e00eefb1-f9bd-441a-b4a7-0e65cc492228"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 3, 18, 22, 0, 0, DateTimeKind.Utc), null, null, 126.60m, 4.17m, "H", 30.36m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("47580c61-a534-44e7-94a7-c1ac30e1ada9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 15, 16, 58, 0, 0, DateTimeKind.Utc), null, null, 56.32m, 2.60m, "S", 21.66m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b338ac11-e333-4ee5-8d1d-03188e1bf38f"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 6, 16, 10, 0, 0, DateTimeKind.Utc), null, null, 40.80m, 0.46m, "ZDP", 88.69m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e1ba3d26-123f-4ef1-b96d-4401b77cf0c3"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 29, 20, 7, 0, 0, DateTimeKind.Utc), null, null, 403.74m, 4.37m, "HX", 92.39m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5a830790-559a-40fe-92f9-8b9ef8f824ef"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 1, 19, 6, 0, 0, DateTimeKind.Utc), null, null, 154.96m, 2.22m, "XV", 69.8m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("29764b20-3726-4c6b-ab9d-b87b12020e07"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 3, 19, 7, 0, 0, DateTimeKind.Utc), null, null, 9.32m, 0.53m, "LPA", 17.58m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("032627c0-94db-4d71-88a3-22d172824b6e"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 24, 19, 27, 0, 0, DateTimeKind.Utc), null, null, 237.23m, 4.57m, "JL", 51.91m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2fa21658-aa38-44e6-8d2e-dc446f5d646c"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 15, 14, 30, 0, 0, DateTimeKind.Utc), null, null, 61.06m, 1.72m, "JLD", 35.5m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d75a929c-d222-4f03-a69f-86bb1a2fdf98"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 21, 16, 20, 0, 0, DateTimeKind.Utc), null, null, 47.40m, 2.61m, "ZD", 18.16m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3015e169-f89c-4df9-883e-b62640f833fd"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 7, 20, 36, 0, 0, DateTimeKind.Utc), null, null, 103.30m, 1.42m, "N", 72.75m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0705396a-a948-4bd8-821d-082a98574752"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 9, 17, 10, 0, 0, DateTimeKind.Utc), null, null, 0.60m, 0.07m, "K", 8.61m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ac50a00a-bc56-46d2-ad76-7738d96d94d9"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 6, 16, 54, 0, 0, DateTimeKind.Utc), null, null, 319.77m, 4.95m, "F", 64.6m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessTag", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("55491fc2-e161-4219-8b2a-3651810d7088"), "testUserName", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 30, 14, 59, 0, 0, DateTimeKind.Utc), null, null, 4.70m, 1.34m, "HOZ", 3.51m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
