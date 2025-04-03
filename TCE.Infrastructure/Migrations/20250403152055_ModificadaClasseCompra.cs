using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModificadaClasseCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorDevido",
                table: "Compra",
                newName: "ValorCompra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorCompra",
                table: "Compra",
                newName: "ValorDevido");
        }
    }
}
