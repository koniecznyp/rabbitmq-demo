using Refuelio.Common.Commands;
using Refuelio.Common.Events;

namespace Refuelio.Common.RabbitMq
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>() where TCommand : ICommand;
        IBusSubscriber SubscribeEvent<TEvent>() where TEvent : IEvent;
    }
}