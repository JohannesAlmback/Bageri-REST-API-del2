using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mormor_Dagnys_Bageri_REST_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    PricePerUnit = table.Column<double>(type: "REAL", nullable: false),
                    ProductWeight = table.Column<double>(type: "REAL", nullable: false),
                    QuantityPerPack = table.Column<int>(type: "INTEGER", nullable: false),
                    BestBefore = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BakedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
