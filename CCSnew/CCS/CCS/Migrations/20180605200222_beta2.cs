using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CCS.Migrations
{
    public partial class beta2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MsgDays",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjDays",
                table: "Settings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WelcomeMessage",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Project",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MsgDays",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ProjDays",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "WelcomeMessage",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Project");
        }
    }
}
