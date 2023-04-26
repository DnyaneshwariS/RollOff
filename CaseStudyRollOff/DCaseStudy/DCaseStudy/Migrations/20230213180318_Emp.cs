using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DCaseStudy.Migrations
{
    public partial class Emp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    GlobalGroupId = table.Column<double>(type: "float", nullable: false),
                    EmployeeNo = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainClient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectCode = table.Column<double>(type: "float", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeopleManagerPerformanceReviewer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Practice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PspName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewGlobalPractice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.GlobalGroupId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
