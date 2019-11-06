using Pharmacy.DAL.EF;
using Pharmacy.DAL.Entities.Identity;
using Pharmacy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Repositories
{
    public class ClientManager:IClientManager
    {
        private MainContext _Context;

        public ClientManager(MainContext context)
        {
            _Context = context;
        }

        public void Create(ClientProfile profile)
        {
            _Context.Entry(profile).State = System.Data.Entity.EntityState.Added;
            _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
