using Contracts.DTO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Repository
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(UserRegisterDTO userModel);
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
