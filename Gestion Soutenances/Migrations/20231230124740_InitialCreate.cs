using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestion_Soutenances.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateNaiss = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Societe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lib = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PFE",
                columns: table => new
                {
                    PFEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    desc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateF = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncadrantId = table.Column<int>(type: "int", nullable: false),
                    EnseignantId = table.Column<int>(type: "int", nullable: true),
                    SocieteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFE", x => x.PFEID);
                    table.ForeignKey(
                        name: "FK_PFE_Enseignant_EnseignantId",
                        column: x => x.EnseignantId,
                        principalTable: "Enseignant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PFE_Societe_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "Societe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PFE_Etudiant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtudiantId = table.Column<int>(type: "int", nullable: false),
                    PFEID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFE_Etudiant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PFE_Etudiant_Etudiant_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PFE_Etudiant_PFE_PFEID",
                        column: x => x.PFEID,
                        principalTable: "PFE",
                        principalColumn: "PFEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PFE_EnseignantId",
                table: "PFE",
                column: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_SocieteId",
                table: "PFE",
                column: "SocieteId");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_Etudiant_EtudiantId",
                table: "PFE_Etudiant",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_Etudiant_PFEID",
                table: "PFE_Etudiant",
                column: "PFEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PFE_Etudiant");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "PFE");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Societe");
        }
    }
}
