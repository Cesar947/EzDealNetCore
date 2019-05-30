using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UPCService.Migrations
{
    public partial class AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Distritos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distritos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublicistaId = table.Column<int>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    CostoServicio = table.Column<int>(nullable: false),
                    ServicioId = table.Column<int>(nullable: true),
                    EstaHabilitado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Usuarios_PublicistaId",
                        column: x => x.PublicistaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reseñas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublicacionId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    Contenido = table.Column<string>(nullable: true),
                    Valoracion = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reseñas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reseñas_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reseñas_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublicacionId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    Mensaje = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DistritoId",
                table: "Usuarios",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_PublicistaId",
                table: "Publicaciones",
                column: "PublicistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_ServicioId",
                table: "Publicaciones",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_ClienteId",
                table: "Reseñas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_PublicacionId",
                table: "Reseñas",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_ClienteId",
                table: "Solicitudes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_PublicacionId",
                table: "Solicitudes",
                column: "PublicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Distritos_DistritoId",
                table: "Usuarios",
                column: "DistritoId",
                principalTable: "Distritos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Distritos_DistritoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Distritos");

            migrationBuilder.DropTable(
                name: "Reseñas");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DistritoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "Usuarios");
        }
    }
}
