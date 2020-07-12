using API.Dtos;
using AutoMapper;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
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

            await _saleHeaderService.Validate(result);
            await _saleHeaderService.Compute(result);

            _saleHeaderService.Add(result);

            await _saleHeaderService.SaveAsync();

            return CreatedAtAction(nameof(GetSale), new { id = result.Id }, _mapper.Map<SaleHeaderDto>(result));
        }
    }
}