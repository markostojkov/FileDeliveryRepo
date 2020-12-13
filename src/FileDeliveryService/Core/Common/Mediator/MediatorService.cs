using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

using FileDeliveryService.Common.Mediator.Contracts;
using FileDeliveryService.Common.Mediator.Interfaces;

namespace FileDeliveryService.Common.Mediator
{
    public class MediatorService : IMediatorService
    {
        private readonly IMediator mediator;

        public MediatorService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task PublishAsync(object notification)
        {
            await PublishAsync(notification, default);
        }

        public async Task PublishAsync<TNotification>(TNotification notification)
            where TNotification : IPublishNotification
        {
            await PublishAsync(notification, default);
        }

        [DisplayName("{0}")]
        public async Task PublishAsync<TNotification>(string jobName, TNotification notification)
            where TNotification : IPublishNotification
        {
            await PublishAsync(notification, default);
        }

        public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request)
        {
            return await SendAsync(request, default);
        }

        public async Task<object> SendAsync(object request)
        {
            return await SendAsync(request, default);
        }

        public async Task PublishAsync(object notification, CancellationToken cancellationToken)
        {
            await mediator.Publish(notification, cancellationToken);
        }

        public async Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken)
            where TNotification : IPublishNotification
        {
            await mediator.Publish(notification, cancellationToken);
        }

        public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken)
        {
            return await mediator.Send(request, cancellationToken);
        }

        public async Task<object> SendAsync(object request, CancellationToken cancellationToken)
        {
            return await mediator.Send(request, cancellationToken);
        }
    }
}
