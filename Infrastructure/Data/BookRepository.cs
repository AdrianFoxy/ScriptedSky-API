using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BookRepository(StoreContext context) : IBookRepository
    {
        public void AddBook(Book book)
        {
            context.Book.Add(book);
        }

        public void UpdateBook(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
        }

        public void DeleteBook(Book book)
        {
            context.Book.Remove(book);
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await context.Book.FindAsync(id);
        }

        public async Task<IReadOnlyList<Book>> GetBooksAsync()
        {
            return await context.Book.ToListAsync();
        }

        public bool BookExists(int id)
        {
            return context.Book.Any(p => p.Id == id);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
