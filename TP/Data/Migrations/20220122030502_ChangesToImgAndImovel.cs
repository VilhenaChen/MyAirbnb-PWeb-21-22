using Microsoft.EntityFrameworkCore.Migrations;

namespace TP.Data.Migrations
{
    public partial class ChangesToImgAndImovel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagem_Imovel_ImovelId",
                table: "Imagem");

            migrationBuilder.DropIndex(
                name: "IX_Imagem_ImovelId",
                table: "Imagem");

            migrationBuilder.DropColumn(
                name: "ImovelId",
                table: "Imagem");

            migrationBuilder.AddColumn<int>(
                name: "ImagemId",
                table: "Imovel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_ImagemId",
                table: "Imovel",
                column: "ImagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imovel_Imagem_ImagemId",
                table: "Imovel",
                column: "ImagemId",
                principalTable: "Imagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imovel_Imagem_ImagemId",
                table: "Imovel");

            migrationBuilder.DropIndex(
                name: "IX_Imovel_ImagemId",
                table: "Imovel");

            migrationBuilder.DropColumn(
                name: "ImagemId",
                table: "Imovel");

            migrationBuilder.AddColumn<int>(
                name: "ImovelId",
                table: "Imagem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_ImovelId",
                table: "Imagem",
                column: "ImovelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagem_Imovel_ImovelId",
                table: "Imagem",
                column: "ImovelId",
                principalTable: "Imovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
