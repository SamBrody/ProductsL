using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CityL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: false),
                    CurrencyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "₽" });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "$" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CityL", "Name" },
                values: new object[] { 1, "Herzogenaurach", "Adidas" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CityL", "Name" },
                values: new object[] { 2, "Beaverton", "Nike" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CityL", "Name" },
                values: new object[] { 3, "Herzogenaurach", "Puma" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CurrencyID", "Description", "ManufacturerID", "Name", "Price" },
                values: new object[] { 1, true, 2, "fast&furios", 1, "A1", 100 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CurrencyID", "Description", "ManufacturerID", "Name", "Price" },
                values: new object[] { 3, true, 1, "-", 2, "C1", 6000 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CurrencyID", "Description", "ManufacturerID", "Name", "Price" },
                values: new object[] { 2, false, 2, "soft", 3, "B1", 150 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrencyID",
                table: "Products",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerID",
                table: "Products",
                column: "ManufacturerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
