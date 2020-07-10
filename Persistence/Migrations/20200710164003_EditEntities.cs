using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class EditEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleLine_Beers_BeerId",
                table: "SaleLine");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleLine_SaleHeaders_SaleHeaderId",
                table: "SaleLine");

            migrationBuilder.DropForeignKey(
                name: "FK_WholesalerBeer_Beers_BeerId",
                table: "WholesalerBeer");

            migrationBuilder.DropForeignKey(
                name: "FK_WholesalerBeer_Wholesalers_WholesalerId",
                table: "WholesalerBeer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WholesalerBeer",
                table: "WholesalerBeer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleLine",
                table: "SaleLine");

            migrationBuilder.RenameTable(
                name: "WholesalerBeer",
                newName: "WholesalerBeers");

            migrationBuilder.RenameTable(
                name: "SaleLine",
                newName: "SaleLines");

            migrationBuilder.RenameIndex(
                name: "IX_WholesalerBeer_BeerId",
                table: "WholesalerBeers",
                newName: "IX_WholesalerBeers_BeerId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleLine_SaleHeaderId",
                table: "SaleLines",
                newName: "IX_SaleLines_SaleHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleLine_BeerId",
                table: "SaleLines",
                newName: "IX_SaleLines_BeerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WholesalerBeers",
                table: "WholesalerBeers",
                columns: new[] { "WholesalerId", "BeerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleLines",
                table: "SaleLines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleLines_Beers_BeerId",
                table: "SaleLines",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleLines_SaleHeaders_SaleHeaderId",
                table: "SaleLines",
                column: "SaleHeaderId",
                principalTable: "SaleHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WholesalerBeers_Beers_BeerId",
                table: "WholesalerBeers",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WholesalerBeers_Wholesalers_WholesalerId",
                table: "WholesalerBeers",
                column: "WholesalerId",
                principalTable: "Wholesalers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleLines_Beers_BeerId",
                table: "SaleLines");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleLines_SaleHeaders_SaleHeaderId",
                table: "SaleLines");

            migrationBuilder.DropForeignKey(
                name: "FK_WholesalerBeers_Beers_BeerId",
                table: "WholesalerBeers");

            migrationBuilder.DropForeignKey(
                name: "FK_WholesalerBeers_Wholesalers_WholesalerId",
                table: "WholesalerBeers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WholesalerBeers",
                table: "WholesalerBeers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleLines",
                table: "SaleLines");

            migrationBuilder.RenameTable(
                name: "WholesalerBeers",
                newName: "WholesalerBeer");

            migrationBuilder.RenameTable(
                name: "SaleLines",
                newName: "SaleLine");

            migrationBuilder.RenameIndex(
                name: "IX_WholesalerBeers_BeerId",
                table: "WholesalerBeer",
                newName: "IX_WholesalerBeer_BeerId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleLines_SaleHeaderId",
                table: "SaleLine",
                newName: "IX_SaleLine_SaleHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleLines_BeerId",
                table: "SaleLine",
                newName: "IX_SaleLine_BeerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WholesalerBeer",
                table: "WholesalerBeer",
                columns: new[] { "WholesalerId", "BeerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleLine",
                table: "SaleLine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleLine_Beers_BeerId",
                table: "SaleLine",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleLine_SaleHeaders_SaleHeaderId",
                table: "SaleLine",
                column: "SaleHeaderId",
                principalTable: "SaleHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WholesalerBeer_Beers_BeerId",
                table: "WholesalerBeer",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WholesalerBeer_Wholesalers_WholesalerId",
                table: "WholesalerBeer",
                column: "WholesalerId",
                principalTable: "Wholesalers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
