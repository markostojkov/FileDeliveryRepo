using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using FileDeliveryService.Common.Mediator.Interfaces;
using FileDeliveryService.Service.FileDelivery.Commands;
using FileDeliveryService.Service.FileDelivery.ValueObjects;

namespace API.Controllers
{
    [Route("api/packet/{packetUid:guid}/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        public VersionController(IMediatorService mediatorService)
        {
            MediatorService = mediatorService;
        }

        public IMediatorService MediatorService { get; }

        [HttpGet("{version:int}")]
        public async Task<IActionResult> Get([FromRoute] Guid packetUid, [FromRoute] int version, [FromQuery] string country, [FromQuery] int versionFrom)
        {
            var countryCodeValue = CountryCodeValue.Create(country);
            var packetVersionValue = PacketVersionValue.Create(version);
            var packetVersionFromValue = PacketVersionValue.Create(versionFrom);

            PacketVersionValue.CheckIfVersionToUpdateIsNotDowngrade(versionFrom, version);

            var result = await MediatorService.SendAsync(new UpdatePacket.Command(packetUid, countryCodeValue, packetVersionValue, packetVersionFromValue));

            return Ok(result);
        }
    }
}
