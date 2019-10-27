using System;

namespace Refuelio.Common.Commands
{
    public class CreateCar : ICommand
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}