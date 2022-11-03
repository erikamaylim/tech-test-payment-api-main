using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_test_payment_api_main.Migrations
{
    public partial class CriacaoTabelaVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemVenda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdVendedor = table.Column<int>(type: "int", nullable: false),
                    NomeVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpfVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefoneVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailVendedor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
