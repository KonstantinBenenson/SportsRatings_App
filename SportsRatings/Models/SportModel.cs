using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportsRatings.Models.Interfaces;

namespace SportsRatings.Models
{
    public class SportModel : SportBase
    {
        [Key]
        public int Id { get; set; }        
    }

    public class SportBase 
    {
        [Required]
        public string Name { get; set; } = null!;

        public string Description { get; set; }

        [Range(1, 5, ErrorMessage = "Value must be beetween 1 and 5")]
        [DisplayName("Rate of Sport")]
        public int? PersonalRate { get; set; } //How much a user loves this sport

        // Relations 

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; } = null!;
    }
}
