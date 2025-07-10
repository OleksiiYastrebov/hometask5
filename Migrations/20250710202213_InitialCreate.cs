using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hometask5.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    gr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gr_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    gr_temp = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Groups__2BC0F88EBD58F738", x => x.gr_id);
                });

            migrationBuilder.CreateTable(
                name: "Analysis",
                columns: table => new
                {
                    an_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    an_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    an_cost = table.Column<decimal>(type: "money", nullable: false),
                    an_price = table.Column<decimal>(type: "money", nullable: false),
                    an_group = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Analysis__831DABF3C016F1F2", x => x.an_id);
                    table.ForeignKey(
                        name: "FK__Analysis__an_gro__3B75D760",
                        column: x => x.an_group,
                        principalTable: "Groups",
                        principalColumn: "gr_id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ord_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ord_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ord_an = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__DC39D7DFF1FDB40D", x => x.ord_id);
                    table.ForeignKey(
                        name: "FK__Orders__ord_an__3E52440B",
                        column: x => x.ord_an,
                        principalTable: "Analysis",
                        principalColumn: "an_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analysis_an_group",
                table: "Analysis",
                column: "an_group");

            migrationBuilder.CreateIndex(
                name: "UQ__Analysis__251E3FCD0619E067",
                table: "Analysis",
                column: "an_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Groups__2291CF8D1E34F79C",
                table: "Groups",
                column: "gr_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ord_an",
                table: "Orders",
                column: "ord_an");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Analysis");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
