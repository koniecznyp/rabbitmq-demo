using System.Threading.Tasks;
using Refuelio.Common.Events;
using Refuelio.Services.Refuels.Domain.Models;
using Refuelio.Services.Refuels.Domain.Repositories;

namespace Refuelio.Services.Refuels.Handlers
{
    public class CarCreatedHandler : IEventHandler<CarCreated>
    {
        private readonly ICarRepository _carRepository;

        public CarCreatedHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task HandleAsync(CarCreated @event)
        {
            await _carRepository.AddAsync(new Car(@event.Id));
        }
    }
}