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
    public class ShipmentsController(IShipmentService shipmentService) : ControllerBase
    {
        #region HttpMethod
        [HttpGet]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Shipment)]
        [ProducesResponseType(typeof(IEnumerable<ShipmentResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllShipment()
        {
            return Ok(await shipmentService.GetAllAsync());
        }

        [HttpGet("KeyValue")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Shipment)]
        [ProducesResponseType(typeof(KeyValueModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllShipmentsAutocomplete()
        {
            return Ok(await shipmentService.GetKeyValueAsync());
        }

        [HttpGet("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Shipment)]
        [ProducesResponseType(typeof(ShipmentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetShipment(Guid id)
        {
            return Ok(await shipmentService.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize(FunctionalityConstants.ADD, PageConstant.Shipment)]
        public async Task<IActionResult> Create(ShipmentInput ShipmentDto)
        {
            return Ok(await shipmentService.AddAsync(ShipmentDto));
        }

        [HttpPut("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Shipment)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(ShipmentInput ShipmentDto, Guid id)
        {
            return Ok(await shipmentService.Update(ShipmentDto, id));

        }

        [HttpDelete("{id}")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Shipment)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await shipmentService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            return Ok(await shipmentService.Delete(id));
        }

        [HttpPost("Search")]
        [Authorize(FunctionalityConstants.VIEW, PageConstant.Shipment)]
        [ProducesResponseType(typeof(IEnumerable<ShipmentResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Search(RequestModel<ShipmentSearch> RequestModel)
        {
            return Ok(await shipmentService.GetAllByPage(RequestModel));
        }

        [HttpPost("Export")]
        [Authorize(FunctionalityConstants.EXPORT, PageConstant.Shipment)]
        public async Task<IActionResult> ExportExcel(ShipmentSearch RequestModel)
        {
            var res = await shipmentService.ExporttoExcel<ShipmentSearch>(x => true, PageConstant.Shipment);
            return File(res, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
        #endregion
    }
}
