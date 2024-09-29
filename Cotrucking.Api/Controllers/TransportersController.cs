using Cotrucking.Domain.Constants;
using Cotrucking.Domain.Models.Common;
using Cotrucking.Domain.Models;
using Cotrucking.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Cotrucking.Api.Helpers;

namespace Cotrucking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController(IDriverService transporterService) : ControllerBase
    {
        #region HttpMethod
        [HttpGet]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Driver)]
        [ProducesResponseType(typeof(IEnumerable<DriverResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await transporterService.GetAllAsync());
        }

        [HttpGet("KeyValue")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Driver)]
        [ProducesResponseType(typeof(KeyValueModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllAutocomplete()
        {
            return Ok(await transporterService.GetKeyValueAsync());
        }

        [HttpGet("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Driver)]
        [ProducesResponseType(typeof(DriverResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDriver(Guid id)
        {
            return Ok(await transporterService.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize(FunctionalityConstants.ADD, PageConstant.Driver)]
        public async Task<IActionResult> Create(DriverInput DriverDto)
        {
            return Ok(await transporterService.AddAsync(DriverDto));
        }

        [HttpPut("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Driver)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(DriverInput DriverDto, Guid id)
        {
            return Ok(await transporterService.Update(DriverDto, id));

        }

        [HttpDelete("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Driver)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await transporterService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            return Ok(await transporterService.Delete(id));
        }

        [HttpPost("Search")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Driver)]
        [ProducesResponseType(typeof(IEnumerable<DriverResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Search(RequestModel<DriverSearch> RequestModel)
        {
            return Ok(await transporterService.GetAllByPage(RequestModel));

        }

        [HttpPost("Export")]
        [Authorize(FunctionalityConstants.EXPORT, PageConstant.Driver)]
        public async Task<IActionResult> ExportExcel(DriverSearch RequestModel)
        {
            var res = await transporterService.ExporttoExcel<DriverSearch>(x => true, PageConstant.Driver);
            return File(res, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        #endregion

    }
}
