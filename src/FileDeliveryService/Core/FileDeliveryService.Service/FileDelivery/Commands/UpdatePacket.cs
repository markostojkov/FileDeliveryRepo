using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FileDeliveryService.Common.Error;
using FileDeliveryService.Common.Mediator.Contracts;
using FileDeliveryService.Common.Mediator.Util;
using FileDeliveryService.Contracts.FileDelivery.Response;
using FileDeliveryService.Persistence.Repositories.Interfaces;
using FileDeliveryService.Service.FileDelivery.ValueObjects;

namespace FileDeliveryService.Service.FileDelivery.Commands
{
    public sealed class UpdatePacket
    {
        public class Command : ICommand<UpdatedPacketResponse>
        {
            public Command(Guid packetUid, CountryCodeValue countryCode, PacketVersionValue packetVersion, PacketVersionValue currentVersion)
            {
                PacketUid = packetUid;
                CountryCode = countryCode;
                PacketVersion = packetVersion;
                CurrentVersion = currentVersion;
            }

            public Guid PacketUid { get; }

            public CountryCodeValue CountryCode { get; }

            public PacketVersionValue PacketVersion { get; }

            public PacketVersionValue CurrentVersion { get; }
        }

        public class Handler : ICommandHandler<Command, UpdatedPacketResponse>
        {
            public Handler(IPacketRepository packetRepository)
            {
                PacketRepository = packetRepository;
            }

            public IPacketRepository PacketRepository { get; }

            public async Task<UpdatedPacketResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var packetToCheck = await PacketRepository.GetPacketWithVersionsByUid(request.PacketUid);
                var countriesPacketIsAvaliableIn = await PacketRepository.GetCountriesPacketIsAvaliableIn(request.PacketUid);

                bool packetAvaliableInCountry = countriesPacketIsAvaliableIn.Any(x => x.Code.Equals(request.CountryCode.Value, StringComparison.OrdinalIgnoreCase));
                bool packetReleaseDateIsInThePast =
                    DateTime.UtcNow > packetToCheck.Versions.Single(x => x.VersionNumber == request.PacketVersion.VersionCode).VersionPublish;
                bool packetVersionNotMultiStage = request.PacketVersion.VersionCode - 1 == request.CurrentVersion.VersionCode;

                var errorResponse = new ErrorResponse();
                if (!packetAvaliableInCountry) errorResponse.AddError(ErrorCodes.PacketNotAvaliableInCountry);
                if (!packetReleaseDateIsInThePast) errorResponse.AddError(ErrorCodes.PacketNotReleased);
                if (!packetVersionNotMultiStage) errorResponse.AddError(ErrorCodes.PacketVersionMultiStage);
                errorResponse.ThrowIfErrors();

                return new UpdatedPacketResponse(
                    packetToCheck.Versions.Single(x => x.VersionNumber == request.PacketVersion.VersionCode).VersionCode,
                    packetToCheck.Versions.Single(x => x.VersionNumber == request.CurrentVersion.VersionCode).VersionCode);
            }
        }
    }
}
