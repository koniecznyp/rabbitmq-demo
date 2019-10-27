using System.Threading.Tasks;
using RawRabbit;
using Refuelio.Common.Commands;
using Refuelio.Common.Events;
using Refuelio.Services.Cars.Domain.Models;
using Refuelio.Services.Cars.Domain.Repositories;

namespace Refuelio.Services.Cars.Handlers
{
    public class CreateCarHandler : ICommandHandler<CreateCar>
    {
        private readonly IBusClient _busClient;
        private readonly ICarRepository _carRepository;

        public CreateCarHandler(IBusClient busClient, ICarRepository carRepository)
        {
            _busClient = busClient;
            _carRepository = carRepository;
        }

        public async Task HandleAsync(CreateCar command)
        {
            var car = new Car(command.Id, command.Brand, command.Model, command.Plate);
            await _carRepository.AddAsync(car);
            await _busClient.PublishAsync(new CarCreated(command.Id));
        }
    }
}