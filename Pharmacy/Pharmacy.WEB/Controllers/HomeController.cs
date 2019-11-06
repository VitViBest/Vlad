using Pharmacy.BLL.DTO.Store;
using Pharmacy.BLL.Interfaces;
using Pharmacy.WEB.Infrastructure;
using Pharmacy.WEB.Interfaces;
using Pharmacy.WEB.Models.Domain_Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pharmacy.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IService _service;

        private IMapperWEB _mapper;

        public HomeController(IService service, IMapperWEB mapperWEB)
        {
            _service = service;
            _mapper = mapperWEB;
        }

        public ActionResult Index()
        {
            var kindsDTO = _service.StoreService.GetKinds();
            var kinds = _mapper.ToKindDM.Map<IEnumerable<KindDTO>, List<KindDM>>(kindsDTO);
            return View(kinds);
        }
    }
}