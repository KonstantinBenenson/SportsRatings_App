using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsRatings.Models
{
    public class SportsModel : IModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; } 

        [Range(1, 5, ErrorMessage = "Value must be beetween 1 and 5")]
        [DisplayName("Rate of Sport")]
        public int? PersonalRate { get; set; } //How much a user loves this sport

        [DisplayName("Category")]
        public int CategoryId { get; set; }
       
        [ForeignKey("CategoryId")]
        public CategoriesModel Category { get; set; } = null!;
    }
}
