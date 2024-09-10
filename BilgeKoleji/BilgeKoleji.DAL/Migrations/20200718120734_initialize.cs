using Microsoft.EntityFrameworkCore.Migrations;

namespace BilgeKoleji.DAL.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ogrencis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numara = table.Column<int>(nullable: false),
                    Adi = table.Column<string>(nullable: true),
                    Soyadi = table.Column<string>(nullable: true),
                    Cinsiyet = table.Column<string>(nullable: true),
                    DevamDurumu = table.Column<bool>(nullable: true),
                    Sube = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenelTablos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenelTablos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenelTablos_Ogrencis_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrencis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sinifs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(nullable: true),
                    GenelTabloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinifs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sinifs_GenelTablos_GenelTabloId",
                        column: x => x.GenelTabloId,
                        principalTable: "GenelTablos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(nullable: true),
                    SinifId = table.Column<int>(nullable: true),
                    GenelTabloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ders_GenelTablos_GenelTabloId",
                        column: x => x.GenelTabloId,
                        principalTable: "GenelTablos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ders_Sinifs_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Sinifs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(nullable: true),
                    Soyadi = table.Column<string>(nullable: true),
                    BransId = table.Column<int>(nullable: true),
                    GenelTabloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogretmens_Ders_BransId",
                        column: x => x.BransId,
                        principalTable: "Ders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ogretmens_GenelTablos_GenelTabloId",
                        column: x => x.GenelTabloId,
                        principalTable: "GenelTablos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ders_GenelTabloId",
                table: "Ders",
                column: "GenelTabloId");

            migrationBuilder.CreateIndex(
                name: "IX_Ders_SinifId",
                table: "Ders",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_GenelTablos_OgrenciId",
                table: "GenelTablos",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_BransId",
                table: "Ogretmens",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmens_GenelTabloId",
                table: "Ogretmens",
                column: "GenelTabloId");

            migrationBuilder.CreateIndex(
                name: "IX_Sinifs_GenelTabloId",
                table: "Sinifs",
                column: "GenelTabloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ogretmens");

            migrationBuilder.DropTable(
                name: "Ders");

            migrationBuilder.DropTable(
                name: "Sinifs");

            migrationBuilder.DropTable(
                name: "GenelTablos");

            migrationBuilder.DropTable(
                name: "Ogrencis");
        }
    }
}
