using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using FileDeliveryService.Common.Mediator.Interfaces;
using FileDeliveryService.Common.ValueObjects;
using FileDeliveryService.Service.FileDelivery.Commands;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacketController : ControllerBase
    {
        public IMediatorService MediatorService { get; }

        public PacketController(IMediatorService mediatorService)
        {
            MediatorService = mediatorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int? page, int? pageSize)
        {
            var pagingValue = PagingValue.Create(page, pageSize);
            var response = await MediatorService.SendAsync(new GetPaginatedPackets.Command(pagingValue));

            return Ok(response);
        }

        [HttpGet("{packetUid:guid}")]
        public async Task<IActionResult> Get([FromRoute]Guid packetUid)
        {
            var response = await MediatorService.SendAsync(new GetPacketDetail.Command(packetUid));

            return Ok(response);
        }
    }
}
