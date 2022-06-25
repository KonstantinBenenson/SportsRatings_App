using System.ComponentModel.DataAnnotations;

namespace SportsRatings.Models
{
    public class RegionsModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
