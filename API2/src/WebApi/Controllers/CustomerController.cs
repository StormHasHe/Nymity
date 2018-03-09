using Contracts.DTO;
using Contracts.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Customers")]
    public class CustomerController : ApiController
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET api/Customers
        [Route("{customerId?}")]
        public IHttpActionResult GetCustomers(string customerId = null)
        {
            var response = new ResponseDTO<List<CustomerDTO>>() { Value = new List<CustomerDTO>() };

            try
            {
                if (!string.IsNullOrEmpty(customerId))
                {
                    var customer = _customerService.GetCustomerById(customerId);

                    if (customer != null)
                    {
                        response.Success = true;
                        response.Value.Add(customer);
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Customer not found.";
                    }
                }
                else
                {
                    response.Value = _customerService.GetAllCustomers();

                    if (response.Value.Count > 0)
                        response.Success = true;
                    else
                        response.Success = false;
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Exception = e;
                response.Message = "An error occurred while fetching the customers";
            }

            return Ok(response);
        }
    }
}
