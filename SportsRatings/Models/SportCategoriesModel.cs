using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsRatings.Models
{
    public class SportCategoriesModel :IModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("YOUR NEW CATEGORY")]
        public string Name { get; set; } = String.Empty;

        public IEnumerable<SportsModel>? Sports { get; set; } = null!;
    }
}
