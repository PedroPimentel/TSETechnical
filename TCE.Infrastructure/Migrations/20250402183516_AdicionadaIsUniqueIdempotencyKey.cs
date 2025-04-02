using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadaIsUniqueIdempotencyKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdempotencyKey",
                table: "Compra",
                column: "IdempotencyKey",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Compra_IdempotencyKey",
                table: "Compra");
        }
    }
}
