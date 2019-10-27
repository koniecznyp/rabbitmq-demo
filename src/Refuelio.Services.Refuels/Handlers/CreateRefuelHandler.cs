using System;
using System.Threading.Tasks;
using Refuelio.Common.Commands;
using Refuelio.Common.Events;
using Refuelio.Services.Refuels.Domain.Models;
using Refuelio.Services.Refuels.Domain.Repositories;

namespace Refuelio.Services.Refuels.Handlers
{
    public class CreateRefuelHandler : ICommandHandler<CreateRefuel>
    {
        private readonly IRefuelRepository _refuelRepository;
        private readonly ICarRepository _carRepository;

        public CreateRefuelHandler(IRefuelRepository refuelRepository, ICarRepository carRepository)
        {
            _refuelRepository = refuelRepository;
            _carRepository = carRepository;
        }

        public async Task HandleAsync(CreateRefuel command)
        {
            var car = await _carRepository.GetAsync(command.CarId);
            if(car is null)
            {
                throw new Exception($"Car with id {command.CarId} does not exists");
            }
            var refuel = new Refuel(command.Id, command.CarId, command.Date, 
                command.Liters, command.LiterPrice, command.Mielage);
            await _refuelRepository.AddAsync(refuel);
        }
    }
}