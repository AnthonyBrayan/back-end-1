using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addTableTypeUser3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_TypeUsuario_TypeUsuarioId_TypeUser",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_TypeUsuarioId_TypeUser",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TypeUsuarioId_TypeUser",
                table: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdTypeUsuario",
                table: "Customer",
                column: "IdTypeUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_TypeUsuario_IdTypeUsuario",
                table: "Customer",
                column: "IdTypeUsuario",
                principalTable: "TypeUsuario",
                principalColumn: "Id_TypeUser",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_TypeUsuario_IdTypeUsuario",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_IdTypeUsuario",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "TypeUsuarioId_TypeUser",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TypeUsuarioId_TypeUser",
                table: "Customer",
                column: "TypeUsuarioId_TypeUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_TypeUsuario_TypeUsuarioId_TypeUser",
                table: "Customer",
                column: "TypeUsuarioId_TypeUser",
                principalTable: "TypeUsuario",
                principalColumn: "Id_TypeUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
