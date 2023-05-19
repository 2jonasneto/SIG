using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIG.Data.Migrations
{
    /// <inheritdoc />
    public partial class _180520232134 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Computers");

            migrationBuilder.CreateTable(
                name: "Brand",
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
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipType",
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
                    table.PrimaryKey("PK_EquipType", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "EquipType");

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "Computers",
                type: "Varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Computers",
                type: "Varchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
