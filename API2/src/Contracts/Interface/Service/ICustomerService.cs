using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Service
{
    public interface ICustomerService
    {
        List<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(string id);
        List<CustomerDTO> GetCustomersByCountry(string country);
    }
}
