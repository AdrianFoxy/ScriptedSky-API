using API.Dtos.FilteringDto;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FilteringController (IMapper mapper, 
        IGenericRepository<Genre> repoGenre, IGenericRepository<Author> repoAutor,
        IGenericRepository<Publisher> repoPublisher, IGenericRepository<Language> repoLanguage) : BaseApiController
    {
        [HttpGet("genre")]
        public async Task<ActionResult<GenreFilteringDto>> GetFilteringGenres()
        {
            var genres = await repoGenre.ListAllAsync();
            return Ok(mapper.Map<IReadOnlyList<Genre>, IReadOnlyList<GenreFilteringDto>>(genres));
        }

        [HttpGet("author")]
        public async Task<ActionResult<AuthorFilteringDto>> GetFilteringAuthors()
        {
            var authors = await repoAutor.ListAllAsync();
            return Ok(mapper.Map<IReadOnlyList<Author>, IReadOnlyList<AuthorFilteringDto>>(authors));
        }

        [HttpGet("publisher")]
        public async Task<ActionResult<AuthorFilteringDto>> GetFilteringPublishers()
        {
            var publishers = await repoPublisher.ListAllAsync();
            return Ok(mapper.Map<IReadOnlyList<Publisher>, IReadOnlyList<PublisherFilteringDto>>(publishers));
        }

        [HttpGet("language")]
        public async Task<ActionResult<AuthorFilteringDto>> GetFilteringLanguages()
        {
            var languages = await repoLanguage.ListAllAsync();
            return Ok(mapper.Map<IReadOnlyList<Language>, IReadOnlyList<LanguageFilteringDto>>(languages));
        }
    }
}
