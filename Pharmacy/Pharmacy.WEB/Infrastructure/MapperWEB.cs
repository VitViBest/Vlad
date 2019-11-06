using AutoMapper;
using Pharmacy.BLL.DTO.Identity;
using Pharmacy.BLL.DTO.Store;
using Pharmacy.WEB.Interfaces;
using Pharmacy.WEB.Models.Domain_Models.Identity;
using Pharmacy.WEB.Models.Domain_Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pharmacy.WEB.Infrastructure
{
    public class MapperWEB : IMapperWEB
    {
        private IMapper _ToBasketDM;

        private IMapper _FromBasketDM;

        private IMapper _ToImageDM;

        private IMapper _FromImageDM;

        private IMapper _ToKindDM;

        private IMapper _FromKindDM;

        private IMapper _ToOrderDM;

        private IMapper _FromOrderDM;

        private IMapper _ToOrderItemDM;

        private IMapper _FromOrderItemDM;

        private IMapper _ToProducerDM;

        private IMapper _FromProducerDM;

        private IMapper _ToProductDM;

        private IMapper _FromProductDM;

        private IMapper _ToPropertyDM;

        private IMapper _FromPropertyDM;

        private IMapper _ToClientProfileDM;

        private IMapper _FromClientProfileDM;

        public IMapper ToBasketDM
        {
            get
            {
                if (_ToBasketDM == null)
                    _ToBasketDM = new MapperConfiguration(cfg => cfg.CreateMap<BasketDTO, BasketDM>()
                          .ForMember(i => i.OrderItems, j => j.MapFrom(k => ToOrderItemDM.Map<IEnumerable<OrderItemDTO>, List<OrderItemDM>>(k.OrderItems))))
                        .CreateMapper();
                return _ToBasketDM;
            }
        }

        public IMapper FromBasketDM
        {
            get
            {
                if (_FromBasketDM == null)
                    _FromBasketDM = new MapperConfiguration(cfg => cfg.CreateMap<BasketDM, BasketDTO>()
                          .ForMember(i => i.OrderItems, j => j.MapFrom(k => FromOrderItemDM.Map<IEnumerable<OrderItemDM>, List<OrderItemDTO>>(k.OrderItems))))
                        .CreateMapper();
                return _FromBasketDM;
            }
        }

        public IMapper ToImageDM
        {
            get
            {
                if (_ToImageDM == null)
                    _ToImageDM = new MapperConfiguration(cfg => cfg.CreateMap<ImageDTO, ImageDM>())
                        .CreateMapper();
                return _ToImageDM;
            }
        }

        public IMapper FromImageDM
        {
            get
            {
                if (_FromImageDM == null)
                    _FromImageDM = new MapperConfiguration(cfg => cfg.CreateMap<ImageDM, ImageDTO>())
                        .CreateMapper();
                return _FromImageDM;
            }
        }

        public IMapper ToKindDM
        {
            get
            {
                if (_ToKindDM == null)
                    _ToKindDM = new MapperConfiguration(cfg => cfg.CreateMap<KindDTO, KindDM>())
                        .CreateMapper();
                return _ToKindDM;
            }
        }

        public IMapper FromKindDM
        {
            get
            {
                if (_FromKindDM == null)
                    _FromKindDM = new MapperConfiguration(cfg => cfg.CreateMap<KindDM, KindDTO>())
                        .CreateMapper();
                return _FromKindDM;
            }
        }

        public IMapper ToOrderDM
        {
            get
            {
                if (_ToOrderDM == null)
                    _ToOrderDM = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderDM>()
                          .ForMember(i => i.OrderItems, j => j.MapFrom(k => ToOrderItemDM.Map<IEnumerable<OrderItemDTO>, List<OrderItemDM>>(k.OrderItems))))
                        .CreateMapper();
                return _ToOrderDM;
            }
        }

        public IMapper FromOrderDM
        {
            get
            {
                if (_FromOrderDM == null)
                    _FromOrderDM = new MapperConfiguration(cfg => cfg.CreateMap<OrderDM, OrderDTO>()
                          .ForMember(i => i.OrderItems, j => j.MapFrom(k => FromOrderItemDM.Map<IEnumerable<OrderItemDM>, List<OrderItemDTO>>(k.OrderItems))))
                        .CreateMapper();
                return _FromOrderDM;
            }
        }

        public IMapper ToOrderItemDM
        {
            get
            {
                if (_ToOrderItemDM == null)
                    _ToOrderItemDM = new MapperConfiguration(cfg => cfg.CreateMap<OrderItemDTO, OrderItemDM>()
                          .ForMember(i => i.Product, j => j.MapFrom(k => ToProductDM.Map<ProductDTO, ProductDM>(k.Product))))
                        .CreateMapper();
                return _ToOrderItemDM;
            }
        }

        public IMapper FromOrderItemDM
        {
            get
            {
                if (_FromOrderItemDM == null)
                    _FromOrderItemDM = new MapperConfiguration(cfg => cfg.CreateMap<OrderItemDM, OrderItemDTO>()
                          .ForMember(i => i.Product, j => j.MapFrom(k => FromProductDM.Map<ProductDM, ProductDTO>(k.Product))))
                        .CreateMapper();
                return _FromOrderItemDM;
            }
        }

        public IMapper ToProducerDM
        {
            get
            {
                if (_ToProducerDM == null)
                    _ToProducerDM = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDTO, ProducerDM>())
                        .CreateMapper();
                return _ToProducerDM;
            }
        }

        public IMapper FromProducerDM
        {
            get
            {
                if (_FromProducerDM == null)
                    _FromProducerDM = new MapperConfiguration(cfg => cfg.CreateMap<ProducerDM, ProducerDTO>())
                        .CreateMapper();
                return _FromProducerDM;
            }
        }

        public IMapper ToProductDM
        {
            get
            {
                if (_ToProductDM == null)
                    _ToProductDM = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductDM>()
                          .ForMember(i => i.Kinds, j => j.MapFrom(k => ToKindDM.Map<IEnumerable<KindDTO>, List<KindDM>>(k.Kinds)))
                          .ForMember(i => i.Producer, j => j.MapFrom(k => ToProducerDM.Map<ProducerDTO, ProducerDM>(k.Producer)))
                          .ForMember(i => i.Images, j => j.MapFrom(k => ToImageDM.Map<IEnumerable<ImageDTO>, List<ImageDM>>(k.Images)))
                          .ForMember(i => i.Properties, j => j.MapFrom(k => ToPropertyDM.Map<IEnumerable<PropertyDTO>, List<PropertyDM>>(k.Properties))))
                        .CreateMapper();
                return _ToProductDM;
            }
        }

        public IMapper FromProductDM
        {
            get
            {
                if (_FromProductDM == null)
                    _FromProductDM = new MapperConfiguration(cfg => cfg.CreateMap<ProductDM, ProductDTO>()
                          .ForMember(i => i.Kinds, j => j.MapFrom(k => FromKindDM.Map<IEnumerable<KindDM>, List<KindDTO>>(k.Kinds)))
                          .ForMember(i => i.Producer, j => j.MapFrom(k => FromProducerDM.Map<ProducerDM, ProducerDTO>(k.Producer)))
                          .ForMember(i => i.Images, j => j.MapFrom(k => FromImageDM.Map<IEnumerable<ImageDM>, List<ImageDTO>>(k.Images)))
                          .ForMember(i => i.Properties, j => j.MapFrom(k => FromPropertyDM.Map<IEnumerable<PropertyDM>, List<PropertyDTO>>(k.Properties))))
                        .CreateMapper();
                return _FromProductDM;
            }
        }

        public IMapper ToPropertyDM
        {
            get
            {
                if (_ToPropertyDM == null)
                    _ToPropertyDM = new MapperConfiguration(cfg => cfg.CreateMap<PropertyDTO, PropertyDM>())
                        .CreateMapper();
                return _ToPropertyDM;
            }
        }

        public IMapper FromPropertyDM
        {
            get
            {
                if (_FromPropertyDM == null)
                    _FromPropertyDM = new MapperConfiguration(cfg => cfg.CreateMap<PropertyDM, PropertyDTO>())
                        .CreateMapper();
                return _FromPropertyDM;
            }
        }

        public IMapper ToClientProfileDM
        {
            get
            {
                if (_ToClientProfileDM == null)
                    _ToClientProfileDM = new MapperConfiguration(cfg => cfg.CreateMap<ClientProfileDTO, ProfileDM>()
                          .ForMember(i => i.Orders, j => j.MapFrom(k => ToOrderDM.Map<IEnumerable<OrderDTO>, List<OrderDM>>(k.Orders)))
                          .ForMember(i => i.Basket, j => j.MapFrom(k => ToBasketDM.Map<BasketDTO, BasketDM>(k.Basket))))
                          .CreateMapper();
                return _ToClientProfileDM;
            }
        }

        public IMapper FromClientProfileDM
        {
            get
            {
                if (_FromClientProfileDM == null)
                    _FromClientProfileDM = new MapperConfiguration(cfg => cfg.CreateMap<ProfileDM, ClientProfileDTO>()
                          .ForMember(i => i.Orders, j => j.MapFrom(k => FromOrderDM.Map<IEnumerable<OrderDM>, List<OrderDTO>>(k.Orders)))
                          .ForMember(i => i.Basket, j => j.MapFrom(k => FromBasketDM.Map<BasketDM, BasketDTO>(k.Basket))))
                          .CreateMapper();
                return _FromClientProfileDM;
            }
        }

    }
}