using System.Collections.Generic;

namespace projetNet.Models
{
    public class OfferDetailsViewModel
    {
        public required Offer Offer { get; set; }
        public required Vehicle Vehicle { get; set; }
        public List<Booking>? Bookings { get; set; }
        public List<VehiculeSale>? Sales { get; set; }
    }
}