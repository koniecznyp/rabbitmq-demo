using System.Threading.Tasks;

namespace Refuelio.Common.Events
{
    public interface IEventHandler<T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}