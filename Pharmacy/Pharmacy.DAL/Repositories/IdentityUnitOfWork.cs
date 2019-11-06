using Microsoft.AspNet.Identity.EntityFramework;
using Pharmacy.DAL.EF;
using Pharmacy.DAL.Entities.Identity;
using Pharmacy.DAL.Identity;
using Pharmacy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Repositories
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private MainContext _Context;

        private IClientManager _ClientManager;

        private ApplicationRoleManager _RoleManager;

        private ApplicationUserManager _UserManager;

        public IdentityUnitOfWork(string connectionString)
        {
            _Context = new MainContext(connectionString);
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                if (_UserManager == null)
                    _UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_Context));
                return _UserManager;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                if (_RoleManager == null)
                    _RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_Context));
                return _RoleManager;
            }
        }

        public IClientManager ClientManager
        {
            get
            {
                if (_ClientManager == null)
                    _ClientManager = new ClientManager(_Context);
                return _ClientManager;
            }
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _Disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                {
                    RoleManager.Dispose();
                    RoleManager.Dispose();
                    ClientManager.Dispose();
                }
            }
            _Disposed = true;
        }
    }
}
