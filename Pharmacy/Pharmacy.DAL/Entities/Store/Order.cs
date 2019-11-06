using Pharmacy.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Entities.Store
{
    public class Order
    {
        public int Id { get; set; }

        public decimal Sum { get; set; }

        public string Address { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public string ClientProfileId { get; set; }

        public virtual ClientProfile ClientProfile { get; set; }

        public DateTime Date { get; set; }

        public string Phone { get; set; }
    }
}
