using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CatfishCove.Web.Migrations
{
    public partial class AddUniqueConstraintToSunday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BuffetRotatingWeeks_SundayDate",
                table: "BuffetRotatingWeeks",
                column: "SundayDate",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BuffetRotatingWeeks_SundayDate",
                table: "BuffetRotatingWeeks");
        }
    }
}
