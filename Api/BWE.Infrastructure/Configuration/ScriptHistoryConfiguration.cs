using BWE.Domain.DBModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BWE.Infrastructure.Configuration
{
    public class ScriptHistoryConfiguration : IEntityTypeConfiguration<ScriptHistory>
    {
        public void Configure(EntityTypeBuilder<ScriptHistory> builder)
        {

            builder.HasIndex(x => x.ScriptId)
               .IsUnique(false);
            builder.HasIndex(x => x.CreatedBy)
               .IsUnique(false);
            builder.HasIndex(x => x.UpdatedBy)
               .IsUnique(false);

            builder.HasOne(x => x.CreatedByUser)
               .WithOne(y => y.CreatedByScriptHistory)
               .HasForeignKey<ScriptHistory>(z => z.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UpdateByUser)
               .WithOne(y => y.UpdatedByScriptHistory)
               .HasForeignKey<ScriptHistory>(z => z.UpdatedBy)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
