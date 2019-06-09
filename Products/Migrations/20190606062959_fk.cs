using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Migrations
{
    public partial class fk : Migration
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
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CityL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
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
                    ProdId = table.Column<int>(nullable: false),
                    CurrId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Currencies_CurrId",
                        column: x => x.CurrId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Producers_ProdId",
                        column: x => x.ProdId,
                        principalTable: "Producers",
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
                table: "Producers",
                columns: new[] { "Id", "CityL", "Name" },
                values: new object[] { 1, "Herzogenaurach", "Adidas" });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "CityL", "Name" },
                values: new object[] { 2, "Beaverton", "Nike" });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "CityL", "Name" },
                values: new object[] { 3, "Herzogenaurach", "Puma" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CurrId", "Description", "Name", "Price", "ProdId" },
                values: new object[] { 1, true, 2, "fast&furios", "A1", 100, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CurrId", "Description", "Name", "Price", "ProdId" },
                values: new object[] { 3, true, 1, "-", "C1", 6000, 2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CurrId", "Description", "Name", "Price", "ProdId" },
                values: new object[] { 2, false, 2, "soft", "B1", 150, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrId",
                table: "Products",
                column: "CurrId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdId",
                table: "Products",
                column: "ProdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
