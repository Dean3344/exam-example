using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamApiNet7.Infrastructure.Mappings.User
{
    public class UserMap : IEntityTypeConfiguration<Domain.Models.UserAggregate.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.UserAggregate.User> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasIndex(e => e.AccountName).IsUnique();

            builder.Property(e => e.Id)
                .HasDefaultValueSql("(newId())");

            builder.Property(e => e.AccountName)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(e => e.GivenName)
                .HasMaxLength(50);

            builder.Property(e => e.FamilyName)
                .HasMaxLength(50);

            builder.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);

            builder.Property(e => e.Birthday);

            builder.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getDate())")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.UpdateTime);

            builder.HasOne(e => e.ContactInfo)
                .WithMany()
                .HasForeignKey(e => e.Id);
        }
    }
}
