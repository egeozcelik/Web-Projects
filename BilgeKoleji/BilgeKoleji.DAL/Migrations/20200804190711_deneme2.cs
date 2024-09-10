using Microsoft.EntityFrameworkCore.Migrations;

namespace BilgeKoleji.DAL.Migrations
{
    public partial class deneme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ders_GenelTablos_GenelTabloId",
                table: "Ders");

            migrationBuilder.DropForeignKey(
                name: "FK_GenelTablos_Ogrencis_OgrenciId",
                table: "GenelTablos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogretmens_GenelTablos_GenelTabloId",
                table: "Ogretmens");

            migrationBuilder.DropForeignKey(
                name: "FK_Sinifs_GenelTablos_GenelTabloId",
                table: "Sinifs");

            migrationBuilder.DropIndex(
                name: "IX_Sinifs_GenelTabloId",
                table: "Sinifs");

            migrationBuilder.DropIndex(
                name: "IX_Ogretmens_GenelTabloId",
                table: "Ogretmens");

            migrationBuilder.DropIndex(
                name: "IX_GenelTablos_OgrenciId",
                table: "GenelTablos");

            migrationBuilder.DropIndex(
                name: "IX_Ders_GenelTabloId",
                table: "Ders");

            migrationBuilder.DropColumn(
                name: "GenelTabloId",
                table: "Sinifs");

            migrationBuilder.DropColumn(
                name: "GenelTabloId",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "OgrenciId",
                table: "GenelTablos");

            migrationBuilder.DropColumn(
                name: "GenelTabloId",
                table: "Ders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenelTabloId",
                table: "Sinifs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenelTabloId",
                table: "Ogretmens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OgrenciId",
                table: "GenelTablos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenelTabloId",
                table: "Ders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sinifs_GenelTabloId",
                table: "Sinifs",
                column: "GenelTabloId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_GenelTabloId",
                table: "Ogretmens",
                column: "GenelTabloId");

            migrationBuilder.CreateIndex(
                name: "IX_GenelTablos_OgrenciId",
                table: "GenelTablos",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_Ders_GenelTabloId",
                table: "Ders",
                column: "GenelTabloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ders_GenelTablos_GenelTabloId",
                table: "Ders",
                column: "GenelTabloId",
                principalTable: "GenelTablos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenelTablos_Ogrencis_OgrenciId",
                table: "GenelTablos",
                column: "OgrenciId",
                principalTable: "Ogrencis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ogretmens_GenelTablos_GenelTabloId",
                table: "Ogretmens",
                column: "GenelTabloId",
                principalTable: "GenelTablos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sinifs_GenelTablos_GenelTabloId",
                table: "Sinifs",
                column: "GenelTabloId",
                principalTable: "GenelTablos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
