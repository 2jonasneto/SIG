using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIG.Data.Migrations
{
    /// <inheritdoc />
    public partial class adjustcomputerEntityLocacityrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Locacities_LocacityId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_LocacityId",
                table: "Computers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Computers_LocacityId",
                table: "Computers",
                column: "LocacityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Locacities_LocacityId",
                table: "Computers",
                column: "LocacityId",
                principalTable: "Locacities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
