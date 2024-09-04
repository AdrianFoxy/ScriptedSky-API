using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specificatios;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BookController(IGenericRepository<Book> repo, IMapper mapper) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StoreBookDto>>> GetBooks(
            [FromQuery] BookSpecParams bookSpecParams)
        {
            var spec = new BookFilterSortPaginationSpecification(bookSpecParams);

            return await CreatePagedResult<Book, StoreBookDto>(repo, spec, bookSpecParams.PageIndex, bookSpecParams.PageSize, mapper);
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
