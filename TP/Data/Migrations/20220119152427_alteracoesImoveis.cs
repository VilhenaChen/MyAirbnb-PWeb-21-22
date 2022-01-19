using Microsoft.EntityFrameworkCore.Migrations;

namespace TP.Data.Migrations
{
    public partial class alteracoesImoveis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Imovel",
                newName: "Localidade");

            migrationBuilder.AddColumn<string>(
                name: "Distrito",
                table: "Imovel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distrito",
                table: "Imovel");

            migrationBuilder.RenameColumn(
                name: "Localidade",
                table: "Imovel",
                newName: "Cidade");
        }
    }
}
