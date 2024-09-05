using API.Dtos;
using API.Dtos.FilteringDto;
using AutoMapper;
using Core.Entities;

namespace API.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Book, StoreBookDto>()
                .ForMember(d => d.PictureURL, opt => opt.MapFrom<UrlResolver<Book, StoreBookDto>>());

            CreateMap<Genre, GenreFilteringDto>();
            CreateMap<Author, AuthorFilteringDto>();
            CreateMap<Publisher, PublisherFilteringDto>();
            CreateMap<Language, LanguageFilteringDto>();
        }
    }
}
