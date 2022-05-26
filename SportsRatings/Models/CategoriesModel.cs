using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsRatings.Models
{
    public class CategoriesModel: IModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("CATEGORY NAME")]
        public string Name { get; set; } = String.Empty;

        [DisplayName("CATEGORY DESCRIPTION")]
        public string? Description { get; set; }

        public IEnumerable<SportsModel>? Sports { get; set; } = null!;
    }
}
