using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class EditEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "SaleLines",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "SaleLines",
                type: "decimal(5, 0)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
