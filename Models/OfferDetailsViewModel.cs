using System.Collections.Generic;

namespace projetNet.Models
{
    public class OfferDetailsViewModel
    {
        public Offer Offer { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<VehiculeSale> Sales { get; set; }
    }
}