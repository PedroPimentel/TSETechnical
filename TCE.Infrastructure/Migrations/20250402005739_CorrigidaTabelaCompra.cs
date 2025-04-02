using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrigidaTabelaCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Cliente_ClienteId1",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_ClienteId1",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "Compra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId1",
                table: "Compra",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ClienteId1",
                table: "Compra",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Cliente_ClienteId1",
                table: "Compra",
                column: "ClienteId1",
                principalTable: "Cliente",
                principalColumn: "Id");
        }
    }
}
