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
            CreateMap<Brewery, PostBreweryDto>();
            CreateMap<Brewery, PutBreweryDto>();
            // Brewery DTO to model
            CreateMap<BreweriesListDto, Brewery>();
            CreateMap<BreweryDto, Brewery>();
            CreateMap<PostBreweryDto, Brewery>();
            CreateMap<PutBreweryDto, Brewery>();

            // Wholesaler model to DTO
            CreateMap<Wholesaler, WholesalersListDto>();
            CreateMap<Wholesaler, WholesalerDto>();
            CreateMap<Wholesaler, PostWholesalerDto>();
            CreateMap<Wholesaler, PutWholesalerDto>();
            // Wholesaler DTO to model
            CreateMap<WholesalersListDto, Wholesaler>();
            CreateMap<WholesalerDto, Wholesaler>();
            CreateMap<PostWholesalerDto, Wholesaler>();
            CreateMap<PutWholesalerDto, Wholesaler>();

            // Beer model to DTO
            CreateMap<Beer, BeersListDto>();
            CreateMap<Beer, BeerDto>();
            CreateMap<Beer, PostBeerDto>();
            CreateMap<Beer, PutBeerDto>();
            // Beer DTO to model
            CreateMap<BeersListDto, Beer>();
            CreateMap<BeerDto, Beer>();
            CreateMap<PostBeerDto, Beer>();
            CreateMap<PutBeerDto, Beer>();
        }
    }
}