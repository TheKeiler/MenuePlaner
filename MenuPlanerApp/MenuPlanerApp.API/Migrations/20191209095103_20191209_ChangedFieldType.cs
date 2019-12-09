﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuPlanerApp.API.Migrations
{
    public partial class _20191209_ChangedFieldType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                "Amount",
                "IngredientWithAmount",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                "Amount",
                "IngredientWithAmount",
                "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}