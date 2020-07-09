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
        public async Task<IActionResult> GetBeers()
        {
            var beers = await _service.ListAsync();

            var mappedResult = _mapper.Map<IEnumerable<BeersListDto>>(beers);

            return Ok(mappedResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeer(int id)
        {
            var beer = await _service.GetAsync(id);

            if (beer == null)
                return NotFound();

            var mappedResult = _mapper.Map<BeerDto>(beer);

            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<ActionResult<Beer>> PostBeer(Beer beer)
        {
            _service.Add(beer);

            await _service.SaveAsync();

            return CreatedAtAction(nameof(GetBeer), new { id = beer.Id }); // TODO DTO
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeer(int id, Beer beer)
        {
            if (id != beer.Id)
            {
                return BadRequest();
            }

            _service.Update(beer);

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
        public async Task<ActionResult<Beer>> DeleteBeer(int id)
        {
            var beer = await _service.GetAsync(id);

            if (beer == null)
                return NotFound();

            _service.Delete(id);

            await _service.SaveAsync();

            return beer;
        }

        private bool BeerExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}