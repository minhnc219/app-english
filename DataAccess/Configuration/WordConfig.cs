using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class WordConfig : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.ToTable("Words");
            builder.HasKey(word => word.Id);
            builder.Property(word => word.Id).HasMaxLength(100).IsRequired();
            builder.Property(word => word.Name).IsRequired();
            builder.Property(word => word.Week).IsRequired();
            builder.Property(word => word.Day).IsRequired();
            builder.HasMany(word => word.Definitions)
                .WithOne(definition => definition.Word)
                .HasForeignKey(definition => definition.WordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
