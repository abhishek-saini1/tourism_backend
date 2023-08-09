using System.ComponentModel.DataAnnotations;

namespace Tourism.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public double? Phone { get; set; }
        public bool? IsApproved { get; set; }
        public ICollection<Trips>? trips { get; set;}
        


    }
}
