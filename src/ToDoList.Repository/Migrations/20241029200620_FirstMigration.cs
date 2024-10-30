using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    IdGroup = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Inserted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.IdGroup);
                });

            migrationBuilder.CreateTable(
                name: "Checklists",
                columns: table => new
                {
                    IdChecklist = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Inserted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklists", x => x.IdChecklist);
                    table.ForeignKey(
                        name: "FK_Checklists_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "IdGroup");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    IdItem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Remind = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Important = table.Column<bool>(type: "bit", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ChecklistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Inserted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_Items_Checklists_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklists",
                        principalColumn: "IdChecklist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "IdGroup", "Inserted", "Name" },
                values: new object[,]
                {
                    { new Guid("3ac8ebfa-efb0-4802-84b7-d66eeb06b0dc"), new DateTime(2024, 10, 29, 17, 6, 19, 845, DateTimeKind.Local).AddTicks(6068), "School" },
                    { new Guid("6d88fd70-53d7-4594-b6ab-490c158b7114"), new DateTime(2024, 10, 29, 17, 6, 19, 845, DateTimeKind.Local).AddTicks(6071), "Home" },
                    { new Guid("9c97e004-9bc1-4922-b00a-194ab26bf6dc"), new DateTime(2024, 10, 29, 17, 6, 19, 845, DateTimeKind.Local).AddTicks(6065), "Work" },
                    { new Guid("f6461cb4-e9af-4a54-b669-4a55cb3fcb5f"), new DateTime(2024, 10, 29, 17, 6, 19, 845, DateTimeKind.Local).AddTicks(6060), "Shopping" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_GroupId",
                table: "Checklists",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ChecklistId",
                table: "Items",
                column: "ChecklistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Checklists");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
