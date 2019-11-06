using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy.WEB.Models.Domain_Models.Store
{
    public class OrderItemDM
    {
        public int Id { get; set; }

        public ProductDM Product { get; set; }

        public int Count { get; set; }

        public bool Checked { get; set; }
    }
}