using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportsRatings.Models
{
    public class SportsModel : IModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = String.Empty;

        [Range(1,5)]
        [DisplayName("Rate of Sport")]
        public int PersonalRate { get; set; }

        public int CategoryId { get; set; }

        public SportCategoriesModel Caterogy { get; set; } = null!;
    }
}
