using Pharmacy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Repositories
{
    public class MainUnitOfWork : IMainUnitOfWork
    {

        private IIdentityUnitOfWork _Identity;

        private IUnitOfWork _Unit;

        private readonly string _Connection;

        public MainUnitOfWork(string connectionString)
        {
            _Connection = connectionString;
        }

        public IUnitOfWork Unit
        {
            get
            {
                if (_Unit == null)
                    _Unit = new EFUnitOfWork(_Connection);
                return _Unit;
            }
        }

        public IIdentityUnitOfWork Identity
        {
            get
            {
                if (_Identity == null)
                    _Identity = new IdentityUnitOfWork(_Connection);
                return _Identity;
            }
        }

        public void Dispose()
        {
            Identity.Dispose();
            Unit.Dispose();
        }
    }
}
