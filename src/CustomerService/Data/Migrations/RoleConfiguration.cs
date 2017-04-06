using System.Data.Entity.Migrations;
using CustomerService.Data;
using CustomerService.Data.Model;
using CustomerService.Features.Users;

namespace CustomerService.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(CustomerServiceContext context) {

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.SYSTEM
            });

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.PRODUCT
            });

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.DEVELOPMENT
            });

            context.SaveChanges();
        }
    }
}
