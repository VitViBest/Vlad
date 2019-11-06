using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.DTO.Store
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<KindDTO> Kinds { get; set; }

        public ProducerDTO Producer { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public IEnumerable<ImageDTO> Images { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<PropertyDTO> Properties { get; set; }

        public int Assessment { get; set; }
    }
}
