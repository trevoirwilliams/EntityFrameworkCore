using EntityFrameworkNet5.Data.Configurations.Entities;
using EntityFrameworkNet5.Domain;
using EntityFrameworkNet5.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkNet5.Data
{
    public abstract class AuditableFootballLeageDbContext : DbContext
    {
        public async Task<int> SaveChangesAsync(string username)
        {
            var entries = ChangeTracker.Entries().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var auditableObject = (BaseDomainObject)entry.Entity;
                auditableObject.ModifiedDate = DateTime.Now;
                auditableObject.ModifiedBy = username;

                if (entry.State == EntityState.Added)
                {
                    auditableObject.CreatedDate = DateTime.Now;
                    auditableObject.CreatedBy = username;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
