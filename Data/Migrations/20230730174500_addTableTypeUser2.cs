using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addTableTypeUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_TypeUsuario_TypeUsuarioId_TypeUser",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_TypeUsuarioId_TypeUser",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "TypeUsuarioId_TypeUser",
                table: "Supplier");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_IdTypeUsuario",
                table: "Supplier",
                column: "IdTypeUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_TypeUsuario_IdTypeUsuario",
                table: "Supplier",
                column: "IdTypeUsuario",
                principalTable: "TypeUsuario",
                principalColumn: "Id_TypeUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_TypeUsuario_IdTypeUsuario",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_IdTypeUsuario",
                table: "Supplier");

            migrationBuilder.AddColumn<int>(
                name: "TypeUsuarioId_TypeUser",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_TypeUsuarioId_TypeUser",
                table: "Supplier",
                column: "TypeUsuarioId_TypeUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_TypeUsuario_TypeUsuarioId_TypeUser",
                table: "Supplier",
                column: "TypeUsuarioId_TypeUser",
                principalTable: "TypeUsuario",
                principalColumn: "Id_TypeUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
