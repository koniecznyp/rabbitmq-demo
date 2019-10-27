using System.Threading.Tasks;
using Refuelio.Common.Events;

namespace Refuelio.Common.RabbitMq
{
    public interface IBusPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}