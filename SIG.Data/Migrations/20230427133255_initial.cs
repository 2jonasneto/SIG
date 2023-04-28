using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIG.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Processor = table.Column<string>(type: "Varchar(100)", nullable: false),
                    MemoryType = table.Column<int>(type: "int", nullable: false),
                    DiskType = table.Column<int>(type: "int", nullable: false),
                    DiskSize = table.Column<int>(type: "int", nullable: false),
                    MemorySize = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "Varchar(100)", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "Varchar(100)", nullable: false),
                    SerialNumber = table.Column<string>(type: "Varchar(100)", nullable: false),
                    LocacityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocacityName = table.Column<string>(type: "Varchar(100)", nullable: false),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaName = table.Column<string>(type: "Varchar(100)", nullable: false),
                    SectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectorName = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "Varchar(100)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");
        }
    }
}
