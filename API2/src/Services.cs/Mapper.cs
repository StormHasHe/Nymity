using Contracts.DTO;
using Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal static class Mapper
    {
        public static CustomerDTO ToCustomerDTO(this Customer customer)
        {
            var customerDto = new CustomerDTO()
            {
                Address = customer.Address,
                City = customer.City,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Country = customer.Country,
                CustomerID = customer.CustomerID,
                Fax = customer.Fax,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Region = customer.Region
            };

            return customerDto;
        }

        public static List<CustomerDTO> ToCustomerDTO(this List<Customer> customers)
        {
            var customerList = new List<CustomerDTO>();

            foreach (var customer in customers)
            {
                var customerDto = new CustomerDTO()
                {
                    Address = customer.Address,
                    City = customer.City,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Country = customer.Country,
                    CustomerID = customer.CustomerID,
                    Fax = customer.Fax,
                    Phone = customer.Phone,
                    PostalCode = customer.PostalCode,
                    Region = customer.Region
                };

                customerList.Add(customerDto);
            }

            return customerList;
        }
    }
}
