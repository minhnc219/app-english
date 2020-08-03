using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class DescriptionConfig : IEntityTypeConfiguration<Description>
    {
        public void Configure(EntityTypeBuilder<Description> builder)
        {
            builder.ToTable("Descriptions");
            builder.HasKey(description => description.Id);
            builder.Property(description => description.Id).HasMaxLength(100).IsRequired();
            builder.Property(description => description.Detail).IsRequired();
            builder.HasMany(description => description.Examples)
                .WithOne(example => example.Description)
                .HasForeignKey(example => example.DescriptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
