using Cotrucking.Domain.Constants;
using Cotrucking.Domain.Models.Common;
using Cotrucking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Cotrucking.Api.Helpers;
using Cotrucking.Services.Services;

namespace Cotrucking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(ICountryService countryService) : ControllerBase
    {
        #region HttpMethod
        [HttpGet]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Country)]
        [ProducesResponseType(typeof(IEnumerable<CountryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await countryService.GetAllAsync());
        }

        [HttpGet("KeyValue")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Country)]
        [ProducesResponseType(typeof(KeyValueModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllAutocomplete()
        {
            return Ok(await countryService.GetKeyValueAsync());
        }

        [HttpGet("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Country)]
        [ProducesResponseType(typeof(CountryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCountry(Guid id)
        {
            return Ok(await countryService.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize(FunctionalityConstants.ADD, PageConstant.Country)]
        public async Task<IActionResult> Create(CountryInput CountryDto)
        {
            return Ok(await countryService.AddAsync(CountryDto));
        }

        [HttpPut("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Country)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(CountryInput CountryDto, Guid id)
        {
            return Ok(await countryService.Update(CountryDto, id));

        }

        [HttpDelete("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Country)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await countryService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            return Ok(await countryService.Delete(id));
        }

        [HttpPost("Search")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Country)]
        [ProducesResponseType(typeof(IEnumerable<CountryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Search(RequestModel<CountrySearch> RequestModel)
        {
            return Ok(await countryService.GetAllByPage(RequestModel));

        }

        [HttpPost("Export")]
        [Authorize(FunctionalityConstants.EXPORT, PageConstant.Country)]
        public async Task<IActionResult> ExportExcel(CountrySearch RequestModel)
        {
            var res = await countryService.ExporttoExcel<CountrySearch>(x => true, PageConstant.Country);
            return File(res, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        #endregion

    }
}
