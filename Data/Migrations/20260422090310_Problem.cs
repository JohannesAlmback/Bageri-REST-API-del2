using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mormor_Dagnys_Bageri_REST_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Problem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Suppliers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SupplierContactId",
                table: "SupplierContacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommodityId",
                table: "Commodities",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SupplierPrices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SupplierPrices");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suppliers",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SupplierContacts",
                newName: "SupplierContactId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Commodities",
                newName: "CommodityId");
        }
    }
}
