using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pagamento.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumber = table.Column<string>(type: "varchar(100)", nullable: true),
                    Holder = table.Column<string>(type: "varchar(100)", nullable: true),
                    ExpirationDate = table.Column<string>(type: "varchar(100)", nullable: true),
                    SecurityCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    Brand = table.Column<string>(type: "varchar(100)", nullable: true),
                    Usage = table.Column<string>(type: "varchar(100)", nullable: true),
                    Reason = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Installments = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<string>(type: "varchar(100)", nullable: true),
                    Capture = table.Column<bool>(type: "bit", nullable: false),
                    Authenticate = table.Column<bool>(type: "bit", nullable: false),
                    Recurrent = table.Column<bool>(type: "bit", nullable: false),
                    Tid = table.Column<string>(type: "varchar(100)", nullable: true),
                    ProofOfSale = table.Column<string>(type: "varchar(100)", nullable: true),
                    AuthorizationCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    Provider = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsQrCode = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivedDate = table.Column<string>(type: "varchar(100)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsSplitted = table.Column<bool>(type: "bit", nullable: false),
                    ReturnMessage = table.Column<string>(type: "varchar(100)", nullable: true),
                    ReturnCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    Type = table.Column<string>(type: "varchar(100)", nullable: true),
                    Currency = table.Column<string>(type: "varchar(100)", nullable: true),
                    Country = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsCryptoCurrencyNegotiation = table.Column<bool>(type: "bit", nullable: false),
                    ReasonCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    ReasonMessage = table.Column<string>(type: "varchar(100)", nullable: true),
                    ProviderReturnCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    ProviderReturnMessage = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Method = table.Column<string>(type: "varchar(100)", nullable: true),
                    Rel = table.Column<string>(type: "varchar(100)", nullable: true),
                    Href = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MerchantOrderId = table.Column<string>(type: "varchar(100)", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PaymentId",
                table: "Links",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PaymentId",
                table: "Transactions",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
