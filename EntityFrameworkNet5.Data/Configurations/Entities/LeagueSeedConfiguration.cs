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
    public class LeagueSeedConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasData(
                    new League
                    {
                        Id = 20,
                        Name = "Sample League",
                    }
                );
        }
    }
}
