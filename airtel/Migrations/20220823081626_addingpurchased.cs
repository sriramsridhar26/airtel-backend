using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace airtel.Migrations
{
    public partial class addingpurchased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "purchased",
                table: "orders",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "purchased",
                table: "orders");
        }
    }
}
