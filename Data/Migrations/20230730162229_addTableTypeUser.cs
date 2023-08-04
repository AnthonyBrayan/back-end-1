using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addTableTypeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTypeUsuario",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeUsuarioId_TypeUser",
                table: "Supplier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTypeUsuario",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeUsuarioId_TypeUser",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeUsuario",
                columns: table => new
                {
                    Id_TypeUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeUser_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeUsuario", x => x.Id_TypeUser);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_TypeUsuarioId_TypeUser",
                table: "Supplier",
                column: "TypeUsuarioId_TypeUser");

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_TypeUsuario_TypeUsuarioId_TypeUser",
                table: "Supplier",
                column: "TypeUsuarioId_TypeUser",
                principalTable: "TypeUsuario",
                principalColumn: "Id_TypeUser",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_TypeUsuario_TypeUsuarioId_TypeUser",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_TypeUsuario_TypeUsuarioId_TypeUser",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "TypeUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_TypeUsuarioId_TypeUser",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Customer_TypeUsuarioId_TypeUser",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IdTypeUsuario",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "TypeUsuarioId_TypeUser",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IdTypeUsuario",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TypeUsuarioId_TypeUser",
                table: "Customer");
        }
    }
}
