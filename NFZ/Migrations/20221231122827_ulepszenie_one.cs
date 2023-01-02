using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFZ.Migrations
{
    /// <inheritdoc />
    public partial class ulepszenieone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Invoke_InvokeId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Invoke_InvokeId",
                table: "Worker");

            migrationBuilder.DropTable(
                name: "Invoke");

            migrationBuilder.RenameColumn(
                name: "InvokeId",
                table: "Worker",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_InvokeId",
                table: "Worker",
                newName: "IX_Worker_InvoiceId");

            migrationBuilder.RenameColumn(
                name: "InvokeId",
                table: "Product",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_InvokeId",
                table: "Product",
                newName: "IX_Product_InvoiceId");

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NIP = table.Column<int>(type: "int", nullable: false),
                    AccountNr = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_WorkerId",
                table: "Invoice",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Invoice_InvoiceId",
                table: "Product",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Invoice_InvoiceId",
                table: "Worker",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Invoice_InvoiceId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Invoice_InvoiceId",
                table: "Worker");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Worker",
                newName: "InvokeId");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_InvoiceId",
                table: "Worker",
                newName: "IX_Worker_InvokeId");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Product",
                newName: "InvokeId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_InvoiceId",
                table: "Product",
                newName: "IX_Product_InvokeId");

            migrationBuilder.CreateTable(
                name: "Invoke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    AccountNr = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NIP = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoke_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoke_WorkerId",
                table: "Invoke",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Invoke_InvokeId",
                table: "Product",
                column: "InvokeId",
                principalTable: "Invoke",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Invoke_InvokeId",
                table: "Worker",
                column: "InvokeId",
                principalTable: "Invoke",
                principalColumn: "Id");
        }
    }
}
