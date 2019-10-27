using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Refuelio.Services.Refuels.Domain.Models
{
    public class Refuel
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid CarId { get; set; }
        public DateTime Date { get; set; }
        public double Liters { get; set; }
        public double LiterPrice { get; set; }
        public int Mielage { get; set; }
        public DateTime CreatedAt { get; set; }

        public Refuel(Guid id, Guid carId, DateTime date, double liters, 
            double literPrice, int mielage)
        {
            Id = id;
            CarId = carId;
            Date = DateTime.UtcNow;
            SetLiters(liters);
            SetLiterPrice(literPrice);
            SetMielage(mielage);
            CreatedAt = DateTime.Now;
        }

        public void SetLiters(double liters)
        {
            if(liters <= 0)
            {
                throw new ArgumentException("The number of liters can not be less than or equal to 0");
            }
            Liters = liters;
        }

        public void SetLiterPrice(double literPrice)
        {
            if(literPrice <= 0)
            {
                throw new ArgumentException("The price of one liter of fuel can not be less than or equal to 0");
            }
            LiterPrice = literPrice;
        }

        public void SetMielage(int mileage)
        {
            if(mileage <= 0)
            {
                throw new ArgumentException("Mileage can not be less than or equal to 0");
            }
            Mielage = mileage;
        }
    }
}