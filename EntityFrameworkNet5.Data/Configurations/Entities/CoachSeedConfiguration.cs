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
    public class CoachSeedConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasData(
                    new Coach
                    {
                        Id = 20,
                        Name = "Trevoir Williams",
                        TeamId = 20
                    },
                    new Coach
                    {
                        Id = 21,
                        Name = "Trevoir Williams - Sample 1",
                        TeamId = 21
                    }, new Coach
                    {
                        Id = 22,
                        Name = "Trevoir Williams - Sample 2",
                        TeamId = 22
                    }
                );
        }
    }
}
