using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacy.WEB.Models.Domain_Models.Store
{
    public class ProducerDM
    {
        [Display(Name = "Производитель")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Number { get; set; }

        public string Address { get; set; }
    }
}