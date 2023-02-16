namespace Contracts.Common.Infrastructure
{

    public interface IEventBus
    {
        Task PublishAsync<T>(T message) where T : class;
    }
}
