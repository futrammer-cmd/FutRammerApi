using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application;

public partial class AddAcademicsLessonsAndTeachers : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Lessons",
            schema: "Academics",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),

                // بيانات المادة التعليمية
                LessonCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LessonNameAra = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                LessonNameEng = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                SeasonId = table.Column<long>(type: "bigint", nullable: false),

                // الحقول الافتراضية العامة (تتكرر في كل جداول سكيما Academics)
                NotActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                FlgDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AddBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                AddTime = table.Column<DateTime>(type: "datetime", nullable: false),
                EditBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                EditTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                MenuId = table.Column<long>(type: "bigint", nullable: true),
                Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatorUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifierUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                DeleterUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                IsBlocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                IsSystem = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                IsImported = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                DescriptionAra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DescriptionEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IsSynchronized = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                SynchronizationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                GLSerial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                GLType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                PostedToGL = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                ConfirmerUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                Confirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                IsLinkWithTaxAuthority = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                ConfirmationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                GeneralTrxSerial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                MonthlyTrxSerial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IsBlackList = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                MasterID = table.Column<long>(type: "bigint", nullable: true),
                PrintCount = table.Column<long>(type: "bigint", nullable: true),
                IsFavorite = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),

                // عمود تعدد المستأجرين (Multi-Tenancy) - يضاف تلقائيًا بواسطة Finbuckle.MultiTenant
                TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Lessons", x => x.Id);
                table.ForeignKey(
                    name: "FK_Lessons_Seasons_SeasonId",
                    column: x => x.SeasonId,
                    principalSchema: "Academics",
                    principalTable: "Seasons",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Teachers",
            schema: "Academics",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),

                // بيانات المعلم
                TeacherCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                TeacherNameAra = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                TeacherNameEng = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),

                // الحقول الافتراضية العامة (تتكرر في كل جداول سكيما Academics)
                NotActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                FlgDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                AddBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                AddTime = table.Column<DateTime>(type: "datetime", nullable: false),
                EditBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                EditTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                MenuId = table.Column<long>(type: "bigint", nullable: true),
                Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                CreatorUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                LastModifierUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                DeleterUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                IsBlocked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                IsSystem = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                IsImported = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                DescriptionAra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DescriptionEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IsSynchronized = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                SynchronizationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                GLSerial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                GLType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                PostedToGL = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                ConfirmerUserId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                Confirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                IsLinkWithTaxAuthority = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                ConfirmationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                GeneralTrxSerial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                MonthlyTrxSerial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                AttachmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IsBlackList = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                MasterID = table.Column<long>(type: "bigint", nullable: true),
                PrintCount = table.Column<long>(type: "bigint", nullable: true),
                IsFavorite = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),

                // عمود تعدد المستأجرين (Multi-Tenancy) - يضاف تلقائيًا بواسطة Finbuckle.MultiTenant
                TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Teachers", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Lessons_SeasonId",
            schema: "Academics",
            table: "Lessons",
            column: "SeasonId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Lessons",
            schema: "Academics");

        migrationBuilder.DropTable(
            name: "Teachers",
            schema: "Academics");
    }
}
