using System.Data.Entity.Migrations;
using CustomerService.Data;
using CustomerService.Data.Model;

namespace CustomerService.Migrations
{
    public class TenantConfiguration
    {
        public static void Seed(CustomerServiceContext context) {

            context.Tenants.AddOrUpdate(x => x.Name, new Tenant()
            {
                Name = "Default"
            });

            context.SaveChanges();
        }
    }
}
