﻿using API.Dtos;
using AutoMapper;
using Domain.Models;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Brewery model to DTO
            CreateMap<Brewery, BreweryDto>();
            CreateMap<Brewery, PostBreweryDto>();
            CreateMap<Brewery, PutBreweryDto>();
            // Brewery DTO to model
            CreateMap<BreweryDto, Brewery>();
            CreateMap<PostBreweryDto, Brewery>();
            CreateMap<PutBreweryDto, Brewery>();

            // Wholesaler model to DTO
            CreateMap<Wholesaler, WholesalerDto>();
            CreateMap<Wholesaler, PostWholesalerDto>();
            CreateMap<Wholesaler, PutWholesalerDto>();
            // Wholesaler DTO to model
            CreateMap<WholesalerDto, Wholesaler>();
            CreateMap<PostWholesalerDto, Wholesaler>();
            CreateMap<PutWholesalerDto, Wholesaler>();

            // Beer model to DTO
            CreateMap<Beer, BeerDto>();
            CreateMap<Beer, PostBeerDto>();
            CreateMap<Beer, PutBeerDto>();
            CreateMap<Beer, BeerForWholesalerBeerDto>();
            // Beer DTO to model
            CreateMap<BeerDto, Beer>();
            CreateMap<PostBeerDto, Beer>();
            CreateMap<PutBeerDto, Beer>();
            CreateMap<BeerForWholesalerBeerDto, Beer>();

            // Wholesalerbeer model to DTO
            CreateMap<WholesalerBeer, WholesalerBeerDto>();
            CreateMap<WholesalerBeer, WholesalerBeerForBeerDto>();
            CreateMap<WholesalerBeer, PostWholesalerBeerDto>();
            // Wholesalerbeer DTO to model
            CreateMap<WholesalerBeerDto, WholesalerBeer>();
            CreateMap<WholesalerBeerForBeerDto, WholesalerBeer>();
            CreateMap<PostWholesalerBeerDto, WholesalerBeer>();

            // SaleHeader model to DTO
            CreateMap<SaleHeader, SaleHeaderDto>();
            CreateMap<SaleHeader, PostSaleHeaderDto>();
            CreateMap<SaleHeader, PutSaleHeaderDto>();
            // SaleHeader DTO to model
            CreateMap<SaleHeaderDto, SaleHeader>();
            CreateMap<PostSaleHeaderDto, SaleHeader>();
            CreateMap<PutSaleHeaderDto, SaleHeader>();
        }
    }
}