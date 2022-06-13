using AutoMapper;
using HeroApi.Models;
using HeroApi.Models.DTOs;

namespace HeroApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CharacterDTO, Character>().ReverseMap();
        }
    }
}
