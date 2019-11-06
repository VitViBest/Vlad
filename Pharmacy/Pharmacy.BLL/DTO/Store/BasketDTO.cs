using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.DTO.Store
{
    public class BasketDTO
    {
        public int Id { get; set; }

        public IEnumerable<OrderItemDTO> OrderItems { get; set; }
    }
}
