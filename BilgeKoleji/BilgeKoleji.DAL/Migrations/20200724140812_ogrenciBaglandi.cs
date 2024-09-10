using Microsoft.EntityFrameworkCore.Migrations;

namespace BilgeKoleji.DAL.Migrations
{
    public partial class ogrenciBaglandi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sube",
                table: "Ogrencis");

            migrationBuilder.AddColumn<int>(
                name: "SubeId",
                table: "Ogrencis",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ogrencis_Sinifs_SubeId",
                table: "Ogrencis");

            migrationBuilder.DropIndex(
                name: "IX_Ogrencis_SubeId",
                table: "Ogrencis");

            migrationBuilder.DropColumn(
                name: "SubeId",
                table: "Ogrencis");

            migrationBuilder.AddColumn<string>(
                name: "Sube",
                table: "Ogrencis",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
