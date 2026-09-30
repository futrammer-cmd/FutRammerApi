using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application;

public partial class AddStudentProfileFields : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTime>(
            name: "BirthDate",
            schema: "Identity",
            table: "Users",
            type: "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "City",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Country",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "CurrentJob",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "EducationLevel",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Gender",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "GraduationYear",
            schema: "Identity",
            table: "Users",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Major",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "MaritalStatus",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "MiddleName",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "MotherTongue",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "Nationality",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "NotifyConsent",
            schema: "Identity",
            table: "Users",
            type: "bit",
            nullable: false,
            defaultValue: true);

        migrationBuilder.AddColumn<string>(
            name: "ProgramLanguage",
            schema: "Identity",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "BirthDate",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "City",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "Country",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "CurrentJob",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "EducationLevel",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "Gender",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "GraduationYear",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "Major",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "MaritalStatus",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "MiddleName",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "MotherTongue",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "Nationality",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "NotifyConsent",
            schema: "Identity",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "ProgramLanguage",
            schema: "Identity",
            table: "Users");
    }
}
