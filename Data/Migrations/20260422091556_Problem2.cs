using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mormor_Dagnys_Bageri_REST_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Problem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SupplierPrices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SupplierPrices",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
