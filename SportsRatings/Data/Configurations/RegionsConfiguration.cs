using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsRatings.Models;

namespace SportsRatings.Data.Configurations
{
    public class RegionsConfiguration : IEntityTypeConfiguration<RegionModel>
    {
        public void Configure(EntityTypeBuilder<RegionModel> builder)
        {
            builder.HasData(
                new RegionModel
                {
                    Id = 1,
                    Name = "NA"
                },
                new RegionModel
                {
                    Id = 2,
                    Name = "EU"
                },
                new RegionModel
                {
                    Id = 3,
                    Name = "MINA"
                },
                new RegionModel
                {
                    Id = 4,
                    Name = "SAM"
                },
                new RegionModel
                {
                    Id = 5,
                    Name = "OCE"
                }
            );
        }
    }
}
