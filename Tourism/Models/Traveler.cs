using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourism.Models
{
    public class Traveler
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public double? Phone { get; set; }

        [ForeignKey("Trips")]
        public int? TripId { get; set; }

        public ICollection<FeedBack>? FeedBacks { get; set; }

    }
}
