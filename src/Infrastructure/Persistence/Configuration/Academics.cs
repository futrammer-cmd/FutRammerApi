using Finbuckle.MultiTenant.EntityFrameworkCore;
using FutRammerApi.Domain.Academics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FutRammerApi.Infrastructure.Persistence.Configuration;

public class SeasonConfig : IEntityTypeConfiguration<Season>
{
    public void Configure(EntityTypeBuilder<Season> builder)
    {
        builder.ToTable("Seasons", SchemaNames.Academics);
        builder.IsMultiTenant();

        // بيانات الفصل الدراسي
        builder.Property(s => s.SeasonCode).IsRequired().HasMaxLength(50);
        builder.Property(s => s.SeasonNameAra).IsRequired().HasMaxLength(256);
        builder.Property(s => s.SeasonNameEng).IsRequired().HasMaxLength(256);

        // أطوال أعمدة النصوص المحدودة (nvarchar(255)) حسب القالب المتفق عليه
        builder.Property(s => s.AddBy).HasMaxLength(255);
        builder.Property(s => s.EditBy).HasMaxLength(255);
        builder.Property(s => s.CreatorUserId).HasMaxLength(255);
        builder.Property(s => s.LastModifierUserId).HasMaxLength(255);
        builder.Property(s => s.DeleterUserId).HasMaxLength(255);
        builder.Property(s => s.GLSerial).HasMaxLength(255);
        builder.Property(s => s.GLType).HasMaxLength(255);
        builder.Property(s => s.ConfirmerUserId).HasMaxLength(255);
        builder.Property(s => s.GeneralTrxSerial).HasMaxLength(255);
        builder.Property(s => s.MonthlyTrxSerial).HasMaxLength(255);

        // AddTime من نوع datetime (وليس datetime2) حسب القالب المطلوب
        builder.Property(s => s.AddTime).HasColumnType("datetime");

        // كل أعمدة bit تاخد قيمة افتراضية = 0 (false) عند الإدراج
        builder.Property(s => s.NotActive).HasDefaultValue(false);
        builder.Property(s => s.FlgDelete).HasDefaultValue(false);
        builder.Property(s => s.IsDeleted).HasDefaultValue(false);
        builder.Property(s => s.IsActive).HasDefaultValue(false);
        builder.Property(s => s.IsBlocked).HasDefaultValue(false);
        builder.Property(s => s.IsSystem).HasDefaultValue(false);
        builder.Property(s => s.IsImported).HasDefaultValue(false);
        builder.Property(s => s.IsSynchronized).HasDefaultValue(false);
        builder.Property(s => s.PostedToGL).HasDefaultValue(false);
        builder.Property(s => s.Confirmed).HasDefaultValue(false);
        builder.Property(s => s.IsLinkWithTaxAuthority).HasDefaultValue(false);
        builder.Property(s => s.IsBlackList).HasDefaultValue(false);
        builder.Property(s => s.IsFavorite).HasDefaultValue(false);
    }
}

