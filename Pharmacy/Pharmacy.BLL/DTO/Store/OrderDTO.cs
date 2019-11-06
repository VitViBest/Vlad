using Pharmacy.BLL.DTO.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.DTO.Store
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public decimal Sum { get; set; }

        public string Address { get; set; }

        public IEnumerable<OrderItemDTO> OrderItems { get; set; }

        public DateTime Date { get; set; }

        public string Phone { get; set; }

        public string ClientProfileId { get; set; }
    }
}
