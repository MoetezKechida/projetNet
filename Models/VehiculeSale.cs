using System;

namespace projetNet.Models
{
    public class VehiculeSale
    {
        public Guid Id { get; set; }
        public Guid OfferId { get; set; }
        public string BuyerId { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Status { get; set; } = "attempt";
    }
}
