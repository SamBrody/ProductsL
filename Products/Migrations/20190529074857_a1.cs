using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency_",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producer_",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CityL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products_",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PrId = table.Column<int>(nullable: false),
                    ProducerId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    CurId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true),
                    Available = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products__Currency__CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products__Producer__ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Currency_",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "₽" });

            migrationBuilder.InsertData(
                table: "Currency_",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "$" });

            migrationBuilder.InsertData(
                table: "Producer_",
                columns: new[] { "Id", "CityL", "Name" },
                values: new object[] { 1, "Herzogenaurach", "Adidas" });

            migrationBuilder.InsertData(
                table: "Producer_",
                columns: new[] { "Id", "CityL", "Name" },
                values: new object[] { 2, "Beaverton", "Nike" });

            migrationBuilder.InsertData(
                table: "Producer_",
                columns: new[] { "Id", "CityL", "Name" },
                values: new object[] { 3, "Herzogenaurach", "Puma" });

            migrationBuilder.InsertData(
                table: "Products_",
                columns: new[] { "Id", "Available", "CurId", "CurrencyId", "Description", "Name", "PrId", "Price", "ProducerId" },
                values: new object[] { 1, true, 2, null, "fast&furios", "A1", 3, 100, null });

            migrationBuilder.InsertData(
                table: "Products_",
                columns: new[] { "Id", "Available", "CurId", "CurrencyId", "Description", "Name", "PrId", "Price", "ProducerId" },
                values: new object[] { 2, false, 2, null, "soft", "B1", 2, 150, null });

            migrationBuilder.InsertData(
                table: "Products_",
                columns: new[] { "Id", "Available", "CurId", "CurrencyId", "Description", "Name", "PrId", "Price", "ProducerId" },
                values: new object[] { 3, true, 1, null, "-", "C1", 1, 6000, null });

            migrationBuilder.CreateIndex(
                name: "IX_Products__CurrencyId",
                table: "Products_",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products__ProducerId",
                table: "Products_",
                column: "ProducerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products_");

            migrationBuilder.DropTable(
                name: "Currency_");

            migrationBuilder.DropTable(
                name: "Producer_");
        }
    }
}
