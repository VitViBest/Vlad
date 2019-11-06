using Pharmacy.BLL.Interfaces;
using Pharmacy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Services
{
    public class Service : IService
    {
        private IStoreService _StoreService;

        private IUserService _UserService;

        private IMainUnitOfWork _IOF;

        private IMapperDTO _MapperDTO;

        public Service(IMainUnitOfWork unitOfWork,IMapperDTO mapper)
        {
            _IOF = unitOfWork;
            _MapperDTO = mapper;
        }

        public IStoreService StoreService
        {
            get
            {
                if (_StoreService == null)
                    _StoreService = new StoreService(_IOF,_MapperDTO);
                return _StoreService;
            }
        }

        public IUserService UserService
        {
            get
            {
                if (_UserService == null)
                    _UserService = new UserService(_IOF, _MapperDTO);
                return _UserService;
            }
        }

        public void Dispose()
        {
            StoreService.Dispose();
            UserService.Dispose();
        }
    }
}
