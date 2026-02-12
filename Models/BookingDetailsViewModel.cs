using System.Net.Mime;

namespace projetNet.Models;

public class BookingDetailsViewModel
{
    
        public Booking Booking { get; set; } = null!;
        public Vehicle Vehicle { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!; 
        // In MyBookings → this will be Seller
        // In Requests → this will be Buyer
    
}