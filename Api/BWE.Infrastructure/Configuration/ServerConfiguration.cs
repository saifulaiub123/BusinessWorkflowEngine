using BWE.Domain.DBModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Infrastructure.Configuration
{
    public class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
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
        }
    }
}