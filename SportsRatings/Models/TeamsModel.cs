using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportsRatings.Models.Interfaces;

namespace SportsRatings.Models
{
    public class TeamsModel: IEntitiesModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        //Relations
        [DisplayName("Region")]
        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public RegionsModel Region { get; set; } = null!;

        [DisplayName("Sport")]
        public int SportId { get; set; }
        [ForeignKey("SportId")]
        public SportsModel Sport { get; set; } = null!;

        public IEnumerable<PlayersModel> Players { get; set; }
    }
}
