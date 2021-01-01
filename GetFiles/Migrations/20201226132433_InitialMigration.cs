using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GetFiles.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoCourse",
                columns: table => new
                {
                    idCourse = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameOfCourse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    info = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCourse", x => x.idCourse);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    idVideo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameOfVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoCourseidCourse = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.idVideo);
                    table.ForeignKey(
                        name: "FK_Video_VideoCourse_VideoCourseidCourse",
                        column: x => x.VideoCourseidCourse,
                        principalTable: "VideoCourse",
                        principalColumn: "idCourse",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_VideoCourseidCourse",
                table: "Video",
                column: "VideoCourseidCourse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "VideoCourse");
        }
    }
}
