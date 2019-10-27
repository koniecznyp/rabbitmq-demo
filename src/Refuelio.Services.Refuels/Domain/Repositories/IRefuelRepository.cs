using System;
using System.Threading.Tasks;
using Refuelio.Services.Refuels.Domain.Models;

namespace Refuelio.Services.Refuels.Domain.Repositories
{
    public interface IRefuelRepository
    {
        Task AddAsync(Refuel refuel);
        Task<Refuel> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}