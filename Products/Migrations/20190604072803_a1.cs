using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Migrations
{
    public partial class a1 : Migration
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
                    CurrId = table.Column<int>(nullable: false),
                    ProducerId = table.Column<int>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                columns: new[] { "Id", "Available", "CurrId", "CurrencyId", "Description", "Name", "Price", "ProdId", "ProducerId" },
                values: new object[] { 1, true, 0, null, "fast&furios", "A1", 100, 0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CurrId", "CurrencyId", "Description", "Name", "Price", "ProdId", "ProducerId" },
                values: new object[] { 2, false, 0, null, "soft", "B1", 150, 0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CurrId", "CurrencyId", "Description", "Name", "Price", "ProdId", "ProducerId" },
                values: new object[] { 3, true, 0, null, "-", "C1", 6000, 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CurrencyId",
                table: "Products",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerId",
                table: "Products",
                column: "ProducerId");
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
