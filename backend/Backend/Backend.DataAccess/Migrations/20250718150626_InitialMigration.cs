using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    apellido = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuID);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "usuID", "nombre", "apellido" },
                values: new object[,]
                {
                    { 1m, "Andres", "Rodriguez Vera" },
                    { 2m, "Jose", "Giraldo Perez" },
                    { 3m, "Ana", "Martinez Garcia" },
                    { 4m, "Carlos", "Lopez Fernandez" },
                    { 5m, "Maria", "Sanchez Torres" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
