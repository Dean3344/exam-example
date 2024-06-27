using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamApiNet7.Infrastructure.Mappings.User
{
    public class ContactInfoMap : IEntityTypeConfiguration<Domain.Models.UserAggregate.ContactInfo>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.UserAggregate.ContactInfo> builder)
        {
            builder.HasKey(k => k.UserId);

            builder.Property(e => e.UserId);

            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .IsUnicode(false);

        }
    }
}
