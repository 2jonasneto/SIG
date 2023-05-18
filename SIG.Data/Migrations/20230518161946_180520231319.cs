using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIG.Data.Migrations
{
    /// <inheritdoc />
    public partial class _180520231319 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "LocacityName",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "SectorName",
                table: "Computers");

            migrationBuilder.CreateTable(
                name: "ActingAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActingAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locacities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ActingAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedBy = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locacities_ActingAreas_ActingAreaId",
                        column: x => x.ActingAreaId,
                        principalTable: "ActingAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_LocacityId",
                table: "Computers",
                column: "LocacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locacities_ActingAreaId",
                table: "Locacities",
                column: "ActingAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Locacities_LocacityId",
                table: "Computers",
                column: "LocacityId",
                principalTable: "Locacities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Locacities_LocacityId",
                table: "Computers");

            migrationBuilder.DropTable(
                name: "Locacities");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "ActingAreas");

            migrationBuilder.DropIndex(
                name: "IX_Computers_LocacityId",
                table: "Computers");

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                table: "Computers",
                type: "Varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocacityName",
                table: "Computers",
                type: "Varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SectorName",
                table: "Computers",
                type: "Varchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
