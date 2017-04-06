using CustomerService.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Collections.Generic;

namespace CustomerService.Features.Core
{
    public class AllowTenantAttribute : AuthorizationFilterAttribute
    {
        public AllowTenantAttribute()
        {
            _context = (ICustomerServiceContext)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICustomerServiceContext));
        }

        public override bool AllowMultiple
        {
            get { return false; }
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                var uniqueId = actionContext.Request.GetTenantUniqueId();

                var tenant = _context.Tenants.SingleOrDefault(x => x.UniqueId == uniqueId);

                if (tenant == null)
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

            }
            catch(KeyNotFoundException e)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

        }
        
        private readonly ICustomerServiceContext _context;
    }
}