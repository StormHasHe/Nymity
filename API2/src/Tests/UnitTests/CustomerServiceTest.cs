using Contracts.Interface.Repository;
using Contracts.Interface.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TesteData;

namespace Tests.UnitTests
{
    [TestClass]
    public class CustomerServiceTest
    {
        ICustomerRepository _mockCustomerRepository;
        ICustomerService _customerService;

        public CustomerServiceTest()
        {
            _mockCustomerRepository = MockRepository.GenerateMock<ICustomerRepository>();

            _mockCustomerRepository.Stub<ICustomerRepository>(x => x.GetAll()).Return(CustomerServiceMockData.CustomersList());

            _customerService = new CustomerService(_mockCustomerRepository);

        }

        [TestMethod]
        public void ReturnAllCustomers()
        {
            var customer = _customerService.GetAllCustomers();

            _mockCustomerRepository.AssertWasCalled<ICustomerRepository>(x => x.GetAll());
            Assert.IsTrue(customer.Count == 5, "GetAllCustomers not returning all customers");
        }

        [TestMethod]
        public void ReturnCustomerById()
        {
            var customer = _customerService.GetCustomerById("ADHAN");

            _mockCustomerRepository.AssertWasCalled<ICustomerRepository>(x => x.GetAll());
            Assert.IsTrue(customer.ContactName == "Adhan Maldonado", "ReturnCustomerById not returning customer");
        }

        [TestMethod]
        public void ReturnCustomerNotFound()
        {
            var customer = _customerService.GetCustomerById("IAGOG");

            _mockCustomerRepository.AssertWasCalled<ICustomerRepository>(x => x.GetAll());
            Assert.IsTrue(customer == null);
        }

        [TestMethod]
        public void ReturnCustomersByCountry_BR()
        {
            var customer = _customerService.GetCustomersByCountry("BR");

            _mockCustomerRepository.AssertWasCalled<ICustomerRepository>(x => x.GetAll());
            Assert.IsTrue(customer.Count == 2, "ReturnCustomersByCountry_BR not returning customers");
        }

        [TestMethod]
        public void ReturnCustomersByCountry_US()
        {
            var customer = _customerService.GetCustomersByCountry("US");

            _mockCustomerRepository.AssertWasCalled<ICustomerRepository>(x => x.GetAll());
            Assert.IsTrue(customer.Count == 1, "ReturnCustomersByCountry_BR not returning customers");
        }

        [TestMethod]
        public void ReturnCustomersByCountry_CA()
        {
            var customer = _customerService.GetCustomersByCountry("BR");

            _mockCustomerRepository.AssertWasCalled<ICustomerRepository>(x => x.GetAll());
            Assert.IsTrue(customer.Count == 2, "ReturnCustomersByCountry_BR not returning customers");
        }
    }
}
