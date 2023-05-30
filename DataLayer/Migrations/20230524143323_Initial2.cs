using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PetId",
                table: "Recoveries",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recoveries_PetId",
                table: "Recoveries",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recoveries_Pets_PetId",
                table: "Recoveries",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recoveries_Pets_PetId",
                table: "Recoveries");

            migrationBuilder.DropIndex(
                name: "IX_Recoveries_PetId",
                table: "Recoveries");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Recoveries");
        }
    }
}
