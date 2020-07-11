﻿using API.Dtos;
using AutoMapper;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeerService _beerService;
        private readonly IBreweryService _breweryService;
        private readonly IWholesalerService _wholesalerService;

        private readonly IMapper _mapper;

        public BeersController(
            IBeerService beerService,
            IBreweryService breweryService,
            IWholesalerService wholesalerService,
            IMapper mapper
        )
        {
            _beerService = beerService;
            _breweryService = breweryService;
            _wholesalerService = wholesalerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeerDto>>> GetBeers()
        {
            var beers = await _beerService.BreweriesAndWholesalersListAsync();

            IEnumerable<BeerDto> result = _mapper.Map<IEnumerable<BeerDto>>(beers);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetBeer(int id)
        {
            var beer = await _beerService.GetAsync(id);

            if (beer == null)
                return NotFound();

            BeerDto result = _mapper.Map<BeerDto>(beer);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> PostBeer(PostBeerDto postBeerDto)
        {
            Brewery brewery = await _breweryService.GetAsync(postBeerDto.BreweryId);

            if (brewery == null)
                return NotFound();

            Beer result = _mapper.Map<Beer>(postBeerDto);

            result.Brewery = brewery; // TODO mapping

            _beerService.Validate(result);

            _beerService.Add(result);

            await _beerService.SaveAsync();

            return CreatedAtAction(nameof(GetBeer), new { id = result.Id }, _mapper.Map<BeerDto>(result));
        }

        [HttpPost("{id}/wholesalers")]
        public async Task<ActionResult<BeerDto>> PostWholesalerBeer(int id, PostWholesalerBeerForBeerDto postWholesalerBeerForBeerDto)
        {
            Beer beer = await _beerService.WholesalerBeersGetAsync(id);

            if (beer == null)
                return NotFound();

            Wholesaler wholesaler = await _wholesalerService.GetAsync(postWholesalerBeerForBeerDto.WholesalerId);

            if (wholesaler == null)
                return NotFound();

            beer.WholesalerBeers.Add(new WholesalerBeer { Wholesaler = wholesaler, Beer = beer });

            _beerService.Update(beer);

            await _beerService.SaveAsync();

            return CreatedAtAction(nameof(GetBeer), new { id = beer.Id }, _mapper.Map<BeerDto>(beer));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeer(int id, PutBeerDto putBeerDto)
        {
            if (id != putBeerDto.Id)
            {
                return BadRequest();
            }

            Brewery brewery = await _breweryService.GetAsync(putBeerDto.BreweryId);

            if (brewery == null)
                return NotFound();

            Beer result = _mapper.Map<Beer>(putBeerDto);

            result.Brewery = brewery; // TODO mapping

            _beerService.Update(result);

            try
            {
                await _beerService.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                /*if (TODO)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }*/
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeer(int id)
        {
            var beer = await _beerService.GetAsync(id);

            if (beer == null)
                return NotFound();

            _beerService.Delete(id);

            await _beerService.SaveAsync();

            return NoContent();
        }

        private bool BeerExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}