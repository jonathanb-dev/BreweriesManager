using API.Dtos;
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

        private readonly IMapper _mapper;

        public BeersController(IBeerService beerService, IBreweryService breweryService, IMapper mapper)
        {
            _beerService = beerService;
            _breweryService = breweryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeerDto>>> GetBeers()
        {
            var beers = await _beerService.ListAsync();

            IEnumerable<BeersListDto> result = _mapper.Map<IEnumerable<BeersListDto>>(beers);

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<BeerDto>>> GetBeersPerBrewery()
        {
            var beers = await _beerService.ListAsync();

            IEnumerable<BeersListDto> result = _mapper.Map<IEnumerable<BeersListDto>>(beers);

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

            result.Brewery = brewery;

            _beerService.Add(result);

            await _beerService.SaveAsync();

            return CreatedAtAction(nameof(GetBeer), new { id = result.Id }, _mapper.Map<BeerDto>(result));
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

            result.Brewery = brewery;

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