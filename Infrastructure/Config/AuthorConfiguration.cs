using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Description).IsRequired().HasColumnType("text");
            builder.Property(p => p.PictureUrl).IsRequired().HasColumnType("text").HasDefaultValue("/img/default_img.jpg");

            builder.HasMany(g => g.BookAuthor)
                   .WithOne(ag => ag.Author)
                   .HasForeignKey(ag => ag.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
