using System.ComponentModel.DataAnnotations;

namespace Tourism.Models
{
    public class Admin
    {
        [Key]
        public int AId { get; set; }

        public string? AUserName { get; set; }

        public string? APassword { get; set;}

        public string? AEmail { get; set;}





    }
}
