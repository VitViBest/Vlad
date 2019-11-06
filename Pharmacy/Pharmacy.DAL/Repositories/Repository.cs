using Pharmacy.DAL.EF;
using Pharmacy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Repositories
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private MainContext _Context;

        public Repository(MainContext context)
        {
            _Context = context;
        }

        /// <summary>
        /// Add new element into table.
        /// </summary>
        /// <param name="item"></param>
        public void Create(T item)
        {
            _Context.Entry(item).State = System.Data.Entity.EntityState.Added;
        }

        /// <summary>
        /// Delete element from table.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            T item = _Context.Set<T>().Find(id);
            if (item != null)
                _Context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
        }

        /// <summary>
        /// Returns IEnumerable elements for predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _Context.Set<T>().Where(predicate).ToList();
        }

        /// <summary>
        /// Take element for id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            return _Context.Set<T>().Find(id);
        }

        /// <summary>
        /// Get all elements from table.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _Context.Set<T>();
        }

        /// <summary>
        /// Updates element in table.
        /// </summary>
        /// <param name="item"></param>
        public void Update(T item,int id)
        {
            T localItem = Get(id);
            var local = _Context.Set<T>()
                         .Local
                         .FirstOrDefault(f => f ==localItem);
            if (local != null)
            {
               _Context.Entry(local).State = EntityState.Detached;
            }
            _Context.Entry(item).State = EntityState.Modified;
            _Context.SaveChanges();
            
        }
    }
}
