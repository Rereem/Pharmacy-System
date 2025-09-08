using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy.Services.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_UsageCause_UsageCauseId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UsageCauseId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UsageCauseId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsageCauseId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_UsageCauseId",
                table: "Items",
                column: "UsageCauseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_UsageCause_UsageCauseId",
                table: "Items",
                column: "UsageCauseId",
                principalTable: "UsageCause",
                principalColumn: "Id");
        }
    }
}
