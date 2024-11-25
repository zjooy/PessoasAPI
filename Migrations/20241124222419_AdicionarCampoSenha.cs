using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastroPessoas.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCampoSenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DT_Aniversario",
                table: "Pessoas");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Pessoas");

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_Aniversario",
                table: "Pessoas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
