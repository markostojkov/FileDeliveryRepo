using MediatR;

namespace FileDeliveryService.Common.Mediator.Contracts
{
    public interface IPublishNotificationHandler<T> : INotificationHandler<T>
        where T : INotification
    {
    }
}