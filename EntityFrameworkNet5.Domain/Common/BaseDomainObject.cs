using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNet5.Domain.Common
{
    public abstract class BaseDomainObject
    {
        public int Id { get; set; }
    }
}
