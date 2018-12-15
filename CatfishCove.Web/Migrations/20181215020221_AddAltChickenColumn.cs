using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CatfishCove.Web.Migrations
{
    public partial class AddAltChickenColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("BuffetRotatingWeeks", newName: "BuffetRotatingWeeks_Migration");

            migrationBuilder.Sql("INSERT INTO FoodTypes (Name) " +
                                 "VALUES ('Alt Chicken')");

            migrationBuilder.Sql("INSERT INTO BuffetItems (FoodTypeId, Name, RotationFrequency, Description) " +
                                 "VALUES (19, 'Chicken and Dumplings', 1, '')");

            migrationBuilder.Sql("INSERT INTO BuffetSchedules (BuffetItemId, FoodTypeId, NextItemId) " +
                                 "VALUES (31, 19, NULL)");

            migrationBuilder.Sql("INSERT INTO BuffetSchedules (BuffetItemId, FoodTypeId, NextItemId) " +
                                 "VALUES (26, 19, 16)");

            migrationBuilder.Sql("UPDATE BuffetSchedules " +
                                 "SET NextItemId = 17 " +
                                 "WHERE Id = 16 ");

            migrationBuilder.Sql("UPDATE BuffetItems " +
                                 "SET RotationFrequency = 1, FoodTypeId = 19 " +
                                 "WHERE Id = 26 ");

            migrationBuilder.CreateTable(
                name: "BuffetRotatingWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeansId = table.Column<int>(type: "INTEGER", nullable: false),
                    CasseroleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CornId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeatId = table.Column<int>(type: "INTEGER", nullable: false),
                    AltChickenId = table.Column<int>(type: "INTEGER", nullable: false),
                    SundayDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffetRotatingWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuffetRotatingWeeks_BuffetSchedules_BeansId",
                        column: x => x.BeansId,
                        principalTable: "BuffetSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuffetRotatingWeeks_BuffetSchedules_CasseroleId",
                        column: x => x.CasseroleId,
                        principalTable: "BuffetSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuffetRotatingWeeks_BuffetSchedules_CornId",
                        column: x => x.CornId,
                        principalTable: "BuffetSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuffetRotatingWeeks_BuffetSchedules_MeatId",
                        column: x => x.MeatId,
                        principalTable: "BuffetSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuffetRotatingWeeks_BuffetSchedules_AltChickenIdId",
                        column: x => x.AltChickenId,
                        principalTable: "BuffetSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.Sql("INSERT INTO BuffetRotatingWeeks " +
                                 "SELECT Id, BeansId, CasseroleId, CornId, MeatId, 17, SundayDate " +
                                 "FROM BuffetRotatingWeeks_Migration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuffetRotatingWeeks_BuffetSchedules_AltChickenId",
                table: "BuffetRotatingWeeks");

            migrationBuilder.DropIndex(
                name: "IX_BuffetRotatingWeeks_AltChickenId",
                table: "BuffetRotatingWeeks");

            migrationBuilder.DropColumn(
                name: "AltChickenId",
                table: "BuffetRotatingWeeks");
        }
    }
}
