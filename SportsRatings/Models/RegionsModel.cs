using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SportsRatings.Models.Interfaces;

namespace SportsRatings.Models
{
    public class RegionsModel: IEntitiesModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Region name")]
        public string Name { get; set; } = null!;
    }
}
