using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BWE.Domain.DBModel;

namespace BWE.Infrastructure.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasIndex(x => x.StatusId)
                .IsUnique(false);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.PasswordHash)
                .IsRequired();
            builder.Property(x => x.StatusId)
               .IsRequired()
               .HasMaxLength(10);
            builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);
               
        }
    }
}
