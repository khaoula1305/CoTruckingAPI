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
    public class AddressController(IAddressService _addressService) : ControllerBase
    {
        #region HttpMethodx
        [HttpGet, Authorize(FunctionalityConstants.VIEW, PageConstant.Address)]
        [ProducesResponseType(typeof(IEnumerable<AddressResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllCities()
        {
            return Ok(await _addressService.GetAllAsync());
        }

        [HttpGet("KeyValue")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Address)]
        [ProducesResponseType(typeof(KeyValueModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllAddresssAutocomplete()
        {
            return Ok(await _addressService.GetKeyValueAsync());
        }

        [HttpGet("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Address)]
        [ProducesResponseType(typeof(AddressResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAddress(Guid id)
        {
            return Ok(await _addressService.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize(FunctionalityConstants.ADD, PageConstant.Address)]
        public async Task<IActionResult> Create(AddressInput AddressDto)
        {
            return Ok(await _addressService.AddAsync(AddressDto));
        }

        [HttpPut("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Address)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(AddressInput AddressDto, Guid id)
        {
            return Ok(await _addressService.Update(AddressDto, id));

        }

        [HttpDelete("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Address)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _addressService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            return Ok(await _addressService.Delete(id));
        }

        [HttpPost("Search")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Address)]
        [ProducesResponseType(typeof(IEnumerable<AddressResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Search(RequestModel<AddressSearch> RequestModel)
        {
            return Ok(await _addressService.GetAllByPage(RequestModel));

        }

        [HttpPost("Export")]
        [Authorize(FunctionalityConstants.EXPORT, PageConstant.Address)]
        public async Task<IActionResult> ExportExcel(AddressSearch RequestModel)
        {
            var res = await _addressService.ExporttoExcel<AddressSearch>(x => true, PageConstant.Address);
            return File(res, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        #endregion
    }
}
