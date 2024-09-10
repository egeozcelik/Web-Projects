using Microsoft.EntityFrameworkCore.Migrations;

namespace BilgeKoleji.DAL.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SinifId",
                table: "Ogrencis",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ogrencis_SinifId",
                table: "Ogrencis",
                column: "SinifId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrencis_Sinifs_SinifId",
                table: "Ogrencis",
                column: "SinifId",
                principalTable: "Sinifs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogrencis_Sinifs_SinifId",
                table: "Ogrencis");

            migrationBuilder.DropIndex(
                name: "IX_Ogrencis_SinifId",
                table: "Ogrencis");

            migrationBuilder.DropColumn(
                name: "SinifId",
                table: "Ogrencis");
        }
    }
}
