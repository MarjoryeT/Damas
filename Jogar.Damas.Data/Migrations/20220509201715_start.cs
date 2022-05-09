using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jogar.Damas.Data.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(type: "uuid", nullable: false),
                    USER_NAME = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    START_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PHONE = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.USER_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}
