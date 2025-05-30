using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class TodoChangeAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_UserProfiles_AssignedPersonId",
                table: "ToDoItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssignedPersonId",
                table: "ToDoItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_UserProfiles_AssignedPersonId",
                table: "ToDoItems",
                column: "AssignedPersonId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_UserProfiles_AssignedPersonId",
                table: "ToDoItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssignedPersonId",
                table: "ToDoItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_UserProfiles_AssignedPersonId",
                table: "ToDoItems",
                column: "AssignedPersonId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }
    }
}
