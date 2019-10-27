using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Refuelio.Services.Cars.Domain.Models
{
    public class Car
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }

        protected Car()
        {
        }

        public Car(Guid id, string brand, string model, string plate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Plate = plate;
        }
    }
}