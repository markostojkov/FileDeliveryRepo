using System.Threading;
using System.Threading.Tasks;

using FileDeliveryService.Common.Mediator.Contracts;
using FileDeliveryService.Common.Mediator.Util;
using FileDeliveryService.Common.ValueObjects;
using FileDeliveryService.Contracts.FileDelivery.Response;
using FileDeliveryService.Persistence.Repositories.Interfaces;

namespace FileDeliveryService.Service.FileDelivery.Commands
{
    public sealed class GetPaginatedPackets
    {
        public class Command : ICommand<PaginatedPacketsResponse>
        {
            public Command(PagingValue paging)
            {
                Paging = paging;
            }

            public PagingValue Paging { get; }
        }

        public class Handler : ICommandHandler<Command, PaginatedPacketsResponse>
        {
            public Handler(IPacketRepository packetRepository)
            {
                PacketRepository = packetRepository;
            }

            public IPacketRepository PacketRepository { get; }

            public async Task<PaginatedPacketsResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                return await PacketRepository.GetPacketsPaginated(request.Paging);
            }
        }
    }
}
