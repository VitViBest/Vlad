using Pharmacy.WEB.Models.Domain_Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy.WEB.Models.Domain_Models.Identity
{
    public class ProfileDM
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public List<OrderDM> Orders { get; set; }

        public BasketDM Basket { get; set; }
    }
}