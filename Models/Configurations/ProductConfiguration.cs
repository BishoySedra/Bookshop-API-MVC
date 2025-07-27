﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Table and Schema
            builder.ToTable("Products", schema: "MasterSchema");

            // Primary Key
            builder.HasKey(p => p.Id);

            // Title: Required, MaxLength(50)
            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(50);

            // Description: Optional, MaxLength(250)
            builder.Property(p => p.Description)
                   .HasMaxLength(250);

            // Author: Required, MaxLength(50)
            builder.Property(p => p.Author)
                   .IsRequired()
                   .HasMaxLength(50);

            // Price: Required, ColumnName = BookPrice
            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnName("BookPrice");

            // Validation for price range (1-1000) – done in application-level validation, not DB

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
