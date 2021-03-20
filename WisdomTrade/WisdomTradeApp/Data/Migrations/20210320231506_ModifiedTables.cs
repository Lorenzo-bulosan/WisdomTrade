using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WisdomTradeApp.Data.Migrations
{
    public partial class ModifiedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageLowerLimit",
                table: "WisdomTrade");

            migrationBuilder.DropColumn(
                name: "AverageUpperLimit",
                table: "WisdomTrade");

            migrationBuilder.DropColumn(
                name: "FinalDirection",
                table: "WisdomTrade");

            migrationBuilder.DropColumn(
                name: "CloseDateTime",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "LowerLimit",
                table: "Positions");

            migrationBuilder.RenameColumn(
                name: "TotalCredit",
                table: "WisdomTrade",
                newName: "FinalPricePrediction");

            migrationBuilder.RenameColumn(
                name: "UpperLimit",
                table: "Positions",
                newName: "PricePrediction");

            migrationBuilder.RenameColumn(
                name: "OpenDateTime",
                table: "Positions",
                newName: "Date");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "WisdomTrade",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "WisdomTrade");

            migrationBuilder.RenameColumn(
                name: "FinalPricePrediction",
                table: "WisdomTrade",
                newName: "TotalCredit");

            migrationBuilder.RenameColumn(
                name: "PricePrediction",
                table: "Positions",
                newName: "UpperLimit");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Positions",
                newName: "OpenDateTime");

            migrationBuilder.AddColumn<float>(
                name: "AverageLowerLimit",
                table: "WisdomTrade",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "AverageUpperLimit",
                table: "WisdomTrade",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "FinalDirection",
                table: "WisdomTrade",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CloseDateTime",
                table: "Positions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "Credit",
                table: "Positions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Direction",
                table: "Positions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "LowerLimit",
                table: "Positions",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
