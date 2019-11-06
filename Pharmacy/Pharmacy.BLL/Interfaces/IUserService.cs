using Pharmacy.BLL.DTO.Identity;
using Pharmacy.BLL.DTO.Store;
using Pharmacy.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Interfaces
{
    public interface IUserService:IDisposable
    {
        Task<OperationDetails> CreateAsync(ClientProfileDTO client);

        Task<ClaimsIdentity> AuthenticateAsync(ClientProfileDTO client);

        Task<ClientProfileDTO> GetUserAsync(string name);
    }
}
