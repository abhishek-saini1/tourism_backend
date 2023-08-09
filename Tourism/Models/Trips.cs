using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourism.Models
{
    public class Trips
    {
        [Key]
        public int TId { get; set; }
        public string? Destination { get; set; }


        public string? TDetails { get; set; }

        public decimal? RatesPerDay { get; set; }

        public decimal? RatesPerHour { get; set; }

        public decimal? RatesPerTourPack { get; set; }
        public string? Itinerary { get; set; }
        public string? FoodAndAccommodation { get; set; }

        [ForeignKey("Agent")]
        public int? AgentId { get; set; }

        public ICollection<BookingTrip>? Trip { get; set; }
        
        




    }
}
