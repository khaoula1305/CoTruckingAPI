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
    public class TransportersController(ITransporterService transporterService) : ControllerBase
    {
        #region HttpMethod
        [HttpGet]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Transporter)]
        [ProducesResponseType(typeof(IEnumerable<TransporterResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await transporterService.GetAllAsync());
        }

        [HttpGet("KeyValue")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Transporter)]
        [ProducesResponseType(typeof(KeyValueModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllAutocomplete()
        {
            return Ok(await transporterService.GetKeyValueAsync());
        }

        [HttpGet("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Transporter)]
        [ProducesResponseType(typeof(TransporterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetTransporter(Guid id)
        {
            return Ok(await transporterService.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize(FunctionalityConstants.ADD, PageConstant.Transporter)]
        public async Task<IActionResult> Create(TransporterInput TransporterDto)
        {
            return Ok(await transporterService.AddAsync(TransporterDto));
        }

        [HttpPut("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Transporter)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(TransporterInput TransporterDto, Guid id)
        {
            return Ok(await transporterService.Update(TransporterDto, id));

        }

        [HttpDelete("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Transporter)]
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
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Transporter)]
        [ProducesResponseType(typeof(IEnumerable<TransporterResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Search(RequestModel<TransporterSearch> RequestModel)
        {
            return Ok(await transporterService.GetAllByPage(RequestModel));

        }

        [HttpPost("Export")]
        [Authorize(FunctionalityConstants.EXPORT, PageConstant.Transporter)]
        public async Task<IActionResult> ExportExcel(TransporterSearch RequestModel)
        {
            var res = await transporterService.ExporttoExcel<TransporterSearch>(x => true, PageConstant.Transporter);
            return File(res, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        #endregion

    }
}
