using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundoBiblico.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Alteraçãonabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Produtos");
        }
    }
}
