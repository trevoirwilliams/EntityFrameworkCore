using EntityFrameworkNet5.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNet5.Data.Configurations.Entities
{
    public class TeamSeedConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                    new Team
                    {
                        Id = 20,
                        Name = "Trevoir Williams - Sample Team",
                        LeagueId = 20
                    },
                    new Team
                    {
                        Id = 21,
                        Name = "Trevoir Williams - Sample Team",
                        LeagueId = 20

                    },
                    new Team
                    {
                        Id = 22,
                        Name = "Trevoir Williams - Sample Team",
                        LeagueId = 20

                    }
                );
        }
    }
}
