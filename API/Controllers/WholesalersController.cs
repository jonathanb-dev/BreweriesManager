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
        public async Task<ActionResult<IEnumerable<WholesalerDto>>> GetWholesalers()
        {
            var wholesalers = await _service.ListAsync();

            IEnumerable<WholesalersListDto> result = _mapper.Map<IEnumerable<WholesalersListDto>>(wholesalers);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WholesalerDto>> GetWholesaler(int id)
        {
            var wholesaler = await _service.GetAsync(id);

            if (wholesaler == null)
                return NotFound();

            WholesalerDto result = _mapper.Map<WholesalerDto>(wholesaler);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<WholesalerDto>> PostWholesaler(PostWholesalerDto postWholesalerDto)
        {
            Wholesaler result = _mapper.Map<Wholesaler>(postWholesalerDto);

            _service.Add(result);

            await _service.SaveAsync();

            return CreatedAtAction(nameof(GetWholesaler), new { id = result.Id }, _mapper.Map<WholesalerDto>(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWholesaler(int id, PutWholesalerDto putWholesalerDto)
        {
            if (id != putWholesalerDto.Id)
            {
                return BadRequest();
            }

            Wholesaler result = _mapper.Map<Wholesaler>(putWholesalerDto);

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
        public async Task<IActionResult> DeleteWholesaler(int id)
        {
            var wholesaler = await _service.GetAsync(id);

            if (wholesaler == null)
                return NotFound();

            _service.Delete(id);

            await _service.SaveAsync();

            return NoContent();
        }

        private bool WholesalerExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}