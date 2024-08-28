using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Title).IsRequired().HasMaxLength(256);
            builder.HasIndex(p => p.Title).IsUnique();

            builder.Property(p => p.Description).IsRequired().HasColumnType("text");
            builder.Property(p => p.PictureURL).IsRequired().HasColumnType("text").HasDefaultValue("/img/default_img.jpg");
            builder.Property(p => p.ReleaseYear).IsRequired();
            builder.Property(p => p.SizeFormat).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PageNumber).IsRequired();
            builder.Property(p => p.Weight).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ISBN).IsRequired().HasMaxLength(13);

            builder.HasMany(p => p.BookAuthor)
                   .WithOne(p => p.Book)
                   .HasForeignKey(p => p.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.BookGenre)
                   .WithOne(p => p.Book)
                   .HasForeignKey(p => p.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Language).WithMany()
                   .HasForeignKey(p => p.LanguageId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Publisher).WithMany()
                   .HasForeignKey(p => p.PublisherId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
