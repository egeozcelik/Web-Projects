using Microsoft.EntityFrameworkCore.Migrations;

namespace BilgeKoleji.DAL.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogrencis_Sinifs_SubeId",
                table: "Ogrencis");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogretmens_Ders_BransId",
                table: "Ogretmens");

            migrationBuilder.DropIndex(
                name: "IX_Ogretmens_BransId",
                table: "Ogretmens");

            migrationBuilder.DropIndex(
                name: "IX_Ogrencis_SubeId",
                table: "Ogrencis");

            migrationBuilder.DropColumn(
                name: "BransId",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "SubeId",
                table: "Ogrencis");

            migrationBuilder.AddColumn<int>(
                name: "DersId",
                table: "Ogretmens",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_DersId",
                table: "Ogretmens",
                column: "DersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogretmens_Ders_DersId",
                table: "Ogretmens",
                column: "DersId",
                principalTable: "Ders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogretmens_Ders_DersId",
                table: "Ogretmens");

            migrationBuilder.DropIndex(
                name: "IX_Ogretmens_DersId",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "DersId",
                table: "Ogretmens");

            migrationBuilder.AddColumn<int>(
                name: "BransId",
                table: "Ogretmens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubeId",
                table: "Ogrencis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_BransId",
                table: "Ogretmens",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrencis_SubeId",
                table: "Ogrencis",
                column: "SubeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrencis_Sinifs_SubeId",
                table: "Ogrencis",
                column: "SubeId",
                principalTable: "Sinifs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ogretmens_Ders_BransId",
                table: "Ogretmens",
                column: "BransId",
                principalTable: "Ders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
