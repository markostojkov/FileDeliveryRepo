using FileDeliveryService.Common.Mediator.Contracts;
using MediatR;

namespace FileDeliveryService.Common.Mediator.Util
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
    }
}