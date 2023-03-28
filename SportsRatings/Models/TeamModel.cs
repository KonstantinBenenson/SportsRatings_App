using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportsRatings.Models.Interfaces;

namespace SportsRatings.Models
{
    public class TeamModel
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
        public RegionModel Region { get; set; }

        [DisplayName("Sport")]
        public int SportId { get; set; }
        [ForeignKey("SportId")]
        public SportModel Sport { get; set; }

        public IEnumerable<PlayerModel> Players { get; set; }
    }
}
