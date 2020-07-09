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
    public class WholesalersController : ControllerBase
    {
        private readonly IWholesalerService _service;

        private readonly IMapper _mapper;

        public WholesalersController(IWholesalerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWholesalers()
        {
            var wholesalers = await _service.ListAsync();

            var mappedResult = _mapper.Map<IEnumerable<WholesalersListDto>>(wholesalers);

            return Ok(mappedResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWholesaler(int id)
        {
            var wholesaler = await _service.GetAsync(id);

            if (wholesaler == null)
                return NotFound();

            var mappedResult = _mapper.Map<WholesalerDto>(wholesaler);

            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<ActionResult<Wholesaler>> PostWholesaler(Wholesaler wholesaler)
        {
            _service.Add(wholesaler);

            await _service.SaveAsync();

            return CreatedAtAction(nameof(GetWholesaler), new { id = wholesaler.Id }); // TODO DTO
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWholesaler(int id, Wholesaler wholesaler)
        {
            if (id != wholesaler.Id)
            {
                return BadRequest();
            }

            _service.Update(wholesaler);

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
        public async Task<ActionResult<Wholesaler>> DeleteWholesaler(int id)
        {
            var wholesaler = await _service.GetAsync(id);

            if (wholesaler == null)
                return NotFound();

            _service.Delete(id);

            await _service.SaveAsync();

            return wholesaler;
        }

        private bool WholesalerExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}