using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pharmacy.DAL.Entities.Store
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Count { get; set; }

        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int? BasketId { get; set; }

        public virtual Basket Basket { get; set; }
    }
}