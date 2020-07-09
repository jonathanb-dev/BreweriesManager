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
    public class BreweriesController : ControllerBase
    {
        private readonly IBreweryService _service;

        private readonly IMapper _mapper;

        public BreweriesController(IBreweryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBreweries()
        {
            var breweries = await _service.ListAsync();

            var mappedResult = _mapper.Map<IEnumerable<BreweriesListDto>>(breweries);

            return Ok(mappedResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrewery(int id)
        {
            var brewery = await _service.GetAsync(id);

            if (brewery == null)
                return NotFound();

            var mappedResult = _mapper.Map<BreweryDto>(brewery);

            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<ActionResult<Brewery>> PostBrewery(Brewery brewery)
        {
            _service.Add(brewery);

            await _service.SaveAsync();

            return CreatedAtAction(nameof(GetBrewery), new { id = brewery.Id }); // TODO DTO
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewery(int id, Brewery brewery)
        {
            if (id != brewery.Id)
            {
                return BadRequest();
            }

            _service.Update(brewery);

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
        public async Task<ActionResult<Brewery>> DeleteBrewery(int id)
        {
            var brewery = await _service.GetAsync(id);

            if (brewery == null)
                return NotFound();

            _service.Delete(id);

            await _service.SaveAsync();

            return brewery;
        }

        private bool BreweryExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}