public class LessonConfig : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons", SchemaNames.Academics);
        builder.IsMultiTenant();

        // بيانات المادة التعليمية
        builder.Property(l => l.LessonCode).IsRequired().HasMaxLength(50);
        builder.Property(l => l.LessonNameAra).IsRequired().HasMaxLength(256);
        builder.Property(l => l.LessonNameEng).IsRequired().HasMaxLength(256);

        builder.HasOne(l => l.Season)
            .WithMany()
            .HasForeignKey(l => l.SeasonId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // أطوال أعمدة النصوص المحدودة (nvarchar(255)) حسب القالب المتفق عليه
        builder.Property(l => l.AddBy).HasMaxLength(255);
        builder.Property(l => l.EditBy).HasMaxLength(255);
        builder.Property(l => l.CreatorUserId).HasMaxLength(255);
        builder.Property(l => l.LastModifierUserId).HasMaxLength(255);
        builder.Property(l => l.DeleterUserId).HasMaxLength(255);
        builder.Property(l => l.GLSerial).HasMaxLength(255);
        builder.Property(l => l.GLType).HasMaxLength(255);
        builder.Property(l => l.ConfirmerUserId).HasMaxLength(255);
        builder.Property(l => l.GeneralTrxSerial).HasMaxLength(255);
        builder.Property(l => l.MonthlyTrxSerial).HasMaxLength(255);

        // AddTime من نوع datetime (وليس datetime2) حسب القالب المطلوب
        builder.Property(l => l.AddTime).HasColumnType("datetime");

        // كل أعمدة bit تاخد قيمة افتراضية = 0 (false) عند الإدراج
        builder.Property(l => l.NotActive).HasDefaultValue(false);
        builder.Property(l => l.FlgDelete).HasDefaultValue(false);
        builder.Property(l => l.IsDeleted).HasDefaultValue(false);
        builder.Property(l => l.IsActive).HasDefaultValue(false);
        builder.Property(l => l.IsBlocked).HasDefaultValue(false);
        builder.Property(l => l.IsSystem).HasDefaultValue(false);
        builder.Property(l => l.IsImported).HasDefaultValue(false);
        builder.Property(l => l.IsSynchronized).HasDefaultValue(false);
        builder.Property(l => l.PostedToGL).HasDefaultValue(false);
        builder.Property(l => l.Confirmed).HasDefaultValue(false);
        builder.Property(l => l.IsLinkWithTaxAuthority).HasDefaultValue(false);
        builder.Property(l => l.IsBlackList).HasDefaultValue(false);
        builder.Property(l => l.IsFavorite).HasDefaultValue(false);
    }
}

public class TeacherConfig : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers", SchemaNames.Academics);
        builder.IsMultiTenant();

        // بيانات المعلم
        builder.Property(t => t.TeacherCode).IsRequired().HasMaxLength(50);
        builder.Property(t => t.TeacherNameAra).IsRequired().HasMaxLength(256);
        builder.Property(t => t.TeacherNameEng).IsRequired().HasMaxLength(256);
        builder.Property(t => t.Email).HasMaxLength(256);
        builder.Property(t => t.Phone).HasMaxLength(50);

        // أطوال أعمدة النصوص المحدودة (nvarchar(255)) حسب القالب المتفق عليه
        builder.Property(t => t.AddBy).HasMaxLength(255);
        builder.Property(t => t.EditBy).HasMaxLength(255);
        builder.Property(t => t.CreatorUserId).HasMaxLength(255);
        builder.Property(t => t.LastModifierUserId).HasMaxLength(255);
        builder.Property(t => t.DeleterUserId).HasMaxLength(255);
        builder.Property(t => t.GLSerial).HasMaxLength(255);
        builder.Property(t => t.GLType).HasMaxLength(255);
        builder.Property(t => t.ConfirmerUserId).HasMaxLength(255);
        builder.Property(t => t.GeneralTrxSerial).HasMaxLength(255);
        builder.Property(t => t.MonthlyTrxSerial).HasMaxLength(255);

        // AddTime من نوع datetime (وليس datetime2) حسب القالب المطلوب
        builder.Property(t => t.AddTime).HasColumnType("datetime");

        // كل أعمدة bit تاخد قيمة افتراضية = 0 (false) عند الإدراج
        builder.Property(t => t.NotActive).HasDefaultValue(false);
        builder.Property(t => t.FlgDelete).HasDefaultValue(false);
        builder.Property(t => t.IsDeleted).HasDefaultValue(false);
        builder.Property(t => t.IsActive).HasDefaultValue(false);
        builder.Property(t => t.IsBlocked).HasDefaultValue(false);
        builder.Property(t => t.IsSystem).HasDefaultValue(false);
        builder.Property(t => t.IsImported).HasDefaultValue(false);
        builder.Property(t => t.IsSynchronized).HasDefaultValue(false);
        builder.Property(t => t.PostedToGL).HasDefaultValue(false);
        builder.Property(t => t.Confirmed).HasDefaultValue(false);
        builder.Property(t => t.IsLinkWithTaxAuthority).HasDefaultValue(false);
        builder.Property(t => t.IsBlackList).HasDefaultValue(false);
        builder.Property(t => t.IsFavorite).HasDefaultValue(false);
    }
}
