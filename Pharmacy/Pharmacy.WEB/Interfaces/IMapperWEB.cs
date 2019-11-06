using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.WEB.Interfaces
{
    public interface IMapperWEB
    {
        IMapper ToBasketDM { get; }

        IMapper FromBasketDM { get; }

        IMapper ToImageDM { get; }

        IMapper FromImageDM { get; }

        IMapper ToKindDM { get; }

        IMapper FromKindDM { get; }

        IMapper ToOrderDM { get; }

        IMapper FromOrderDM { get; }

        IMapper ToOrderItemDM { get; }

        IMapper FromOrderItemDM { get; }

        IMapper ToProducerDM { get; }

        IMapper FromProducerDM { get; }

        IMapper ToProductDM { get; }

        IMapper FromProductDM { get; }

        IMapper ToPropertyDM { get; }

        IMapper FromPropertyDM { get; }

        IMapper ToClientProfileDM { get; }

        IMapper FromClientProfileDM { get; }
    }
}
