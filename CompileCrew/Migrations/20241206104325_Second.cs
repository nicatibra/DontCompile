using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompileCrew.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Companies_CompanyId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Reports_CompanyId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OverTimeHours",
                table: "VacationRequests");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "VacationRequests");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "SofDelete",
                table: "VacationRequests",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "SofDelete",
                table: "Reports",
                newName: "SoftDelete");

            migrationBuilder.RenameColumn(
                name: "SofDelete",
                table: "Payrolls",
                newName: "SoftDelete");

            migrationBuilder.RenameColumn(
                name: "SofDelete",
                table: "Employees",
                newName: "SoftDelete");

            migrationBuilder.RenameColumn(
                name: "SofDelete",
                table: "Contracts",
                newName: "SoftDelete");

            migrationBuilder.RenameColumn(
                name: "SofDelete",
                table: "Attendances",
                newName: "SoftDelete");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "VacationRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "SoftDelete",
                table: "VacationRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "VacationRequests");

            migrationBuilder.DropColumn(
                name: "SoftDelete",
                table: "VacationRequests");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "VacationRequests",
                newName: "SofDelete");

            migrationBuilder.RenameColumn(
                name: "SoftDelete",
                table: "Reports",
                newName: "SofDelete");

            migrationBuilder.RenameColumn(
                name: "SoftDelete",
                table: "Payrolls",
                newName: "SofDelete");

            migrationBuilder.RenameColumn(
                name: "SoftDelete",
                table: "Employees",
                newName: "SofDelete");

            migrationBuilder.RenameColumn(
                name: "SoftDelete",
                table: "Contracts",
                newName: "SofDelete");

            migrationBuilder.RenameColumn(
                name: "SoftDelete",
                table: "Attendances",
                newName: "SofDelete");

            migrationBuilder.AddColumn<int>(
                name: "OverTimeHours",
                table: "VacationRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "VacationRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "MyProperty",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SofDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CompanyId",
                table: "Reports",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Companies_CompanyId",
                table: "Reports",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
