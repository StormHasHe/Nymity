using Contracts.DTO;
using Contracts.Interface.Repository;
using Identity.Configuration;
using Identity.Context;
using Identity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private ApplicationDbContext _ctx;

        private ApplicationUserManager _userManager;

        public AuthRepository(ApplicationUserManager userManager, ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDTO userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.Email,
                Email = userModel.Email
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
