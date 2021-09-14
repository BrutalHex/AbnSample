using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Abn.Analytics.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusObject",
                columns: table => new
                {
                    StatusObject_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusObject_Status = table.Column<int>(type: "int", nullable: false),
                    StatusObject_Progress = table.Column<int>(type: "int", nullable: false),
                    StatusObject_Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusObject_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusObject_Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusObject", x => x.StatusObject_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusObject");
        }
    }
}
