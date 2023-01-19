using BWE.Domain.DBModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace BWE.Infrastructure.Configuration
{
    public class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.HasIndex(x => x.CreatedBy)
                .IsUnique(false);
            builder.HasIndex(x => x.UpdatedBy)
                .IsUnique(false);

            builder.Property(x => x.Name)
                .HasMaxLength(250);
            builder.Property(x => x.IpAddress)
                .HasMaxLength(20);
            builder.Property(x => x.MachineName)
                .HasMaxLength(50);
            builder.Property(x => x.UserName)
                .HasMaxLength(100);
            builder.Property(x => x.Password)
                .HasMaxLength(250);

            builder.HasMany(s => s.Scripts)
                .WithOne(g => g.Server)
                .HasForeignKey(x => x.DestinationServerId)
                .OnDelete(DeleteBehavior.Restrict);



            builder.HasOne(x => x.CreatedByUser)
               .WithOne(y => y.CreatedByServer)
               .HasForeignKey<Server>(z => z.CreatedBy)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UpdateByUser)
               .WithOne(y => y.UpdatedByServer)
               .HasForeignKey<Server>(z => z.UpdatedBy)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}