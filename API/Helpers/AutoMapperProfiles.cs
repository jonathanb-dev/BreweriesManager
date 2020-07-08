using API.Dtos;
using AutoMapper;
using Domain.Models;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Beer, BeersListDto>();
            CreateMap<Beer, BeerDto>();
        }
    }
}