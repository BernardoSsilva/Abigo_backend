using Abigo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abigo.Infrastructure
{
    public class AbigoDbAccess:DbContext
    {
        public AbigoDbAccess(DbContextOptions<AbigoDbAccess> options):base(options)

        {
            
        }

        public DbSet<AccountableEntity> Accountables { get; set; }
        public DbSet<DisponibleLocalesEntity> DisponibleLocales { get; set; }
    }
}
