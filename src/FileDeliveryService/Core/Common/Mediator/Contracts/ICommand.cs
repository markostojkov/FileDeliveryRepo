using MediatR;

namespace FileDeliveryService.Common.Mediator.Contracts
{
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}