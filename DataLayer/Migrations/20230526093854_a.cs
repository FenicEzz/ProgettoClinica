using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recoveries_Examinations_ExaminationId",
                table: "Recoveries");

            migrationBuilder.RenameColumn(
                name: "ExaminationId",
                table: "Recoveries",
                newName: "PetId");

            migrationBuilder.RenameIndex(
                name: "IX_Recoveries_ExaminationId",
                table: "Recoveries",
                newName: "IX_Recoveries_PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recoveries_Pets_PetId",
                table: "Recoveries",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recoveries_Pets_PetId",
                table: "Recoveries");

            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "Recoveries",
                newName: "ExaminationId");

            migrationBuilder.RenameIndex(
                name: "IX_Recoveries_PetId",
                table: "Recoveries",
                newName: "IX_Recoveries_ExaminationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recoveries_Examinations_ExaminationId",
                table: "Recoveries",
                column: "ExaminationId",
                principalTable: "Examinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
