using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class ExampleConfig : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.ToTable("Examples");
            builder.HasKey(example => example.Id);
            builder.Property(example => example.Id).HasMaxLength(100).IsRequired();
            builder.Property(example => example.Sentence).IsRequired();
            builder.Property(example => example.Meaning).IsRequired();
        }
    }
}
