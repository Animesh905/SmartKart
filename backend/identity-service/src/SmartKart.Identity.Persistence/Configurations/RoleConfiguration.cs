using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartKart.Identity.Domain.Entities.RoleEntities;
using SmartKart.Identity.Persistence.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartKart.Identity.Persistence.Configurations
{
    internal sealed class RoleConfiguration
        : IEntityTypeConfiguration<Role>
    {
        public void Configure(
            EntityTypeBuilder<Role> builder
            )
        {
            builder.ToTable(TableNames.tbl_Roles);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Code)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasIndex(x => x.Code)
                   .IsUnique();
        }
    }
}
