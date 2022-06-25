using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsRatings.Models
{
    public class TeamsModel : IModel
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
        public RegionsModel Region { get; set; }

        [DisplayName("Sport")]
        public int SportId { get; set; }
        [ForeignKey("SportId")]
        public SportsModel Sport { get; set; }

        public IEnumerable<PlayersModel> Players { get; set; }
    }
}
