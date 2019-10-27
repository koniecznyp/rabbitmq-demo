using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Refuelio.Services.Refuels.Domain.Models
{
    public class Car
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public Car(Guid id)
        {
            Id = id;
        }
    }
}