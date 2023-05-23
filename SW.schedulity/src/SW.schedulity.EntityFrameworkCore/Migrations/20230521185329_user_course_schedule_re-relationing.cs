using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW.schedulity.Migrations
{
    /// <inheritdoc />
    public partial class user_course_schedule_rerelationing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSchedule");

            migrationBuilder.DropColumn(
                name: "IsPassed",
                table: "AppCourse");

            migrationBuilder.RenameColumn(
                name: "ShceduleTitle",
                table: "AppSchedule",
                newName: "Title");

            migrationBuilder.AddColumn<Guid>(
                name: "UserCourseId",
                table: "AppSchedule",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserCourse",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourse", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UserCourse_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourse_AppCourse_CourseId",
                        column: x => x.CourseId,
                        principalTable: "AppCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourse_AppSchedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "AppSchedule",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_CourseId",
                table: "UserCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourse_ScheduleId",
                table: "UserCourse",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCourse");

            migrationBuilder.DropColumn(
                name: "UserCourseId",
                table: "AppSchedule");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "AppSchedule",
                newName: "ShceduleTitle");

            migrationBuilder.AddColumn<bool>(
                name: "IsPassed",
                table: "AppCourse",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                name: "IX_CourseSchedule_ShcedulesId",
                table: "CourseSchedule",
                column: "ShcedulesId");
        }
    }
}
