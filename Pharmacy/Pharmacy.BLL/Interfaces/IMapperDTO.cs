using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Interfaces
{
    public interface IMapperDTO
    {
        IMapper ToBasketDTO { get; }

        IMapper FromBasketDTO { get; }

        IMapper ToImageDTO { get; }

        IMapper FromImageDTO { get; }

        IMapper ToKindDTO { get; }

        IMapper FromKindDTO { get; }

        IMapper ToOrderDTO { get; }

        IMapper FromOrderDTO { get; }

        IMapper ToOrderItemDTO { get; }

        IMapper FromOrderItemDTO { get; }

        IMapper ToProducerDTO { get; }

        IMapper FromProducerDTO { get; }

        IMapper ToProductDTO { get; }

        IMapper FromProductDTO { get; }

        IMapper ToPropertyDTO { get; }

        IMapper FromPropertyDTO { get; }

        IMapper ToClientProfileDTO { get; }

        IMapper FromClientProfileDTO { get; }
    }
}
