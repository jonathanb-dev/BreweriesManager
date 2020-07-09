using API.Dtos;
using AutoMapper;
using Domain.Models;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Brewery model to DTO
            CreateMap<Brewery, BreweriesListDto>();
            CreateMap<Brewery, BreweryDto>();
            // Brewery DTO to model
            CreateMap<BreweriesListDto, Brewery>();
            CreateMap<BreweryDto, Brewery>();

            // Wholesaler model to DTO
            CreateMap<Wholesaler, WholesalersListDto>();
            CreateMap<Wholesaler, WholesalerDto>();
            // Wholesaler DTO to model
            CreateMap<WholesalersListDto, Wholesaler>();
            CreateMap<WholesalerDto, Wholesaler>();

            // Beer model to DTO
            CreateMap<Beer, BeersListDto>();
            CreateMap<Beer, BeerDto>();
            // Beer DTO to model
            CreateMap<BeersListDto, Beer>();
            CreateMap<BeerDto, Beer>();
        }
    }
}