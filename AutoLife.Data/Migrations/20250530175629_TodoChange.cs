using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLife.Data.Migrations
{
    /// <inheritdoc />
    public partial class TodoChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_UserProfiles_UserProfileId",
                table: "ToDoItems");

            migrationBuilder.DropTable(
                name: "WeeklyPlanItems");

            migrationBuilder.DropTable(
                name: "WeeklyPlans");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "ToDoItems",
                newName: "AssignedPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoItems_UserProfileId",
                table: "ToDoItems",
                newName: "IX_ToDoItems_AssignedPersonId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ToDoItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WhenToDo",
                table: "ToDoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_UserProfiles_AssignedPersonId",
                table: "ToDoItems",
                column: "AssignedPersonId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_UserProfiles_AssignedPersonId",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "WhenToDo",
                table: "ToDoItems");

            migrationBuilder.RenameColumn(
                name: "AssignedPersonId",
                table: "ToDoItems",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDoItems_AssignedPersonId",
                table: "ToDoItems",
                newName: "IX_ToDoItems_UserProfileId");

            migrationBuilder.CreateTable(
                name: "WeeklyPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyPlanItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeeklyPlanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyPlanItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyPlanItems_UserProfiles_AssignedPersonId",
                        column: x => x.AssignedPersonId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeeklyPlanItems_WeeklyPlans_WeeklyPlanId",
                        column: x => x.WeeklyPlanId,
                        principalTable: "WeeklyPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanItems_AssignedPersonId",
                table: "WeeklyPlanItems",
                column: "AssignedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyPlanItems_WeeklyPlanId",
                table: "WeeklyPlanItems",
                column: "WeeklyPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_UserProfiles_UserProfileId",
                table: "ToDoItems",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }
    }
}
