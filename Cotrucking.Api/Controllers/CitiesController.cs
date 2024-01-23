using Cotrucking.Api.Helpers;
using Cotrucking.Domain.Constants;
using Cotrucking.Domain.Models;
using Cotrucking.Domain.Models.Common;
using Cotrucking.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cotrucking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController(ICityService _cityService) : ControllerBase
    {
        #region HttpMethod
        [HttpGet]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.City)]
        [ProducesResponseType(typeof(IEnumerable<CityResponse>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllCities()
        {
            return Ok(await _cityService.GetAllAsync());
        }

        [HttpGet("KeyValue")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.City)]
        [ProducesResponseType(typeof(KeyValueModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllCitysAutocomplete()
        {
            return Ok(await _cityService.GetKeyValueAsync());
        }

        [HttpGet("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.City)]
        [ProducesResponseType(typeof(CityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCity(Guid id)
        {
            return Ok(await _cityService.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize(FunctionalityConstants.ADD, PageConstant.City)]
        public async Task<IActionResult> Create(CityInput CityDto)
        {
            return Ok(await _cityService.AddAsync(CityDto));
        }

        [HttpPut("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.City)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(CityInput CityDto, Guid id)
        {
            return Ok(await _cityService.Update(CityDto, id));

        }

        [HttpDelete("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.City)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _cityService.GetByIdAsync(id);
            if(entity == null)
                return NotFound();
            return Ok(await _cityService.Delete(id));
        }

        [HttpPost("Search")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.City)]
        [ProducesResponseType(typeof(IEnumerable<CityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Search(RequestModel<CitySearch> RequestModel)
        {
            return Ok(await _cityService.GetAllByPage(RequestModel));
            
        }

        [HttpPost("Export")]
        [Authorize(FunctionalityConstants.EXPORT, PageConstant.City)]
        public async Task<IActionResult> ExportExcel(CitySearch RequestModel)
        {
            var res = await _cityService.ExporttoExcel<CitySearch>( x => true,PageConstant.City);
            return File(res, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        #endregion
    }
}
