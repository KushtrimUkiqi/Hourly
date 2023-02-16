namespace Services.Common
{
    using Contracts.Common.Infrastructure;
    using System.Threading.Tasks;

    using MassTransit;

    public sealed class EventBus : IEventBus
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EventBus(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishAsync<T>(T message) where T : class 
        {
           await _publishEndpoint.Publish<T>(message);
        }
    }
}
