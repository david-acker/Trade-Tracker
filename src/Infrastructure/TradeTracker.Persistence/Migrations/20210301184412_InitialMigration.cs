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
                    AccessKey = table.Column<string>(type: "TEXT", nullable: true),
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
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e92878b0-adbf-4303-b677-b2f3361a3eac"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 15, 19, 14, 0, 0, DateTimeKind.Utc), null, null, 19.49m, 3.39m, "FI", 5.75m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ece62ddb-5454-4ea1-a243-e85690e35029"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 24, 18, 22, 0, 0, DateTimeKind.Utc), null, null, 288.56m, 3.82m, "G", 75.54m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("01948e07-2726-42fb-b2ac-c1c7c5e530ce"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 1, 18, 1, 0, 0, DateTimeKind.Utc), null, null, 45.50m, 2.98m, "DT", 15.27m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8f74da44-336b-4abb-ac5c-ee76bd083dac"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 11, 17, 3, 0, 0, DateTimeKind.Utc), null, null, 0.89m, 0.20m, "T", 4.43m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ccdabc42-a22c-4ac7-9356-90b19d2a3c7c"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 23, 17, 58, 0, 0, DateTimeKind.Utc), null, null, 20.93m, 3.46m, "EM", 6.05m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d3a6302c-41b3-4d47-b9c1-7df115032666"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 6, 18, 57, 0, 0, DateTimeKind.Utc), null, null, 286.60m, 3.83m, "I", 74.83m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7b903e4a-eb28-4a5c-bc7f-e459340ec8ee"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 11, 20, 53, 0, 0, DateTimeKind.Utc), null, null, 108.74m, 3.25m, "BH", 33.46m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a1074f78-9c25-4e8e-840d-f5c53ce27109"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 15, 17, 25, 0, 0, DateTimeKind.Utc), null, null, 2.51m, 0.76m, "AJO", 3.3m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e6686070-a736-4f98-8a34-00e09fd8bb1e"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 19, 10, 0, 0, DateTimeKind.Utc), null, null, 204.50m, 4.61m, "PX", 44.36m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7d683b85-e814-4991-b59b-e7f72290acd8"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 3, 14, 47, 0, 0, DateTimeKind.Utc), null, null, 69.54m, 2.55m, "BM", 27.27m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8f3946fb-ed1c-4cec-a440-874e64c90898"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 3, 14, 53, 0, 0, DateTimeKind.Utc), null, null, 74.73m, 1.09m, "QDK", 68.56m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("246a7c24-f190-4de0-a423-863ee483ba48"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 17, 15, 51, 0, 0, DateTimeKind.Utc), null, null, 28.97m, 1.65m, "Q", 17.56m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2d0737de-96eb-4c51-b018-e8cfc65f5583"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 19, 15, 13, 0, 0, DateTimeKind.Utc), null, null, 241.69m, 3.48m, "UZH", 69.45m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("773d4896-1520-4033-bab9-06997d1602be"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 14, 19, 31, 0, 0, DateTimeKind.Utc), null, null, 36.27m, 0.46m, "PVN", 78.85m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("953f8987-36ba-4e74-942b-026a987751c7"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 23, 17, 7, 0, 0, DateTimeKind.Utc), null, null, 48.96m, 2.83m, "YRP", 17.3m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4869997e-0786-4738-817b-38be2c615283"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 28, 20, 5, 0, 0, DateTimeKind.Utc), null, null, 444.70m, 4.85m, "XGT", 91.69m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("96048b52-18a8-415b-9171-b71eae490c2d"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 24, 19, 23, 0, 0, DateTimeKind.Utc), null, null, 15.92m, 2.30m, "XH", 6.92m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("55afd82f-3c6a-46ba-8ea4-65027ee2e32d"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 3, 20, 25, 0, 0, DateTimeKind.Utc), null, null, 4.60m, 0.08m, "MEP", 57.55m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7f0c96a3-cffc-4029-9a03-3dd9c5a5f2b0"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 15, 17, 7, 0, 0, DateTimeKind.Utc), null, null, 175.58m, 3.15m, "VKE", 55.74m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2acada75-5655-4423-9710-533935000cfb"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 5, 20, 9, 0, 0, DateTimeKind.Utc), null, null, 250.92m, 2.87m, "G", 87.43m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("75d291aa-d7bb-41bf-86ec-2a06a6e02308"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 31, 15, 29, 0, 0, DateTimeKind.Utc), null, null, 16.77m, 0.35m, "X", 47.91m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7af05d95-fa2f-4a42-bfe5-1b375932bac1"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 2, 15, 19, 34, 0, 0, DateTimeKind.Utc), null, null, 65.00m, 1.21m, "PSG", 53.72m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6051588e-1a77-420c-8fe4-e14800c4dd46"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 12, 18, 32, 0, 0, DateTimeKind.Utc), null, null, 214.09m, 2.82m, "FXV", 75.92m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b65e8403-d7c1-4bdd-b87e-04fd23da25da"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 11, 15, 5, 0, 0, DateTimeKind.Utc), null, null, 33.46m, 0.59m, "DS", 56.72m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("282cccbd-60ca-4b59-8981-4db0d51a1035"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 15, 19, 11, 0, 0, DateTimeKind.Utc), null, null, 26.50m, 1.55m, "B", 17.1m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f97e61e3-196f-4d2e-9743-3523f55f97c0"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 23, 15, 34, 0, 0, DateTimeKind.Utc), null, null, 338.62m, 3.61m, "FR", 93.8m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9f10c57c-1f01-4650-b8eb-5f73ad866d4a"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 27, 20, 45, 0, 0, DateTimeKind.Utc), null, null, 35.61m, 0.59m, "EQS", 60.35m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c1a7a192-e635-424a-9e47-09e4e63e1e2c"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 31, 18, 19, 0, 0, DateTimeKind.Utc), null, null, 152.60m, 2.31m, "IR", 66.06m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3c762c14-640d-4df8-95e2-8e6ecb589413"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 9, 18, 6, 0, 0, DateTimeKind.Utc), null, null, 124.73m, 1.52m, "YH", 82.06m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ece6a6dc-3592-4229-acc2-d29f31639a6e"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 20, 15, 32, 0, 0, DateTimeKind.Utc), null, null, 86.82m, 1.57m, "QCQ", 55.3m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d619afd9-380b-4c9b-991d-9ca72e85382b"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 25, 20, 57, 0, 0, DateTimeKind.Utc), null, null, 37.55m, 0.73m, "YM", 51.44m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("393687b5-c7ae-49a4-ac45-d4b74b9dd613"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 23, 19, 43, 0, 0, DateTimeKind.Utc), null, null, 181.84m, 3.05m, "TY", 59.62m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2318bf2e-78a9-4b60-928f-61cf5ddce4bd"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 24, 18, 39, 0, 0, DateTimeKind.Utc), null, null, 13.47m, 0.61m, "B", 22.09m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("bf87f816-9b03-4398-944e-2e8dab4652f3"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 21, 17, 10, 0, 0, DateTimeKind.Utc), null, null, 123.05m, 4.92m, "TUZ", 25.01m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4c21be1f-4584-4fea-83d0-1157b212063c"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 6, 20, 8, 0, 0, DateTimeKind.Utc), null, null, 82.11m, 1.21m, "LGJ", 67.86m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("318e45b2-7b56-410d-9bdd-fc1a7d0a6f68"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 3, 20, 41, 0, 0, DateTimeKind.Utc), null, null, 36.97m, 1.30m, "D", 28.44m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e4eec332-eaf5-440d-aa07-f98f7286e352"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 14, 20, 48, 0, 0, DateTimeKind.Utc), null, null, 100.62m, 4.51m, "SFT", 22.31m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("8f9413e6-64af-4fa9-a264-05731a90a908"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 16, 20, 20, 0, 0, DateTimeKind.Utc), null, null, 377.64m, 3.83m, "WXL", 98.6m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("be32c350-e100-43a6-84ee-fc3efa749363"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 11, 15, 40, 0, 0, DateTimeKind.Utc), null, null, 9.71m, 0.14m, "YIS", 69.33m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6ae1f66c-ea8d-4aaa-a30f-81d2cd2ed314"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 2, 14, 48, 0, 0, DateTimeKind.Utc), null, null, 15.97m, 0.26m, "T", 61.41m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("5645697b-3ff8-4344-91fe-a05320aad70f"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 27, 16, 9, 0, 0, DateTimeKind.Utc), null, null, 221.00m, 3.56m, "I", 62.08m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2c8bf62c-4cab-4230-83c6-8fea699c1735"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 2, 16, 28, 0, 0, DateTimeKind.Utc), null, null, 21.24m, 3.65m, "ZXH", 5.82m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d4e542f3-d270-4951-86d0-4b747089239f"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 16, 6, 0, 0, DateTimeKind.Utc), null, null, 276.24m, 4.48m, "MBQ", 61.66m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c0d0f32d-35da-4e0a-b4ec-0f63306c8e87"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 13, 20, 17, 0, 0, DateTimeKind.Utc), null, null, 62.23m, 1.72m, "EJN", 36.18m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1979e3b8-fb59-4e01-bd5c-87ff0b748612"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 13, 14, 41, 0, 0, DateTimeKind.Utc), null, null, 114.63m, 1.65m, "DI", 69.47m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fa9881ec-e528-4698-b979-69da43186268"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 25, 15, 0, 0, 0, DateTimeKind.Utc), null, null, 42.38m, 1.49m, "APC", 28.44m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("aed77636-240b-45d6-a055-7eb0d5267d97"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 21, 17, 43, 0, 0, DateTimeKind.Utc), null, null, 58.72m, 2.83m, "P", 20.75m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("4d22aca6-48c0-4b09-b8e2-f72feddb2121"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 30, 15, 42, 0, 0, DateTimeKind.Utc), null, null, 434.72m, 4.89m, "RV", 88.9m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6f88a89e-c518-4f73-a977-41a2614fc20b"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 4, 17, 10, 0, 0, DateTimeKind.Utc), null, null, 267.97m, 2.96m, "ZUC", 90.53m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a9290284-9169-4a31-850e-de872a7a4305"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 6, 15, 15, 0, 0, DateTimeKind.Utc), null, null, 120.45m, 1.60m, "ARR", 75.28m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6da224c4-e9ac-436c-974c-580342139d9e"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 3, 20, 25, 0, 0, DateTimeKind.Utc), null, null, 88.30m, 1.76m, "MTA", 50.17m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c25c1d9d-ece8-4a49-bf5f-c13bf47b972b"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 15, 20, 13, 0, 0, DateTimeKind.Utc), null, null, 118.62m, 1.89m, "GLN", 62.76m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("cc03d612-c22e-49d8-8245-cb075b8239e2"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 17, 17, 23, 0, 0, DateTimeKind.Utc), null, null, 69.41m, 3.76m, "CW", 18.46m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("64ddb121-395a-4488-8e3a-faf0d3b17626"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 11, 16, 22, 0, 0, DateTimeKind.Utc), null, null, 133.99m, 1.84m, "EW", 72.82m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("0c87af59-f19e-489b-8c16-8403912ae53d"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 24, 20, 5, 0, 0, DateTimeKind.Utc), null, null, 219.80m, 2.44m, "G", 90.08m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("fa5529fd-b239-44e4-9c00-61b13a5c930e"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 20, 16, 5, 0, 0, DateTimeKind.Utc), null, null, 55.32m, 0.82m, "GS", 67.46m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2db6a7a9-9e3d-470e-a3a6-64cecf3afea5"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 9, 20, 53, 0, 0, DateTimeKind.Utc), null, null, 301.74m, 3.39m, "R", 89.01m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("89486c95-d336-4005-8208-b4e88ab612a7"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 28, 17, 36, 0, 0, DateTimeKind.Utc), null, null, 86.40m, 4.17m, "OMS", 20.72m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ee8c7a5e-739e-4ca3-8fbb-81ef625d7cdf"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 10, 17, 13, 0, 0, DateTimeKind.Utc), null, null, 47.87m, 0.93m, "D", 51.47m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d57f85c4-a920-41c0-8f14-fe03dffcd19c"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 4, 16, 18, 0, 0, DateTimeKind.Utc), null, null, 67.50m, 1.33m, "B", 50.75m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("6760435a-7317-48a0-aae0-be22b8f4f1ff"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 25, 16, 43, 0, 0, DateTimeKind.Utc), null, null, 4.43m, 0.48m, "H", 9.22m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ecf4498b-2bbe-4c11-bc70-da66156d1f6f"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 20, 17, 58, 0, 0, DateTimeKind.Utc), null, null, 267.60m, 3.34m, "P", 80.12m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c088a046-4e89-40fc-9d7d-d6ade047e784"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 11, 16, 46, 0, 0, DateTimeKind.Utc), null, null, 81.12m, 2.19m, "ASF", 37.04m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7a6cc702-6f5e-4e7c-b295-7fef5e4af9c8"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 29, 20, 47, 0, 0, DateTimeKind.Utc), null, null, 10.44m, 0.47m, "MG", 22.22m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f8d00f59-a7d4-4089-a0e2-ff8baafad582"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 14, 14, 31, 0, 0, DateTimeKind.Utc), null, null, 41.36m, 0.49m, "VDR", 84.4m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("08bf313f-d652-4d6e-9cc9-18ee3e442ecb"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 3, 16, 35, 0, 0, DateTimeKind.Utc), null, null, 114.22m, 1.26m, "A", 90.65m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c98db727-02b6-4e9c-b7e3-fa603a5fe3f3"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 17, 19, 32, 0, 0, DateTimeKind.Utc), null, null, 307.84m, 3.66m, "DDP", 84.11m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("17877ec0-d6df-4dd9-b16e-db8567690af4"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 18, 19, 50, 0, 0, DateTimeKind.Utc), null, null, 63.37m, 1.17m, "RO", 54.16m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("96a408a1-25e6-4ca1-84ab-42010937e151"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 20, 15, 21, 0, 0, DateTimeKind.Utc), null, null, 324.65m, 4.27m, "VFF", 76.03m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ec9b5224-7f96-408c-8bf1-88691c3aa49b"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 20, 15, 1, 0, 0, DateTimeKind.Utc), null, null, 21.82m, 1.61m, "XC", 13.55m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7654a3a9-a43d-4fa8-9043-8eb2b0e11626"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 12, 14, 47, 0, 0, DateTimeKind.Utc), null, null, 53.89m, 0.91m, "ABH", 59.22m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("56fdf7cf-d2dc-4b0e-a870-95a2f7e865ac"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 13, 19, 21, 0, 0, DateTimeKind.Utc), null, null, 395.37m, 4.92m, "QLQ", 80.36m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("c00a2f96-c1f6-4526-9be6-6dbe00112325"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 11, 18, 7, 0, 0, DateTimeKind.Utc), null, null, 395.25m, 4.40m, "Y", 89.83m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("e589af30-a383-46ba-baa9-236b339241d0"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 8, 14, 40, 0, 0, DateTimeKind.Utc), null, null, 55.35m, 4.89m, "E", 11.32m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("24241bfb-c371-481e-9686-e8f666dfa5ab"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 5, 4, 14, 57, 0, 0, DateTimeKind.Utc), null, null, 133.33m, 3.53m, "AZ", 37.77m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("1051f73e-325d-4f5f-8c01-3a3edd90d10c"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 27, 15, 13, 0, 0, DateTimeKind.Utc), null, null, 26.57m, 4.10m, "A", 6.48m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("b5b25433-3689-45a9-a2c2-ef667ce60848"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 23, 19, 45, 0, 0, DateTimeKind.Utc), null, null, 58.48m, 1.44m, "FF", 40.61m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3bac21d2-ba3e-4e44-8699-5f1a7af7838c"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 9, 16, 34, 0, 0, DateTimeKind.Utc), null, null, 12.61m, 0.56m, "KWW", 22.52m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f822912a-3e83-4413-a847-22424fdcdf6d"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 7, 17, 44, 0, 0, DateTimeKind.Utc), null, null, 156.89m, 4.76m, "B", 32.96m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("415130d8-28fd-4587-be23-71d81fa0884b"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 3, 19, 59, 0, 0, DateTimeKind.Utc), null, null, 63.32m, 1.56m, "IAC", 40.59m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("176d11da-f8b2-432d-85f1-404876a81bc4"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 22, 20, 54, 0, 0, DateTimeKind.Utc), null, null, 355.39m, 4.05m, "EB", 87.75m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("2b1f9660-f166-4317-a605-9110ef602c3c"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 5, 17, 14, 0, 0, DateTimeKind.Utc), null, null, 5.08m, 0.23m, "UA", 22.08m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f5c28cfd-087e-421d-a237-95f14d1b06a6"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 28, 16, 26, 0, 0, DateTimeKind.Utc), null, null, 0.78m, 0.33m, "H", 2.35m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("301b54e5-6a9c-4580-99d3-9c759cd5804c"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 20, 20, 17, 0, 0, DateTimeKind.Utc), null, null, 79.72m, 1.00m, "LD", 79.72m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3d8d7e49-e8af-4288-9ea6-6291d56c753e"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 8, 15, 30, 0, 0, DateTimeKind.Utc), null, null, 10.91m, 0.73m, "JWB", 14.94m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("3db5f7c5-83f4-4769-a0cc-68d2d3dfeed2"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 4, 14, 34, 0, 0, DateTimeKind.Utc), null, null, 248.43m, 2.58m, "P", 96.29m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ec79e25b-4a6f-48bc-b35b-d6811f5f4408"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 30, 19, 34, 0, 0, DateTimeKind.Utc), null, null, 44.94m, 1.72m, "NPR", 26.13m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("715e072f-4a9c-4442-955d-1660583480e3"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 5, 19, 32, 0, 0, DateTimeKind.Utc), null, null, 235.55m, 3.19m, "T", 73.84m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ebeb3b4c-b4c9-43e8-8f67-8e5c0c498528"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 20, 14, 55, 0, 0, DateTimeKind.Utc), null, null, 245.50m, 4.87m, "VQ", 50.41m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("49484964-a865-48da-bb72-b31972d9e419"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 14, 15, 32, 0, 0, DateTimeKind.Utc), null, null, 229.67m, 2.69m, "QFU", 85.38m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("f5c3ad2c-cd29-4d6f-a011-4c2e7f068e05"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 17, 20, 49, 0, 0, DateTimeKind.Utc), null, null, 4.54m, 1.70m, "CEW", 2.67m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("9ebcd822-ef1d-4249-bc6e-043de5a625e1"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 14, 18, 49, 0, 0, DateTimeKind.Utc), null, null, 29.05m, 0.71m, "H", 40.91m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("195d8258-631b-4304-b236-ca7ff793094f"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 26, 16, 4, 0, 0, DateTimeKind.Utc), null, null, 28.66m, 0.84m, "MLJ", 34.12m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("a31c36aa-6177-498e-bbd7-ab13e464f5eb"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 18, 15, 48, 0, 0, DateTimeKind.Utc), null, null, 290.16m, 3.86m, "OWJ", 75.17m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("ae361a0a-566a-46f7-b3fa-f52ebae15455"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 1, 19, 36, 0, 0, DateTimeKind.Utc), null, null, 59.31m, 0.71m, "EHZ", 83.53m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("880c6fb2-2093-4f0d-9953-f86776a6eda6"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 20, 18, 5, 0, 0, DateTimeKind.Utc), null, null, 25.35m, 3.57m, "P", 7.1m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("17eb4e11-dac0-48c3-aaf1-0f5842482efa"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 14, 16, 6, 0, 0, DateTimeKind.Utc), null, null, 74.49m, 2.70m, "NAA", 27.59m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("7e91e86c-bdce-4ded-93d5-c988e2f0e324"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 13, 19, 21, 0, 0, DateTimeKind.Utc), null, null, 95.25m, 4.85m, "SSN", 19.64m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d8da1274-f2e5-48bb-ac8f-b47f868f1c71"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 18, 18, 18, 0, 0, DateTimeKind.Utc), null, null, 61.43m, 1.27m, "N", 48.37m, 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccessKey", "CreatedBy", "CreatedDate", "DateTime", "LastModifiedBy", "LastModifiedDate", "Notional", "Quantity", "Symbol", "TradePrice", "TransactionType" },
                values: new object[] { new Guid("d1e78c05-f11c-4a65-888e-8bc16cf9f7b5"), "00000000-0000-0000-0000-000000000000", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 11, 21, 19, 49, 0, 0, DateTimeKind.Utc), null, null, 166.14m, 3.14m, "E", 52.91m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
