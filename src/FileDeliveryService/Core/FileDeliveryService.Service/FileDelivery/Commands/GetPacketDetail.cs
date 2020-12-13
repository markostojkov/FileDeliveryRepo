using System;
using System.Threading;
using System.Threading.Tasks;
using FileDeliveryService.Common.Error;
using FileDeliveryService.Common.Mediator.Contracts;
using FileDeliveryService.Common.Mediator.Util;
using FileDeliveryService.Contracts.FileDelivery.Response;
using FileDeliveryService.Persistence.Repositories.Interfaces;

namespace FileDeliveryService.Service.FileDelivery.Commands
{
    public sealed class GetPacketDetail
    {
        public class Command : ICommand<PacketDetailResponse>
        {
            public Command(Guid packetUid)
            {
                PacketUid = packetUid;
            }

            public Guid PacketUid { get; }
        }

        public class Handler : ICommandHandler<Command, PacketDetailResponse>
        {
            public Handler(IPacketRepository packetRepository)
            {
                PacketRepository = packetRepository;
            }

            public IPacketRepository PacketRepository { get; }

            public async Task<PacketDetailResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var packetDetail = await PacketRepository.GetPacketDetails(request.PacketUid);

                if (packetDetail is null)
                {
                    new ErrorResponse(ErrorCodes.PacketDoesNotExist).ThrowIfErrors();
                }

                return packetDetail;
            }
        }
    }
}
