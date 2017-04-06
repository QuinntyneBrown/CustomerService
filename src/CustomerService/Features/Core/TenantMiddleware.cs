﻿using Microsoft.Owin;
using CustomerService.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomerService.Features.Core
{
    public class TenantMiddleware : OwinMiddleware
    {
        public TenantMiddleware(OwinMiddleware next)
            : base(next) { }

        public override async Task Invoke(IOwinContext context)
        {
            var CustomerServiceContext = (CustomerServiceContext)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(CustomerServiceContext));


            var values = context.Request.Headers.GetValues("Tenant");
            if (values != null) {                
                context.Environment.Add("Tenant", ((string[])(values))[0]);                
            }
           
            await Next.Invoke(context);
        }
    }
}
