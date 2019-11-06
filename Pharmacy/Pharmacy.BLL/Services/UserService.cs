using Microsoft.AspNet.Identity;
using Pharmacy.BLL.DTO.Identity;
using Pharmacy.BLL.DTO.Store;
using Pharmacy.BLL.Infrastructure;
using Pharmacy.BLL.Interfaces;
using Pharmacy.DAL.Entities.Identity;
using Pharmacy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Services
{
    public class UserService : IUserService
    {
        private IMainUnitOfWork _Unit;

        private IMapperDTO _Mapper;

        public UserService(IMainUnitOfWork unit, IMapperDTO mapper)
        {
            _Unit = unit;
            _Mapper = mapper;
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(ClientProfileDTO client)
        {
            ClaimsIdentity claims = null;
            ApplicationUser user = await _Unit.Identity.UserManager.FindAsync(client.Email,client.Password);
            if (user != null)
                claims = await _Unit.Identity.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claims;
        }

        public async Task<OperationDetails> CreateAsync(ClientProfileDTO client)
        {
            ApplicationUser user = await _Unit.Identity.UserManager.FindByEmailAsync(client.Email);
            if (user == null)
            {
                user = new ApplicationUser() { UserName = client.Email, Email = client.Email };
                var result = await _Unit.Identity.UserManager.CreateAsync(user,client.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                var role = await _Unit.Identity.RoleManager.FindByNameAsync(client.Role);
                if (role == null)
                {
                    role = new ApplicationRole { Name = client.Role };
                    await _Unit.Identity.RoleManager.CreateAsync(role);
                }
                await _Unit.Identity.UserManager.AddToRoleAsync(user.Id,  client.Role);
                ClientProfile profile = new ClientProfile() { Id = user.Id, Name = client.Name };
                _Unit.Identity.ClientManager.Create(profile);
                return new OperationDetails(true,"","");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public void Dispose()
        {
            _Unit.Dispose();
        }

        public async Task<ClientProfileDTO> GetUserAsync(string name)
        {
            ClientProfile profile = (await _Unit.Identity.UserManager.FindByNameAsync(name))?.ClientProfile;
            if (profile != null)
                return _Mapper.ToClientProfileDTO.Map<ClientProfile,ClientProfileDTO>(profile);
            return null;
        }
    }
}
