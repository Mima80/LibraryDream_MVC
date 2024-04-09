using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class added_return_date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "ReturnDate",
                table: "BookCheckouts",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "BookCheckouts",
                keyColumn: "CheckoutId",
                keyValue: 1,
                column: "ReturnDate",
                value: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "BookCheckouts",
                keyColumn: "CheckoutId",
                keyValue: 2,
                column: "ReturnDate",
                value: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "BookCheckouts");
        }
    }
}
