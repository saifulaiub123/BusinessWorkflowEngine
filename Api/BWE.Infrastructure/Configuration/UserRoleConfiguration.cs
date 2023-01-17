using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BWE.Domain.DBModel;

namespace BWE.Infrastructure.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x=> x.Id).ValueGeneratedNever();
        }
    }
}
