using System.ComponentModel.DataAnnotations;

namespace StatiumSystem.Models
{
    public class StadiumDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Url]
        public string ImageUrl { get; set; }
    }
}
