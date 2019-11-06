using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacy.WEB.Models.Domain_Models.Store
{
    public class OrderDM
    {
        public int Id { get; set; }

        public decimal Sum { get; set; }

        [Required]
        public string Address { get; set; }

        public List<OrderItemDM> OrderItems { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string ClientProfileId { get; set; }
    }
}