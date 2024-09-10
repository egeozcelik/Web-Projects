using Microsoft.EntityFrameworkCore.Migrations;

namespace BilgeKoleji.DAL.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cinsiyet",
                table: "Ogretmens",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Ogretmens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Ogretmens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TCK",
                table: "Ogretmens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Ogrencis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Ogrencis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TCK",
                table: "Ogrencis",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "TCK",
                table: "Ogretmens");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Ogrencis");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Ogrencis");

            migrationBuilder.DropColumn(
                name: "TCK",
                table: "Ogrencis");

            migrationBuilder.AlterColumn<int>(
                name: "Cinsiyet",
                table: "Ogretmens",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
