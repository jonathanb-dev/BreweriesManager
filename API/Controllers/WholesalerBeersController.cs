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
    public class WholesalerBeersController : ControllerBase
    {
        private readonly IWholesalerBeerService _wholesalerBeerService;
        private readonly IWholesalerService _wholesalerService;
        private readonly IBeerService _beerService;

        private readonly IMapper _mapper;

        public WholesalerBeersController(
            IWholesalerBeerService wholesalerBeerService,
            IWholesalerService wholesalerService,
            IBeerService beerService,
            IMapper mapper
        )
        {
            _wholesalerBeerService = wholesalerBeerService;
            _wholesalerService = wholesalerService;
            _beerService = beerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WholesalerBeerDto>> GetWholesalerBeer(int wholesalerId, int beerId)
        {
            var wholesalerBeer = await _wholesalerBeerService.GetAsync(wholesalerId, beerId);

            if (wholesalerBeer == null)
                return NotFound();

            WholesalerBeerDto result = _mapper.Map<WholesalerBeerDto>(wholesalerBeer);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<WholesalerBeerDto>> PostWholesalerBeer(PostWholesalerBeerDto postWholesalerBeerDto)
        {
            Wholesaler wholesaler = await _wholesalerService.GetAsync(postWholesalerBeerDto.WholesalerId);

            if (wholesaler == null)
                return NotFound();

            Beer beer = await _beerService.GetAsync(postWholesalerBeerDto.BeerId);

            if (beer == null)
                return NotFound();

            WholesalerBeer result = _mapper.Map<WholesalerBeer>(postWholesalerBeerDto);

            _wholesalerBeerService.Add(result);

            await _wholesalerBeerService.SaveAsync();

            return CreatedAtAction(nameof(GetWholesalerBeer), new { wholesalerId = result.WholesalerId, beerId = result.BeerId }, _mapper.Map<WholesalerBeerDto>(result));
        }
    }
}