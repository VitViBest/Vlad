using Ninject.Modules;
using Pharmacy.BLL.Interfaces;
using Pharmacy.BLL.Services;
using Pharmacy.WEB.Infrastructure;
using Pharmacy.WEB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy.WEB.Util
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService>().To<Service>();
            Bind<IMapperWEB>().To<MapperWEB>();
        }
    }
}