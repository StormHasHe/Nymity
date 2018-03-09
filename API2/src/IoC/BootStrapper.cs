using Contracts.Interface.Repository;
using Identity.Configuration;
using Identity.Context;
using Identity.Model;
using DataAccess.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using Identity.Repository;
using Contracts.Interface.Service;
using Services.Services;
using Microsoft.Owin.Security;
using DataAccess.Context;

namespace IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IdentityIsolationContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);

            //Repositories
            container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Scoped);
            container.Register<IAuthRepository, AuthRepository>(Lifestyle.Scoped);

            //Services
            container.Register<IAccountService, AccountService>(Lifestyle.Scoped);
            container.Register<ICustomerService, CustomerService>(Lifestyle.Scoped);
        }
    }
}