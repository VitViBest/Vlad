using Pharmacy.DAL.EF;
using Pharmacy.DAL.Entities.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Image> Images { get; }

        IRepository<Kind> Kinds { get; }

        IRepository<Order> Orders { get; }

        IRepository<OrderItem> OrderItems { get; }

        IRepository<Producer> Producers { get; }

        IRepository<Product> Products { get; }

        IRepository<Property> Properties { get; }

        IRepository<Basket> Baskets { get; }

        void Save();
    }
}
