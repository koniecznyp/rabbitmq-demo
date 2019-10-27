using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Refuelio.Services.Refuels.Domain.Models;
using Refuelio.Services.Refuels.Domain.Repositories;

namespace Refuelio.Services.Refuels.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IMongoDatabase _database;
 
        public CarRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<Car> _cars 
            => _database.GetCollection<Car>("cars");

        public async Task AddAsync(Car car)
            => await _cars.InsertOneAsync(car);

        public async Task<Car> GetAsync(Guid id)
            => await _cars.Find(x => x.Id == id).SingleOrDefaultAsync();
    }
}