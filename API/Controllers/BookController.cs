using Core.Entities;
using Core.Interfaces;
using Core.Specificatios;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IGenericRepository<Book> repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Book>>> GetBooks(string? title, string? sort, [FromQuery] List<int>? GenreIds)
        {
            var spec = new BookFilterSortPaginationSpecification(title, sort, GenreIds);
            return Ok(await repo.ListWithSpecAsync(spec));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await repo.GetByIdAsync(id);

            if (book == null) return NotFound();

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            repo.Add(book);

            if (await repo.SaveAllAsync())
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

            repo.Update(book);

            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem updating book");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await repo.GetByIdAsync(id);

            if(book == null) return NotFound();

            repo.Delete(book);

            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem deleting book");
        }

        private bool BookExists(int id)
        {
            return repo.Exists(id);
        }   
    }
}
