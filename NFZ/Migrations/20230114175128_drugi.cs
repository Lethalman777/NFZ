using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFZ.Migrations
{
    /// <inheritdoc />
    public partial class drugi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_invoices_InvoiceId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_receipts_ReceiptId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_InvoiceId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ReceiptId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_InvoiceId",
                table: "products",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ReceiptId",
                table: "products",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_invoices_InvoiceId",
                table: "products",
                column: "InvoiceId",
                principalTable: "invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_receipts_ReceiptId",
                table: "products",
                column: "ReceiptId",
                principalTable: "receipts",
                principalColumn: "Id");
        }
    }
}
