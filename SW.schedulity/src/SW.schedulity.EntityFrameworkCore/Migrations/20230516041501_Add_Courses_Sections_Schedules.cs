using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW.schedulity.Migrations
{
    /// <inheritdoc />
    public partial class Add_Courses_Sections_Schedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShceduleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfHours = table.Column<int>(type: "int", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false),
                    SectionType = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCourse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfHours = table.Column<int>(type: "int", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseType = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCourse_AppSection_SectionId",
                        column: x => x.SectionId,
                        principalTable: "AppSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSchedule",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShcedulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedule", x => new { x.CoursesId, x.ShcedulesId });
                    table.ForeignKey(
                        name: "FK_CourseSchedule_AppCourse_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "AppCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_AppSchedule_ShcedulesId",
                        column: x => x.ShcedulesId,
                        principalTable: "AppSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCourse_SectionId",
                table: "AppCourse",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_ShcedulesId",
                table: "CourseSchedule",
                column: "ShcedulesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSchedule");

            migrationBuilder.DropTable(
                name: "AppCourse");

            migrationBuilder.DropTable(
                name: "AppSchedule");

            migrationBuilder.DropTable(
                name: "AppSection");
        }
    }
}
