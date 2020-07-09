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
        public async Task<ActionResult<IEnumerable<BreweryDto>>> GetBreweries()
        {
            var breweries = await _service.ListAsync();

            IEnumerable<BreweriesListDto> result = _mapper.Map<IEnumerable<BreweriesListDto>>(breweries);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BreweryDto>> GetBrewery(int id)
        {
            var brewery = await _service.GetAsync(id);

            if (brewery == null)
                return NotFound();

            BreweryDto result = _mapper.Map<BreweryDto>(brewery);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BreweryDto>> PostBrewery(BreweryDto breweryDto)
        {
            Brewery result = _mapper.Map<Brewery>(breweryDto);

            _service.Add(result);

            await _service.SaveAsync();

            return CreatedAtAction(nameof(GetBrewery), new { id = result.Id }, _mapper.Map<BreweryDto>(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrewery(int id, BreweryDto breweryDto)
        {
            if (id != breweryDto.Id)
            {
                return BadRequest();
            }

            Brewery result = _mapper.Map<Brewery>(breweryDto);

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
        public async Task<IActionResult> DeleteBrewery(int id)
        {
            var brewery = await _service.GetAsync(id);

            if (brewery == null)
                return NotFound();

            _service.Delete(id);

            await _service.SaveAsync();

            return NoContent();
        }

        private bool BreweryExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}