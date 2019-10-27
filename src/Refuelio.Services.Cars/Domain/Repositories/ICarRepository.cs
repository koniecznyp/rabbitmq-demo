using System;
using System.Threading.Tasks;
using Refuelio.Services.Cars.Domain.Models;

namespace Refuelio.Services.Cars.Domain.Repositories
{
    public interface ICarRepository
    {
        Task AddAsync(Car car);
        Task<Car> GetAsync(Guid id);
    }
}