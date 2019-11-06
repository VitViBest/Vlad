using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacy.WEB.Models.Domain_Models.Store
{
    public class ProductDM
    {
        public int Id { get; set; }

        [Display(Name ="Название")]
        public string Name { get; set; }

        public List<KindDM> Kinds { get; set; }

        public ProducerDM Producer { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        public List<ImageDM> Images { get; set; }

        public bool IsDeleted { get; set; }

        public List<PropertyDM> Properties { get; set; }

        public int Assessment { get; set; }
    }
}