using Contracts.DTO;
using Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TesteData
{
    public static class CustomerServiceMockData
    {
        public static IEnumerable<Customer> CustomersList()
        {
            var list = new List<Customer>();

            var item1 = new Customer() {
                Address = "Street Paulo Jose",
                City = "Rio de Janeiro",
                CompanyName = "LCF",
                ContactName = "Jack Reacher",
                ContactTitle = "VP",
                Country = "BR",
                CustomerID = "JACKR",
                Fax = "",
                Phone = "+55 21 99367 6745",
                PostalCode = "22783-390",
                Region = "RJ"
            };

            var item2 = new Customer()
            {
                Address = "Street Nobrega",
                City = "Sao Paulo",
                CompanyName = "Capri",
                ContactName = "Priscilla Sousa",
                ContactTitle = "CEO",
                Country = "BR",
                CustomerID = "PRISC",
                Fax = "",
                Phone = "+55 11 99845 2332",
                PostalCode = "12834-878",
                Region = "SP"
            };

            var item3 = new Customer()
            {
                Address = "First Av",
                City = "New York",
                CompanyName = "Twill",
                ContactName = "John Smith",
                ContactTitle = "President",
                Country = "US",
                CustomerID = "JOHNS",
                Fax = "",
                Phone = "231 234 311",
                PostalCode = "123-3321",
                Region = "NY"
            };

            var item4 = new Customer()
            {
                Address = "Kipling Ave",
                City = "Toronto",
                CompanyName = "Jordans Equipments",
                ContactName = "Jordan Milles",
                ContactTitle = "President",
                Country = "CA",
                CustomerID = "JORDAN",
                Fax = "",
                Phone = "123 123 123",
                PostalCode = "123 456 789",
                Region = "ON"
            };

            var item5 = new Customer()
            {
                Address = "Duke St E",
                City = "Kitchener",
                CompanyName = "Adhan's Software House",
                ContactName = "Adhan Maldonado",
                ContactTitle = "Founder",
                Country = "CA",
                CustomerID = "ADHAN",
                Fax = "",
                Phone = "758 477 748",
                PostalCode = "989 8331",
                Region = "ON"
            };

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.Add(item4);
            list.Add(item5);

            return list.AsEnumerable();
        }
    }
}
