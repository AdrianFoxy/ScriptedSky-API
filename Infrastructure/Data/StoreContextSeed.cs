using Core.Entities;
using System.Text.Json;

namespace Infrastructure.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.Author.Any())
            {
                var authorsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/authors.json");
                var authors = JsonSerializer.Deserialize<List<Author>>(authorsData);
                if (authors == null) return;

                context.Author.AddRange(authors);
                await context.SaveChangesAsync();
            }

            if (!context.Genre.Any())
            {
                var genreData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/genres.json");
                var genres = JsonSerializer.Deserialize<List<Genre>>(genreData);

                if (genres == null) return;

                context.Genre.AddRange(genres);
                await context.SaveChangesAsync();
            }

            if (!context.Publisher.Any())
            {
                var publisherData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/publishers.json");
                var publishers = JsonSerializer.Deserialize<List<Publisher>>(publisherData);

                if (publishers == null) return;

                context.Publisher.AddRange(publishers);
                await context.SaveChangesAsync();
            }

            if (!context.Language.Any())
            {
                var languageData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/languages.json");
                var languages = JsonSerializer.Deserialize<List<Language>>(languageData);

                if (languages == null) return;

                context.Language.AddRange(languages);
                await context.SaveChangesAsync();
            }

            if (!context.Book.Any())
            {
                var bookData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/books.json");
                var books = JsonSerializer.Deserialize<List<Book>>(bookData);

                if (books == null) return;

                context.Book.AddRange(books);
                await context.SaveChangesAsync();
            }

            if (!context.BookAuthor.Any())
            {
                var bookAuthor = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/book-authors.json");
                var bookAuthors = JsonSerializer.Deserialize<List<BookAuthor>>(bookAuthor);

                if (bookAuthors == null) return;

                context.BookAuthor.AddRange(bookAuthors);
                await context.SaveChangesAsync();
            }

            if (!context.BookGenre.Any())
            {
                var bookGenre = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/book-genres.json");
                var bookGenres = JsonSerializer.Deserialize<List<BookGenre>>(bookGenre);

                if (bookGenres == null) return;

                context.BookGenre.AddRange(bookGenres);
                await context.SaveChangesAsync();
            }
        }
    }
}