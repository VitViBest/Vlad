using Ninject.Modules;
using Pharmacy.BLL.Interfaces;
using Pharmacy.DAL.Interfaces;
using Pharmacy.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string _ConnectionString;

        public ServiceModule(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IMainUnitOfWork>().To<MainUnitOfWork>().WithConstructorArgument(_ConnectionString);
            Bind<IMapperDTO>().To<MapperDTO>();
        }
    }
}
