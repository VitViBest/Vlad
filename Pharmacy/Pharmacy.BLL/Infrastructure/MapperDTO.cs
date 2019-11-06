using AutoMapper;
using Pharmacy.BLL.DTO.Identity;
using Pharmacy.BLL.DTO.Store;
using Pharmacy.BLL.Interfaces;
using Pharmacy.DAL.Entities.Identity;
using Pharmacy.DAL.Entities.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Infrastructure
{
    public class MapperDTO : IMapperDTO
    {
        private IMapper _ToBasketDTO;

        private IMapper _FromBasketDTO;

        private IMapper _ToImageDTO;

        private IMapper _FromImageDTO;

        private IMapper _ToKindDTO;

        private IMapper _FromKindDTO;

        private IMapper _ToOrderDTO;

        private IMapper _FromOrderDTO;

        private IMapper _ToOrderItemDTO;

        private IMapper _FromOrderItemDTO;

        private IMapper _ToProducerDTO;

        private IMapper _FromProducerDTO;

        private IMapper _ToProductDTO;

        private IMapper _FromProductDTO;

        private IMapper _ToPropertyDTO;

        private IMapper _FromPropertyDTO;

        private IMapper _ToClientProfileDTO;

        private IMapper _FromClientProfileDTO;

        public IMapper ToBasketDTO
        {
            get
            {
                if (_ToBasketDTO == null)
                    _ToBasketDTO = new MapperConfiguration(cfg => cfg.CreateMap<Basket, BasketDTO>()
                          .ForMember(i => i.OrderItems, j => j.MapFrom(k => ToOrderItemDTO.Map<ICollection<OrderItem>, List<OrderItemDTO>>(k.OrderItems))))
                        .CreateMapper();
                return _ToBasketDTO;
            }
        }

        public IMapper FromBasketDTO
        {
            get
            {
                if (_FromBasketDTO == null)
                    _FromBasketDTO = new MapperConfiguration(cfg => cfg.CreateMap<BasketDTO, Basket>()
                          .ForMember(i => i.OrderItems, j => j.MapFrom(k => FromOrderItemDTO.Map<IEnumerable<OrderItemDTO>, List<OrderItem>>(k.OrderItems))))
                        .CreateMapper();
                return _FromBasketDTO;
            }
        }

        public IMapper ToImageDTO
        {
            get
            {
                if (_ToImageDTO == null)
                    _ToImageDTO = new MapperConfiguration(cfg => cfg.CreateMap<Image, ImageDTO>())
                        .CreateMapper();
                return _ToImageDTO;
            }
        }

        public IMapper FromImageDTO
        {
            get
            {
                if (_FromImageDTO == null)
                    _FromImageDTO = new MapperConfiguration(cfg => cfg.CreateMap<ImageDTO, Image>())
                        .CreateMapper();
                return _FromImageDTO;
            }
        }

        public IMapper ToKindDTO
        {
            get
            {
                if (_ToKindDTO == null)
                    _ToKindDTO = new MapperConfiguration(cfg => cfg.CreateMap<Kind, KindDTO>())
                        .CreateMapper();
                return _ToKindDTO;
            }
        }

        public IMapper FromKindDTO
        {
            get
            {
                if (_FromKindDTO == null)
                    _FromKindDTO = new MapperConfiguration(cfg => cfg.CreateMap<KindDTO, Kind>())
                        .CreateMapper();
                return _FromKindDTO;
            }
        }

        public IMapper ToOrderDTO
        {
            get
            {
                if (_ToOrderDTO == null)
                    _ToOrderDTO = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()
                          .ForMember(i => i.OrderItems, j => j.MapFrom(k => ToOrderItemDTO.Map<ICollection<OrderItem>, List<OrderItemDTO>>(k.OrderItems))))
                        .CreateMapper();
                return _ToOrderDTO;
            }
        }

        public IMapper FromOrderDTO
        {
            get
            {
                if (_FromOrderDTO == null)
                    _FromOrderDTO = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()
                          .ForMember(i => i.OrderItems, j => j.MapFrom(k => FromOrderItemDTO.Map<IEnumerable<OrderItemDTO>, List<OrderItem>>(k.OrderItems))))
                        .CreateMapper();
                return _FromOrderDTO;
            }
        }

        public IMapper ToOrderItemDTO
        {
            get
            {
                if (_ToOrderItemDTO == null)
                    _ToOrderItemDTO = new MapperConfiguration(cfg => cfg.CreateMap<OrderItem, OrderItemDTO>()
                          .ForMember(i => i.Product, j => j.MapFrom(k => ToProductDTO.Map<Product, ProductDTO>(k.Product))))
                        .CreateMapper();
                return _ToOrderItemDTO;
            }
        }

        public IMapper FromOrderItemDTO
        {
            get
            {
                if (_FromOrderItemDTO == null)
                    _FromOrderItemDTO = new MapperConfiguration(cfg => cfg.CreateMap<OrderItemDTO, OrderItem>()
                          .ForMember(i => i.Product, j => j.MapFrom(k => FromProductDTO.Map<ProductDTO, Product>(k.Product))))
                        .CreateMapper();
                return _FromOrderItemDTO;
            }
        }

        public IMapper ToProducerDTO
        {
            get
            {
                if (_ToProducerDTO == null)
                    _ToProducerDTO = new MapperConfiguration(cfg => cfg.CreateMap<Producer, ProducerDTO>())
                        .CreateMapper();
                return _ToProducerDTO;
            }
        }

        public IMapper FromProducerDTO
        {
            get
            {
                if (_FromProducerDTO == null)
                    _FromProducerDTO = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDTO, Producer>())
                        .CreateMapper();
                return _FromProducerDTO;
            }
        }

        public IMapper ToProductDTO
        {
            get
            {
                if (_ToProductDTO == null)
                    _ToProductDTO = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()
                          .ForMember(i => i.Kinds, j => j.MapFrom(k => ToKindDTO.Map<ICollection<Kind>, List<KindDTO>>(k.Kinds)))
                          .ForMember(i => i.Producer, j => j.MapFrom(k => ToProducerDTO.Map<Producer, ProducerDTO>(k.Producer)))
                          .ForMember(i => i.Images, j => j.MapFrom(k => ToImageDTO.Map<ICollection<Image>, List<ImageDTO>>(k.Images)))
                          .ForMember(i => i.Properties, j => j.MapFrom(k => ToPropertyDTO.Map<ICollection<Property>, List<PropertyDTO>>(k.Properties))))
                        .CreateMapper();
                return _ToProductDTO;
            }
        }

        public IMapper FromProductDTO
        {
            get
            {
                if (_FromProductDTO == null)
                    _FromProductDTO = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>()
                          .ForMember(i => i.Kinds, j => j.MapFrom(k => FromKindDTO.Map<IEnumerable<KindDTO>, List<Kind>>(k.Kinds)))
                          .ForMember(i => i.Producer, j => j.MapFrom(k => FromProducerDTO.Map<ProducerDTO, Producer>(k.Producer)))
                          .ForMember(i => i.Images, j => j.MapFrom(k => FromImageDTO.Map<IEnumerable<ImageDTO>, List<Image>>(k.Images)))
                          .ForMember(i => i.Properties, j => j.MapFrom(k => FromPropertyDTO.Map<IEnumerable<PropertyDTO>, List<Property>>(k.Properties))))
                        .CreateMapper();
                return _FromProductDTO;
            }
        }

        public IMapper ToPropertyDTO
        {
            get
            {
                if (_ToPropertyDTO == null)
                    _ToPropertyDTO = new MapperConfiguration(cfg => cfg.CreateMap<Property, PropertyDTO>())
                        .CreateMapper();
                return _ToPropertyDTO;
            }
        }

        public IMapper FromPropertyDTO
        {
            get
            {
                if (_FromPropertyDTO == null)
                    _FromPropertyDTO = new MapperConfiguration(cfg => cfg.CreateMap<PropertyDTO, Property>())
                        .CreateMapper();
                return _FromPropertyDTO;
            }
        }

        public IMapper ToClientProfileDTO
        {
            get
            {
                if (_ToClientProfileDTO == null)
                    _ToClientProfileDTO = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfile, ClientProfileDTO>()
                          .ForMember(u => u.Email, x => x.MapFrom(c => c.ApplicationUser.Email))
                          .ForMember(u => u.Password, x => x.MapFrom(c => c.ApplicationUser.PasswordHash))
                          .ForMember(u => u.Role, x => x.MapFrom(c => c.ApplicationUser.Roles.ToString()))
                          .ForMember(i => i.Orders, j => j.MapFrom(k => ToOrderDTO.Map<ICollection<Order>, List<OrderDTO>>(k.Orders)))
                          .ForMember(i => i.Basket, j => j.MapFrom(k => ToBasketDTO.Map<Basket, BasketDTO>(k.Basket))))
                          .CreateMapper();
                return _ToClientProfileDTO;
            }
        }

        public IMapper FromClientProfileDTO
        {
            get
            {
                if (_FromClientProfileDTO == null)
                    _FromClientProfileDTO = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfileDTO, ClientProfile>()
                          .ForMember(u => u.ApplicationUser.Email, x => x.MapFrom(c => c.Email))
                          .ForMember(u => u.ApplicationUser.PasswordHash, x => x.MapFrom(c => c.Password.GetHashCode()))
                          .ForMember(u => u.ApplicationUser.Roles, x => x.MapFrom(c => c.Role))
                          .ForMember(i => i.Orders, j => j.MapFrom(k => FromOrderDTO.Map<IEnumerable<OrderDTO>, List<Order>>(k.Orders)))
                          .ForMember(i => i.Basket, j => j.MapFrom(k => FromBasketDTO.Map<BasketDTO, Basket>(k.Basket))))
                          .CreateMapper();
                return _FromClientProfileDTO;
            }
        }
    }
}
