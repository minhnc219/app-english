using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class DefinitionConfig : IEntityTypeConfiguration<Definition>
    {
        public void Configure(EntityTypeBuilder<Definition> builder)
        {
            builder.ToTable("Definitions");
            builder.HasKey(definition => definition.Id);
            builder.Property(definition => definition.Id)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(definition => definition.Type).IsRequired();
            builder.HasMany(definition => definition.Descriptions)
                .WithOne(description => description.Definition)
                .HasForeignKey(description => description.DefinitionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
