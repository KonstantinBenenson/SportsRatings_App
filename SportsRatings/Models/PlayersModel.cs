using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportsRatings.Models.Interfaces;

namespace SportsRatings.Models
{
    public class PlayersModel : IEntitiesModel
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }

        public string Background { get; set; }

        //Ratings
        [Range(1, 5, ErrorMessage = "Value must be beetween 1 and 5")]
        public double MechanicsRate { get; set; }

        [Range(1, 5, ErrorMessage = "Value must be beetween 1 and 5")]
        public double MentalityRate { get; set; }

        [Range(1, 5, ErrorMessage = "Value must be beetween 1 and 5")]
        public double TeamWorkRate { get; set; }

        [DisplayName("Average Rating")]
        public double AverageRating { get; set; }

        //Relations
        public int? RegionId { get; set; }
        [ForeignKey("RegionId")]
        public RegionsModel Region { get; set; }

        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public TeamsModel Team { get; set; }

        public int SportId { get; set; }
        [ForeignKey("SportId")]
        public SportsModel Sport { get; set; }

    }
}
