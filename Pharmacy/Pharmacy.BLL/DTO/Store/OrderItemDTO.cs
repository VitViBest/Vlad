using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.DTO.Store
{
    public class OrderItemDTO
    {
        public int Id { get; set; }

        public ProductDTO Product { get; set; }

        public int Count { get; set; }
    }
}
