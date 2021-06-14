using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkNet5.ConsoleApp.ScaffoldDb.Sample
{
    public partial class League
    {
        public League()
        {
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
