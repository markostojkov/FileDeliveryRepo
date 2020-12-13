using MediatR;

namespace FileDeliveryService.Common.Mediator.Contracts
{
    public interface IPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
    }
}
