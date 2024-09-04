using API.Dtos;
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
        }
    }
}
