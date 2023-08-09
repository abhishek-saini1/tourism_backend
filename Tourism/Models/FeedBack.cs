using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tourism.Models
{
    public class FeedBack
    {
        [Key]
        public  int FId { get; set; }
        public string? Name { get; set; }
        public string? FeedBackTitle { get; set; }

        [ForeignKey("Traveler")]
        public int? TravelerID { get; set; }


    }
}
