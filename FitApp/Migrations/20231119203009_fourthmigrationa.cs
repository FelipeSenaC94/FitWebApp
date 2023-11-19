using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitApp.Migrations
{
    public partial class fourthmigrationa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Usuarios_UserId",
                table: "Registros");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Usuarios_UserId",
                table: "Registros",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Usuarios_UserId",
                table: "Registros");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Usuarios_UserId",
                table: "Registros",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "UserId");
        }
    }
}
