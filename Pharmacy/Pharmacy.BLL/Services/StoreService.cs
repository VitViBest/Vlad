using Pharmacy.BLL.DTO.Store;
using Pharmacy.BLL.Infrastructure;
using Pharmacy.BLL.Interfaces;
using Pharmacy.DAL.Entities.Store;
using Pharmacy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Services
{
    public class StoreService :IStoreService
    {
        private IMainUnitOfWork _IOF;

        private IMapperDTO _Mapper;

        public StoreService(IMainUnitOfWork unit, IMapperDTO mapper)
        {
            _IOF = unit;
            _Mapper = mapper;
        }

        public OperationDetails Create(ProductDTO productDTO)
        {
            try
            {
                if (productDTO.Id > 0)
                {
                    var oldProduct = _IOF.Unit.Products.Get(productDTO.Id);
                    var propert = oldProduct.Properties.ToList();
                    foreach (var i in propert)
                    {
                        _IOF.Unit.Properties.Delete(i.Id);
                    }
                    var imag = oldProduct.Images.ToList();
                    foreach (var i in imag)
                    {
                        _IOF.Unit.Images.Delete(i.Id);
                    }
                    var kind = _IOF.Unit.Kinds.Find(x=>x.Products.Any(p=>p.Id==oldProduct.Id)).ToList();
                    foreach (var i in kind)
                    {
                        var pr = i.Products.ToList();
                        var n = i.Name.ToString();
                        _IOF.Unit.Kinds.Delete(i.Id);
                        pr.Remove(_IOF.Unit.Products.Get(productDTO.Id));
                        if (pr.Count > 0)
                            _IOF.Unit.Kinds.Create(new Kind() { Name = n, Products = pr });
                    }
                    _IOF.Unit.Save();
                }
                Product product = _Mapper.FromProductDTO.Map<ProductDTO, Product>(productDTO);
                Producer producer = _IOF.Unit.Producers.Get(productDTO.Producer.Id);
                product.Producer = producer;
                List<Kind> kinds = new List<Kind>();
                foreach (var i in productDTO.Kinds)
                {
                    Kind kind = _IOF.Unit.Kinds.Find(x => x.Name == i.Name.ToLower().Trim())?.FirstOrDefault();
                    if (kind == null)
                    {
                        kind = new Kind() { Name = i.Name.ToLower().Trim()};
                       _IOF.Unit.Kinds.Create(kind);
                    }
                    kinds.Add(kind);
                }
                product.Kinds = kinds;
                List<Property> properties = new List<Property>();
                foreach (var i in productDTO.Properties)
                {
                    Property property =  new Property() { Name = i.Name, Text = i.Text,ProductId=productDTO.Id };
                   _IOF.Unit.Properties.Create(property);
                    properties.Add(property);
                }
                product.Properties = properties;
                List<Image> images = new List<Image>();
                foreach (var i in productDTO.Images)
                {
                    Image image = new Image() { Photo = i.Photo, Text = i.Text.ToLower().Trim(),ProductId=productDTO.Id };
                     _IOF.Unit.Images.Create(image);
                    images.Add(image);
                }
                product.Images = images;
                if (productDTO.Id == 0)
                {
                    _IOF.Unit.Products.Create(product);
                }
                else
                {
                    _IOF.Unit.Products.Update(product,product.Id);
                }
                _IOF.Unit.Save();
                return new OperationDetails(true, "", "");
            }
            catch(Exception ex)
            {
                return new OperationDetails(false, ex.Message,"");
            }
        }

        public OperationDetails Delete(int id)
        {
            try
            {
                Product product = _IOF.Unit.Products.Get(id);
                if (product != null)
                {
                    product.IsDeleted = true;
                    _IOF.Unit.Products.Update(product,id);
                    _IOF.Unit.Save();
                    return new OperationDetails(true, "", "");
                }
                else
                    throw new ValidationExpetion("Не найден товар", "");
            }catch(Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }
        }

        public void Dispose()
        {
            _IOF.Unit.Dispose();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersForUserAsync(string name)
        {
            try {
            IEnumerable<Order> orders = (await _IOF.Identity.UserManager.FindByNameAsync(name)).ClientProfile.Orders;
            List<OrderDTO> ordersDTO = _Mapper.ToOrderDTO.Map<IEnumerable<Order>, List<OrderDTO>>(orders);
            return ordersDTO;
            }
            catch
            {
                return null;
            }
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                return null;
            var product =_IOF.Unit.Products.Get(id.Value);
            if (product == null)
                return null;
            return _Mapper.ToProductDTO.Map<Product, ProductDTO>(product);
       
        }

        public IEnumerable<ProductDTO> GetProducts()
        {

            try
            {
                IEnumerable<Product> products = _IOF.Unit.Products.GetAll();
                return _Mapper.ToProductDTO.Map<IEnumerable<Product>, List<ProductDTO>>(products);
            }
            catch
            {
                return null;
            } 
        }

        public async Task<OperationDetails> MakeOrderAsync(OrderDTO orderDTO,string name)
        {
            try
            {
                var products = new List<OrderItem>();
                decimal sum = 0;
                foreach (var o in orderDTO.OrderItems)
                {
                    var product = _IOF.Unit.Products.Get(o.Product.Id);
                    if (product == null)
                        return new OperationDetails(false, "Товар не найден", "");
                    sum += product.Price * o.Count;
                    products.Add(new OrderItem { Product = product, Count = o.Count });
                }
                Order order = new Order
                {
                    Date = DateTime.Now,
                    Address = orderDTO.Address,
                    Sum = sum,
                    OrderItems = products,
                    Phone=orderDTO.Phone,
                    ClientProfileId = name != null ? ((await _IOF.Identity.UserManager.FindByNameAsync(name)).Id) : null
                };
                _IOF.Unit.Orders.Create(order);
                _IOF.Unit.Save();
                return new OperationDetails(true,"","");
            }
            catch(Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }
        }

        public IEnumerable<ProducerDTO> GetProducers()
        {
            try
            {
                IEnumerable<Producer> producers = _IOF.Unit.Producers.GetAll();
                return _Mapper.ToProducerDTO.Map<IEnumerable<Producer>, List<ProducerDTO>>(producers);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<KindDTO> GetKinds()
        {
            try
            {
                IEnumerable<Kind> kinds = _IOF.Unit.Kinds.GetAll();
                return _Mapper.ToKindDTO.Map<IEnumerable<Kind>, List<KindDTO>>(kinds);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<PropertyDTO> GetProperties()
        {
            try
            {
                IEnumerable<Property> properties = _IOF.Unit.Properties.GetAll();
                return _Mapper.ToPropertyDTO.Map<IEnumerable<Property>, List<PropertyDTO>>(properties);
            }
            catch
            {
                return null;
            }
        }

        //public IEnumerable<string> GetAutocomplete(string term,int count=5)
        //{
        //    if (term != null)
        //    {
        //        term = term.ToLower().Replace(" ", "");
        //        var items = _IOF.Unit..Where(x => x.Name.ToLower().Replace(" ", "").Contains(term)).Distinct().Take(5).Select(x => new { value = x.Name });
        //        return Json(items, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
