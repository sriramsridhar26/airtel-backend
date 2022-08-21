using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace airtel.Migrations
{
    public partial class firstbuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    customerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "packs",
                columns: table => new
                {
                    packId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Talktime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false),
                    validity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packs", x => x.packId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    customerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.customerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "packs");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
