using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tourism.Models
{
    public class BookingTrip
    {
        [Key]
        //[ForeignKey("Traveler")]
        public int BookingId { get; set; }

        public string? TravelerName { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Destination { get; set; }
        public int? NumberOfTravelers { get; set; }
        public string? Description { get; set; }
        public string? Accommodation { get; set; }
        
        public string? DestinationUrl { get; set;}
        public ICollection<Traveler>? Travelers { get; private set; }

        [ForeignKey("Trips")]
        public int? TripId { get; set; }

        // public bool IsRoundTrip { get; set; }
    }
}
