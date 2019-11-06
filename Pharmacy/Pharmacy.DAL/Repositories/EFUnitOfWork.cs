using Pharmacy.DAL.EF;
using Pharmacy.DAL.Entities.Store;
using Pharmacy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Repositories
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private MainContext _Context;

        private Repository<Image> _Images;

        private Repository<Kind> _Kinds;

        private Repository<Order> _Orders;

        private Repository<OrderItem> _OrderItems;

        private Repository<Producer> _Producers;

        private Repository<Product> _Products;

        private Repository<Property> _Properties;

        private Repository<Basket> _Baskets;

        public EFUnitOfWork(string connectionString)
        {
            _Context = new MainContext(connectionString);
        }

        public IRepository<Image> Images
        {
            get
            {
                if (_Images == null)
                    _Images = new Repository<Image>(_Context);
                return _Images;
            }
        }

        public IRepository<Kind> Kinds
        {
            get
            {
                if (_Kinds == null)
                    _Kinds = new Repository<Kind>(_Context);
                return _Kinds;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_Orders == null)
                    _Orders = new Repository<Order>(_Context);
                return _Orders;
            }
        }

        public IRepository<OrderItem> OrderItems
        {
            get
            {
                if (_OrderItems == null)
                    _OrderItems = new Repository<OrderItem>(_Context);
                return _OrderItems;
            }
        }

        public IRepository<Producer> Producers
        {
            get
            {
                if (_Producers == null)
                    _Producers = new Repository<Producer>(_Context);
                return _Producers;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (_Products == null)
                    _Products = new Repository<Product>(_Context);
                return _Products;
            }
        }

        public IRepository<Property> Properties
        {
            get
            {
                if (_Properties == null)
                    _Properties= new Repository<Property>(_Context);
                return _Properties;
            }
        }

        public IRepository<Basket> Baskets
        {
            get
            {
                if (_Baskets == null)
                    _Baskets = new Repository<Basket>(_Context);
                return _Baskets;
            }
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        private bool _Disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                    _Context.Dispose();
                _Disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
