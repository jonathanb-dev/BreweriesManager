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
    public class SalesController : ControllerBase
    {
        private readonly ISaleHeaderService _saleHeaderService;
        private readonly IWholesalerService _wholesalerService;
        private readonly IBeerService _beerService;

        private readonly IMapper _mapper;

        public SalesController(
            ISaleHeaderService saleHeaderService,
            IWholesalerService wholesalerService,
            IBeerService beerService,
            IMapper mapper
        )
        {
            _saleHeaderService = saleHeaderService;
            _wholesalerService = wholesalerService;
            _beerService = beerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleHeaderListDto>>> GetSales()
        {
            var saleHeaders = await _saleHeaderService.ListAsync();

            IEnumerable<SaleHeaderListDto> result = _mapper.Map<IEnumerable<SaleHeaderListDto>>(saleHeaders);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleHeaderDto>> GetSale(int id)
        {
            var saleHeader = await _saleHeaderService.GetAsync(id);

            if (saleHeader == null)
                return NotFound();

            SaleHeaderDto result = _mapper.Map<SaleHeaderDto>(saleHeader);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SaleHeaderDto>> PostSale(PostSaleHeaderDto postSaleHeaderDto)
        {
            Wholesaler wholesaler = await _wholesalerService.GetAsync(postSaleHeaderDto.WholeSalerId);

            if (wholesaler == null)
                return NotFound();

            SaleHeader result = _mapper.Map<SaleHeader>(postSaleHeaderDto);

            result.Wholesaler = wholesaler;

            _saleHeaderService.Add(result);

            await _saleHeaderService.SaveAsync();

            return CreatedAtAction(nameof(GetSale), new { id = result.Id }, _mapper.Map<SaleHeaderDto>(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, PutSaleHeaderDto putSaleHeaderDto)
        {
            if (id != putSaleHeaderDto.Id)
            {
                return BadRequest();
            }

            Wholesaler wholesaler = await _wholesalerService.GetAsync(putSaleHeaderDto.WholeSalerId);

            if (wholesaler == null)
                return NotFound();

            SaleHeader result = _mapper.Map<SaleHeader>(putSaleHeaderDto);

            result.Wholesaler = wholesaler;

            _saleHeaderService.Update(result);

            try
            {
                await _saleHeaderService.SaveAsync();
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
        public async Task<IActionResult> DeleteSale(int id)
        {
            var saleHeader = await _saleHeaderService.GetAsync(id);

            if (saleHeader == null)
                return NotFound();

            _saleHeaderService.Delete(id);

            await _saleHeaderService.SaveAsync();

            return NoContent();
        }

        private bool SaleExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}