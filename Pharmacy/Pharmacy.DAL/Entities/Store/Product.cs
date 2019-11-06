using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Entities.Store
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Kind> Kinds { get; set; }

        public int? ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public int Assessment { get; set; }
    }
}
