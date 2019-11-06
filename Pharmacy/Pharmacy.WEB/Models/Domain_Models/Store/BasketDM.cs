using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy.WEB.Models.Domain_Models.Store
{
    public class BasketDM
    {
        public int Id { get; set; }

        public  List<OrderItemDM> OrderItems { get; set; }
    }
}