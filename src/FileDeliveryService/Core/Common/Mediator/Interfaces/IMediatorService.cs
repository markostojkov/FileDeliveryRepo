using System.Threading;
using System.Threading.Tasks;

using FileDeliveryService.Common.Mediator.Contracts;

namespace FileDeliveryService.Common.Mediator.Interfaces
{
    public interface IMediatorService
    {
        Task PublishAsync(object notification);

        Task PublishAsync<TNotification>(TNotification notification)
            where TNotification : IPublishNotification;

        Task PublishAsync<TNotification>(string jobName, TNotification notification)
            where TNotification : IPublishNotification;

        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request);

        Task<object> SendAsync(object request);

        Task PublishAsync(object notification, CancellationToken cancellationToken);

        Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken)
            where TNotification : IPublishNotification;

        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken);

        Task<object> SendAsync(object request, CancellationToken cancellationToken);
    }
}
