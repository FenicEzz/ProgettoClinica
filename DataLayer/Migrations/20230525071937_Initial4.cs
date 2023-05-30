using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Pets_PetId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Recoveries_Pets_PetId",
                table: "Recoveries");

            migrationBuilder.DropIndex(
                name: "IX_Recoveries_PetId",
                table: "Recoveries");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Recoveries");

            migrationBuilder.AlterColumn<long>(
                name: "PetId",
                table: "Examinations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AcceptanceId",
                table: "Examinations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_AcceptanceId",
                table: "Examinations",
                column: "AcceptanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Acceptances_AcceptanceId",
                table: "Examinations",
                column: "AcceptanceId",
                principalTable: "Acceptances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Pets_PetId",
                table: "Examinations",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Acceptances_AcceptanceId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Pets_PetId",
                table: "Examinations");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_AcceptanceId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "AcceptanceId",
                table: "Examinations");

            migrationBuilder.AddColumn<long>(
                name: "PetId",
                table: "Recoveries",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PetId",
                table: "Examinations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recoveries_PetId",
                table: "Recoveries",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Pets_PetId",
                table: "Examinations",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recoveries_Pets_PetId",
                table: "Recoveries",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }
    }
}
