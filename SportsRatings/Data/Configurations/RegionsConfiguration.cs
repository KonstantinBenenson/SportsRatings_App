using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsRatings.Models;

namespace SportsRatings.Data.Configurations
{
    public class RegionsConfiguration : IEntityTypeConfiguration<RegionsModel>
    {
        public void Configure(EntityTypeBuilder<RegionsModel> builder)
        {
            builder.HasData(
                new RegionsModel
                {
                    Id = 1,
                    Name = "NA"
                },
                new RegionsModel
                {
                    Id = 2,
                    Name = "EU"
                },
                new RegionsModel
                {
                    Id = 3,
                    Name = "MINA"
                },
                new RegionsModel
                {
                    Id = 4,
                    Name = "SAM"
                },
                new RegionsModel
                {
                    Id = 5,
                    Name = "OCE"
                }
            );
        }
    }
}
