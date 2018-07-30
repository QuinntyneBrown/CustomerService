using System.Threading;
using System.Threading.Tasks;
using CustomerService.Core.Interfaces;
using CustomerService.Core.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CustomerService.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options) { }

        public DbSet<StoredEvent> StoredEvents { get; set; }
    }
}
