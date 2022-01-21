using Microsoft.EntityFrameworkCore.Migrations;

namespace TP.Data.Migrations
{
    public partial class MudancaNosImoveis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Imovel");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Tipo_Imovel",
                newName: "Tipo");

            migrationBuilder.AddColumn<int>(
                name: "Tipo_ImovelId",
                table: "Imovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_Tipo_ImovelId",
                table: "Imovel",
                column: "Tipo_ImovelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imovel_Tipo_Imovel_Tipo_ImovelId",
                table: "Imovel",
                column: "Tipo_ImovelId",
                principalTable: "Tipo_Imovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imovel_Tipo_Imovel_Tipo_ImovelId",
                table: "Imovel");

            migrationBuilder.DropIndex(
                name: "IX_Imovel_Tipo_ImovelId",
                table: "Imovel");

            migrationBuilder.DropColumn(
                name: "Tipo_ImovelId",
                table: "Imovel");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Tipo_Imovel",
                newName: "tipo");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Imovel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
