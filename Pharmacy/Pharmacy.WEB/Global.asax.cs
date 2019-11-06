using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Pharmacy.BLL.Infrastructure;
using Pharmacy.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pharmacy.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule ninjectModuleDTO = new BLL.Infrastructure.ServiceModule("DefaultConnection");
            NinjectModule ninjectModuleWEB = new WEB.Util.ServiceModule();
            var kernel = new StandardKernel(ninjectModuleDTO, ninjectModuleWEB);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
