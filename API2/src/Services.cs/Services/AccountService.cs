using Contracts.DTO;
using Contracts.Interface.Repository;
using Contracts.Interface.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AccountService : IAccountService
    {
        private IAuthRepository _authRepository;

        public AccountService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<IdentityResult> RegisterUser(UserRegisterDTO userModel)
        {
            return _authRepository.RegisterUser(userModel);
        }

        public Task<IdentityUser> FindUser(string userName, string password)
        {
            return _authRepository.FindUser(userName, password);
        }
    }
}
