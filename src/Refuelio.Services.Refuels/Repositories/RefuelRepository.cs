using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Refuelio.Services.Refuels.Domain.Models;
using Refuelio.Services.Refuels.Domain.Repositories;

namespace Refuelio.Services.Refuels.Repositories
{
    public class RefuelRepository : IRefuelRepository
    {
        private readonly IMongoDatabase _database;
 
        public RefuelRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<Refuel> _refuels
            => _database.GetCollection<Refuel>("refuels");

        public async Task AddAsync(Refuel refuel)
            => await _refuels.InsertOneAsync(refuel);

        public async Task DeleteAsync(Guid id)
            => await _refuels.DeleteOneAsync(x => x.Id == id);

        public async Task<Refuel> GetAsync(Guid id)
            => await _refuels.Find(x => x.Id == id).SingleOrDefaultAsync();
    }
}