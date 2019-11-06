using Pharmacy.BLL.DTO.Store;
using Pharmacy.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Interfaces
{
    public interface IStoreService:IDisposable
    {
        Task<OperationDetails> MakeOrderAsync(OrderDTO orderDTO, string name);

        ProductDTO GetProduct(int? id);

        IEnumerable<ProductDTO> GetProducts(); 

        IEnumerable<KindDTO> GetKinds();

        IEnumerable<PropertyDTO> GetProperties();

        Task<IEnumerable<OrderDTO>> GetOrdersForUserAsync(string name);

        OperationDetails Create(ProductDTO productDTO);

        OperationDetails Delete(int id);

        IEnumerable<ProducerDTO> GetProducers();
    }
}
