using Contracts.DTO;
using Contracts.Interface.Repository;
using Contracts.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            return this._customerRepository.GetAll().ToList().ToCustomerDTO();
        }

        public CustomerDTO GetCustomerById(string id)
        {
            var customer = this._customerRepository.GetAll().Where(x => x.CustomerID.Equals(id)).FirstOrDefault();

            return customer != null ? customer.ToCustomerDTO() : null;
        }

        public List<CustomerDTO> GetCustomersByCountry(string country)
        {
            return this._customerRepository.GetAll().Where(x => x.Country.Equals(country)).ToList().ToCustomerDTO();
        }
    }
}
