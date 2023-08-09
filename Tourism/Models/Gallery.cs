using System.ComponentModel.DataAnnotations;

namespace Tourism.Models
{
    public class Gallery
    {
        [Key]
        public int? Id { get; set; }

        public byte[]? ImageData { get; set; }
    }
}
