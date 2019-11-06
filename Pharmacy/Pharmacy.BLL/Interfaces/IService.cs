using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Interfaces
{
    public interface IService : IDisposable
    {
        IStoreService StoreService { get; }

        IUserService UserService { get; }
    }
}
