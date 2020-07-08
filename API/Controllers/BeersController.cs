using API.Dtos;
using AutoMapper;
using Domain.Models;
using Domain.Repos;
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
        private readonly IBeerRepository _repo;

        private readonly IMapper _mapper;

        public BeersController(IBeerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBeers()
        {
            var beers = await _repo.GetAllAsync();

            var mappedResult = _mapper.Map<IEnumerable<BeersListDto>>(beers);

            return Ok(mappedResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeer(int id)
        {
            var beer = await _repo.GetAsync(id);

            if (beer == null)
                return NotFound();

            var mappedResult = _mapper.Map<BeerDto>(beer);

            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<ActionResult<Beer>> PostBeer(Beer beer)
        {
            _repo.Insert(beer);

            await _repo.SaveAllAsync();

            return CreatedAtAction(nameof(GetBeer), new { id = beer.Id }); // TODO DTO
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeer(int id, Beer beer)
        {
            if (id != beer.Id)
            {
                return BadRequest();
            }

            _repo.Update(beer);

            try
            {
                await _repo.SaveAllAsync();
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
            var beer = await _repo.GetAsync(id);

            if (beer == null)
                return NotFound();

            _repo.Delete(id);

            await _repo.SaveAllAsync();

            return beer;
        }

        private bool BeerExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}