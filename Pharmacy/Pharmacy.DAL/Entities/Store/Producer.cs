using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Entities.Store
{
    public class Producer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Number { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
