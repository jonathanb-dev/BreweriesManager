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
        private readonly IBeerService _service;

        private readonly IMapper _mapper;

        public BeersController(IBeerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeerDto>>> GetBeers()
        {
            var beers = await _service.ListAsync();

            IEnumerable<BeersListDto> result = _mapper.Map<IEnumerable<BeersListDto>>(beers);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetBeer(int id)
        {
            var beer = await _service.GetAsync(id);

            if (beer == null)
                return NotFound();

            BeerDto result = _mapper.Map<BeerDto>(beer);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> PostBeer(BeerDto beerDto)
        {
            Beer result = _mapper.Map<Beer>(beerDto);

            _service.Add(result);

            await _service.SaveAsync();

            return CreatedAtAction(nameof(GetBeer), new { id = result.Id }, _mapper.Map<BeerDto>(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeer(int id, BeerDto beerDto)
        {
            if (id != beerDto.Id)
            {
                return BadRequest();
            }

            Beer result = _mapper.Map<Beer>(beerDto);

            _service.Update(result);

            try
            {
                await _service.SaveAsync();
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
            var beer = await _service.GetAsync(id);

            if (beer == null)
                return NotFound();

            _service.Delete(id);

            await _service.SaveAsync();

            return NoContent();
        }

        private bool BeerExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}