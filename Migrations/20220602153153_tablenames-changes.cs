using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KariyerBackendApi.Migrations
{
    public partial class tablenameschanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Employers_EmployerId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employers",
                table: "Employers");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "Employers",
                newName: "Employer");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_EmployerId",
                table: "Job",
                newName: "IX_Job_EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employers_PhoneNumber",
                table: "Employer",
                newName: "IX_Employer_PhoneNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employer",
                table: "Employer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Employer_EmployerId",
                table: "Job",
                column: "EmployerId",
                principalTable: "Employer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Employer_EmployerId",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employer",
                table: "Employer");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Employer",
                newName: "Employers");

            migrationBuilder.RenameIndex(
                name: "IX_Job_EmployerId",
                table: "Jobs",
                newName: "IX_Jobs_EmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employer_PhoneNumber",
                table: "Employers",
                newName: "IX_Employers_PhoneNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employers",
                table: "Employers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Employers_EmployerId",
                table: "Jobs",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
