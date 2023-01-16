using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFZ.Migrations
{
    /// <inheritdoc />
    public partial class piaty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ProductCount",
                table: "receiptProducts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ProductCount",
                table: "orderProducts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ProductCount",
                table: "invoiceProducts",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "receiptProducts");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "orderProducts");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "invoiceProducts");
        }
    }
}
