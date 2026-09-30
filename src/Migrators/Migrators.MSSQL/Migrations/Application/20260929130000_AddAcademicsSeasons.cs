using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application;

public partial class AddAcademicsSeasons : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "Academics");

        migrationBuilder.CreateTable(
            name: "Seasons",
            schema: "Academics",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),

                // بيانات الفصل الدراسي
                SeasonCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                SeasonNameAra = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                SeasonNameEng = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),

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
                table.PrimaryKey("PK_Seasons", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Seasons",
            schema: "Academics");
    }
}
