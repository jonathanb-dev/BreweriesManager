using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class EditEntities4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Breweries_BreweryId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleHeaders_Wholesalers_WholesalerId",
                table: "SaleHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleLines_Beers_BeerId",
                table: "SaleLines");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleLines_SaleHeaders_SaleHeaderId",
                table: "SaleLines");

            migrationBuilder.AlterColumn<int>(
                name: "SaleHeaderId",
                table: "SaleLines",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BeerId",
                table: "SaleLines",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WholesalerId",
                table: "SaleHeaders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BreweryId",
                table: "Beers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Breweries_BreweryId",
                table: "Beers",
                column: "BreweryId",
                principalTable: "Breweries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleHeaders_Wholesalers_WholesalerId",
                table: "SaleHeaders",
                column: "WholesalerId",
                principalTable: "Wholesalers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleLines_Beers_BeerId",
                table: "SaleLines",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleLines_SaleHeaders_SaleHeaderId",
                table: "SaleLines",
                column: "SaleHeaderId",
                principalTable: "SaleHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Breweries_BreweryId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleHeaders_Wholesalers_WholesalerId",
                table: "SaleHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleLines_Beers_BeerId",
                table: "SaleLines");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleLines_SaleHeaders_SaleHeaderId",
                table: "SaleLines");

            migrationBuilder.AlterColumn<int>(
                name: "SaleHeaderId",
                table: "SaleLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BeerId",
                table: "SaleLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WholesalerId",
                table: "SaleHeaders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BreweryId",
                table: "Beers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Breweries_BreweryId",
                table: "Beers",
                column: "BreweryId",
                principalTable: "Breweries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleHeaders_Wholesalers_WholesalerId",
                table: "SaleHeaders",
                column: "WholesalerId",
                principalTable: "Wholesalers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
        }
    }
}
