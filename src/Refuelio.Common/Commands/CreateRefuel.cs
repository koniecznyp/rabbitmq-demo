using System;

namespace Refuelio.Common.Commands
{
    public class CreateRefuel : ICommand
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public DateTime Date { get; set; }
        public double Liters { get; set; }
        public double LiterPrice { get; set; }
        public int Mielage { get; set; }
    }
}