using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IBookRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Book>>> GetBooks()
        {
            return Ok(await repo.GetBooksAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await repo.GetBookByIdAsync(id);

            if (book == null) return NotFound();

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            repo.AddBook(book);

            if (await repo.SaveChangesAsync())
            {
                return CreatedAtAction("GetBook", new { id = book.Id }, book);
            }

            return BadRequest("Problem creating book");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateBook(int id, Book book)
        {
            if (book.Id != id || !BookExists(id) )
                return BadRequest("Cannot update book");

            repo.UpdateBook(book);

            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem updating book");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await repo.GetBookByIdAsync(id);

            if(book == null) return NotFound();

            repo.DeleteBook(book);

            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem deleting book");
        }

        private bool BookExists(int id)
        {
            return repo.BookExists(id);
        }   
    }
}
