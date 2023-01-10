using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFZ.Migrations
{
    /// <inheritdoc />
    public partial class ulepszenietwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Worker_WorkerId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Invoice_InvoiceId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Receipt_ReceiptId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Worker_WorkerId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Invoice_InvoiceId",
                table: "Worker");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Receipt_ReceiptId",
                table: "Worker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Worker",
                table: "Worker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.RenameTable(
                name: "Worker",
                newName: "workers");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "receipts");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "invoices");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_ReceiptId",
                table: "workers",
                newName: "IX_workers_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_InvoiceId",
                table: "workers",
                newName: "IX_workers_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_WorkerId",
                table: "receipts",
                newName: "IX_receipts_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ReceiptId",
                table: "products",
                newName: "IX_products_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_OrderId",
                table: "products",
                newName: "IX_products_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_InvoiceId",
                table: "products",
                newName: "IX_products_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_WorkerId",
                table: "invoices",
                newName: "IX_invoices_WorkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workers",
                table: "workers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_receipts",
                table: "receipts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_invoices",
                table: "invoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoices_workers_WorkerId",
                table: "invoices",
                column: "WorkerId",
                principalTable: "workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_invoices_InvoiceId",
                table: "products",
                column: "InvoiceId",
                principalTable: "invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_orders_OrderId",
                table: "products",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_receipts_ReceiptId",
                table: "products",
                column: "ReceiptId",
                principalTable: "receipts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_receipts_workers_WorkerId",
                table: "receipts",
                column: "WorkerId",
                principalTable: "workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoices_workers_WorkerId",
                table: "invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_products_invoices_InvoiceId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_orders_OrderId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_receipts_ReceiptId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_receipts_workers_WorkerId",
                table: "receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_workers_invoices_InvoiceId",
                table: "workers");

            migrationBuilder.DropForeignKey(
                name: "FK_workers_receipts_ReceiptId",
                table: "workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workers",
                table: "workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_receipts",
                table: "receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_invoices",
                table: "invoices");

            migrationBuilder.RenameTable(
                name: "workers",
                newName: "Worker");

            migrationBuilder.RenameTable(
                name: "receipts",
                newName: "Receipt");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "invoices",
                newName: "Invoice");

            migrationBuilder.RenameIndex(
                name: "IX_workers_ReceiptId",
                table: "Worker",
                newName: "IX_Worker_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_workers_InvoiceId",
                table: "Worker",
                newName: "IX_Worker_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_receipts_WorkerId",
                table: "Receipt",
                newName: "IX_Receipt_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ReceiptId",
                table: "Product",
                newName: "IX_Product_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_products_OrderId",
                table: "Product",
                newName: "IX_Product_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_products_InvoiceId",
                table: "Product",
                newName: "IX_Product_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_invoices_WorkerId",
                table: "Invoice",
                newName: "IX_Invoice_WorkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Worker",
                table: "Worker",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Worker_WorkerId",
                table: "Invoice",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Invoice_InvoiceId",
                table: "Product",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Receipt_ReceiptId",
                table: "Product",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Worker_WorkerId",
                table: "Receipt",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Invoice_InvoiceId",
                table: "Worker",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Receipt_ReceiptId",
                table: "Worker",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id");
        }
    }
}
