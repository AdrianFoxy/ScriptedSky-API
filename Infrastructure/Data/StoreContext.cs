using Core.Entities;
using Infrastructure.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethod { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenreConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PublisherConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LanguageConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryMethodConfiguration).Assembly);

            // Many-to-Many Entity
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Author)
                .WithMany(e => e.Book)
                .UsingEntity<BookAuthor>();

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Genre)
                .WithMany(e => e.Book)
                .UsingEntity<BookGenre>();
        }
    }
}
