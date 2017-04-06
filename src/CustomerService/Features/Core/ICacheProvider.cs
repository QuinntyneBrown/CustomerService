using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService.Features.Core
{
    public interface ICacheProvider
    {
        ICache GetCache();
    }
}
