using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class bettertables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Pilots_LeaderId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeaderId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LeaderId",
                table: "Teams");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Teams",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Leader",
                table: "Pilots",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Leader",
                table: "Pilots");

            migrationBuilder.AlterColumn<int>(
                name: "Color",
                table: "Teams",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "LeaderId",
                table: "Teams",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeaderId",
                table: "Teams",
                column: "LeaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Pilots_LeaderId",
                table: "Teams",
                column: "LeaderId",
                principalTable: "Pilots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
