using System;

namespace Refuelio.Common.Events
{
    public class CarCreated : IEvent
    {
        public Guid Id { get; set; }
        
        public CarCreated(Guid id)
        {
            Id = id;
        }
    }
}