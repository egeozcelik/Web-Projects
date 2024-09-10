using Microsoft.EntityFrameworkCore.Migrations;

namespace BilgeKoleji.DAL.Migrations
{
    public partial class hadiins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kontenjan",
                table: "Sinifs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cinsiyet",
                table: "Ogretmens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Yas",
                table: "Ogretmens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Yas",
                table: "Ogrencis",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kontenjan",
                table: "Sinifs");

            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "Yas",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "Yas",
                table: "Ogrencis");
        }
    }
}
