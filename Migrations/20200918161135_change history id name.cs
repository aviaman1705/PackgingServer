﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PackgingAPI.Migrations
{
    public partial class changehistoryidname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Histories",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "tId",
                table: "Histories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Histories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Histories",
                table: "Histories",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Histories",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Histories");

            migrationBuilder.AddColumn<int>(
                name: "tId",
                table: "Histories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Histories",
                table: "Histories",
                column: "tId");
        }
    }
}
