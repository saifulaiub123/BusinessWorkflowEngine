using BWE.Domain.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BWE.Infrastructure.Configuration
{
    public class ScriptConfiguration : IEntityTypeConfiguration<Script>
    {
        public void Configure(EntityTypeBuilder<Script> builder)
        {

            builder.HasIndex(x => x.DestinationServerId)
               .IsUnique(false);
            builder.HasIndex(x => x.CreatedBy)
               .IsUnique(false);
            builder.HasIndex(x => x.UpdatedBy)
               .IsUnique(false);

            builder.Property(x => x.Name)
                .HasMaxLength(250);
            builder.Property(x => x.Description)
                .HasMaxLength(250); 
            builder.Property(x => x.SendTo)
                .HasMaxLength(250);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);



            builder.HasOne(x => x.CreatedByUser)
               .WithOne(y => y.CreatedByScript)
               .HasForeignKey<Script>(z => z.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UpdateByUser)
               .WithOne(y => y.UpdatedByScript)
               .HasForeignKey<Script>(z => z.UpdatedBy)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
