using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RawRabbit;
using RawRabbit.Common;
using Refuelio.Common.Commands;
using Refuelio.Common.Events;

namespace Refuelio.Common.RabbitMq
{
    public class BusSubscriber : IBusSubscriber
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IBusClient _busClient;

        public BusSubscriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            _busClient = _serviceProvider.GetService<IBusClient>();
            var t  = _serviceProvider.GetService<IMongoDatabase>();
        }

        public IBusSubscriber SubscribeCommand<TCommand>() where TCommand : ICommand
        {
            _busClient.SubscribeAsync<TCommand>(async (command) =>
            {
                var commandHandler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
                return await TryHandleAsync(command,
                    () => commandHandler.HandleAsync(command));
            });
            return this;
        }

        public IBusSubscriber SubscribeEvent<TEvent>() where TEvent : IEvent
        {
            _busClient.SubscribeAsync<TEvent>(async (@event) => {
                var handler = _serviceProvider.GetService<IEventHandler<TEvent>>();
                return await TryHandleAsync(@event, () => handler.HandleAsync(@event));
            });
            return this;
        }

        private async Task<Acknowledgement> TryHandleAsync<TMessage>(TMessage message, Func<Task> handle)
        {
            try
            {
                await handle();
                return new Ack();
            }
            catch(Exception ex)
            {
                var messageName = message.GetType().Name;
                throw new Exception($"Unable to handle a message: '{messageName}'");
            }
        }
    }
}