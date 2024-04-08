using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundoBiblico.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Atualizaçãotabelanova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompraId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IngrejaId",
                table: "Clientes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    Troco = table.Column<double>(type: "float", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CompraId",
                table: "Produtos",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ClienteId",
                table: "Compras",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Compras_CompraId",
                table: "Produtos",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Compras_CompraId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CompraId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IngrejaId",
                table: "Clientes");
        }
    }
}
