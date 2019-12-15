using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SWESTPAPI.Migrations
{
    public partial class Modelsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appUsers",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    VCode = table.Column<string>(nullable: true),
                    isVerified = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appUsers", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    CourseCode = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CourseCode);
                });

            migrationBuilder.CreateTable(
                name: "slots",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slots", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sweEvents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    AttachmentUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sweEvents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "myTasks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myTasks", x => x.id);
                    table.ForeignKey(
                        name: "FK_myTasks_appUsers_Email",
                        column: x => x.Email,
                        principalTable: "appUsers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Semester = table.Column<int>(nullable: false),
                    Section = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Profile_appUsers_Email",
                        column: x => x.Email,
                        principalTable: "appUsers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userCourses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Section = table.Column<string>(nullable: true),
                    CourseCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCourses", x => x.id);
                    table.ForeignKey(
                        name: "FK_userCourses_courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userCourses_appUsers_Email",
                        column: x => x.Email,
                        principalTable: "appUsers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "classRoutines",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Section = table.Column<string>(nullable: true),
                    Day = table.Column<string>(nullable: true),
                    TeacherInitial = table.Column<string>(nullable: true),
                    RoomNo = table.Column<string>(nullable: true),
                    CourseCode = table.Column<string>(nullable: true),
                    SlotID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classRoutines", x => x.id);
                    table.ForeignKey(
                        name: "FK_classRoutines_courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_classRoutines_slots_SlotID",
                        column: x => x.SlotID,
                        principalTable: "slots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "examRoutines",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    CourseCode = table.Column<string>(nullable: true),
                    SlotID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_examRoutines", x => x.id);
                    table.ForeignKey(
                        name: "FK_examRoutines_courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_examRoutines_slots_SlotID",
                        column: x => x.SlotID,
                        principalTable: "slots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courseOffers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    semester = table.Column<int>(nullable: false),
                    CourseCode = table.Column<string>(nullable: true),
                    ExamRoutineid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseOffers", x => x.id);
                    table.ForeignKey(
                        name: "FK_courseOffers_courses_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_courseOffers_examRoutines_ExamRoutineid",
                        column: x => x.ExamRoutineid,
                        principalTable: "examRoutines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classRoutines_CourseCode",
                table: "classRoutines",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_classRoutines_SlotID",
                table: "classRoutines",
                column: "SlotID");

            migrationBuilder.CreateIndex(
                name: "IX_courseOffers_CourseCode",
                table: "courseOffers",
                column: "CourseCode",
                unique: true,
                filter: "[CourseCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_courseOffers_ExamRoutineid",
                table: "courseOffers",
                column: "ExamRoutineid");

            migrationBuilder.CreateIndex(
                name: "IX_examRoutines_CourseCode",
                table: "examRoutines",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_examRoutines_SlotID",
                table: "examRoutines",
                column: "SlotID");

            migrationBuilder.CreateIndex(
                name: "IX_myTasks_Email",
                table: "myTasks",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_Email",
                table: "Profile",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_userCourses_CourseCode",
                table: "userCourses",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_userCourses_Email",
                table: "userCourses",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classRoutines");

            migrationBuilder.DropTable(
                name: "courseOffers");

            migrationBuilder.DropTable(
                name: "myTasks");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "sweEvents");

            migrationBuilder.DropTable(
                name: "userCourses");

            migrationBuilder.DropTable(
                name: "examRoutines");

            migrationBuilder.DropTable(
                name: "appUsers");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "slots");
        }
    }
}
