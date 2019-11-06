using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Interfaces
{
    public interface IMainUnitOfWork:IDisposable
    {
        IIdentityUnitOfWork Identity { get; }

        IUnitOfWork Unit { get; }
    }
}
