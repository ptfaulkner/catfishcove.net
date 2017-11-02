using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CatfishCove.Web.Data.Migrations
{
    public partial class AddFoodEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MenuOrder = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuffetItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RotationFrequency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuffetItems_FoodTypes_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodTypeId = table.Column<int>(type: "int", nullable: false),
                    HalfOrderPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WholeOrderPrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_FoodTypes_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuffetSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuffetItemId = table.Column<int>(type: "int", nullable: true),
                    FoodTypeId = table.Column<int>(type: "int", nullable: true),
                    NextItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffetSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuffetSchedules_BuffetItems_BuffetItemId",
                        column: x => x.BuffetItemId,
                        principalTable: "BuffetItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuffetSchedules_FoodTypes_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuffetSchedules_BuffetSchedules_NextItemId",
                        column: x => x.NextItemId,
                        principalTable: "BuffetSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuffetRotatingWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeansId = table.Column<int>(type: "int", nullable: false),
                    CasseroleId = table.Column<int>(type: "int", nullable: false),
                    CornId = table.Column<int>(type: "int", nullable: false),
                    MeatId = table.Column<int>(type: "int", nullable: false),
                    SundayDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BuffetItems_FoodTypeId",
                table: "BuffetItems",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffetRotatingWeeks_BeansId",
                table: "BuffetRotatingWeeks",
                column: "BeansId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffetRotatingWeeks_CasseroleId",
                table: "BuffetRotatingWeeks",
                column: "CasseroleId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffetRotatingWeeks_CornId",
                table: "BuffetRotatingWeeks",
                column: "CornId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffetRotatingWeeks_MeatId",
                table: "BuffetRotatingWeeks",
                column: "MeatId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffetSchedules_BuffetItemId",
                table: "BuffetSchedules",
                column: "BuffetItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffetSchedules_FoodTypeId",
                table: "BuffetSchedules",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffetSchedules_NextItemId",
                table: "BuffetSchedules",
                column: "NextItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_FoodTypeId",
                table: "MenuItems",
                column: "FoodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BuffetRotatingWeeks");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "BuffetSchedules");

            migrationBuilder.DropTable(
                name: "BuffetItems");

            migrationBuilder.DropTable(
                name: "FoodTypes");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
