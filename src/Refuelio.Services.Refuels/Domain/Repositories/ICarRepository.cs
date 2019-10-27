using System;
using System.Threading.Tasks;
using Refuelio.Services.Refuels.Domain.Models;

namespace Refuelio.Services.Refuels.Domain.Repositories
{
    public interface ICarRepository
    {
        Task AddAsync(Car car);
        Task<Car> GetAsync(Guid id);
    }
}