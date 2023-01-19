using BWE.Domain.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Infrastructure.Configuration
{
    public class ScriptConfiguration : IEntityTypeConfiguration<Script>
    {
        public void Configure(EntityTypeBuilder<Script> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(250);
            builder.Property(x => x.Description)
                .HasMaxLength(250);
        }
    }
}
