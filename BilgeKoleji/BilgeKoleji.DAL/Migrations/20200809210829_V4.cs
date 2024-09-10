using Microsoft.EntityFrameworkCore.Migrations;

namespace BilgeKoleji.DAL.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ders_Sinifs_SinifId",
                table: "Ders");

            migrationBuilder.AlterColumn<int>(
                name: "SinifId",
                table: "Ders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ders_Sinifs_SinifId",
                table: "Ders",
                column: "SinifId",
                principalTable: "Sinifs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ders_Sinifs_SinifId",
                table: "Ders");

            migrationBuilder.AlterColumn<int>(
                name: "SinifId",
                table: "Ders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ders_Sinifs_SinifId",
                table: "Ders",
                column: "SinifId",
                principalTable: "Sinifs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
