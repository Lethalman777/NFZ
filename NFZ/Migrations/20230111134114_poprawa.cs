using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFZ.Migrations
{
    /// <inheritdoc />
    public partial class poprawa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workers_invoices_InvoiceId",
                table: "workers");

            migrationBuilder.DropForeignKey(
                name: "FK_workers_receipts_ReceiptId",
                table: "workers");

            migrationBuilder.DropIndex(
                name: "IX_workers_InvoiceId",
                table: "workers");

            migrationBuilder.DropIndex(
                name: "IX_workers_ReceiptId",
                table: "workers");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "workers");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "workers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "receipts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "invoices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "workers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "workers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "receipts",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "invoices",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_workers_InvoiceId",
                table: "workers",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_workers_ReceiptId",
                table: "workers",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_workers_invoices_InvoiceId",
                table: "workers",
                column: "InvoiceId",
                principalTable: "invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workers_receipts_ReceiptId",
                table: "workers",
                column: "ReceiptId",
                principalTable: "receipts",
                principalColumn: "Id");
        }
    }
}
