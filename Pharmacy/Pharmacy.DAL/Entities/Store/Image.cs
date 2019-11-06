using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Entities.Store
{
    public class Image
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Photo { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
