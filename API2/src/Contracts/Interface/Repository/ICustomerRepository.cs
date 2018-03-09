using System;
using System.Collections.Generic;
using Contracts.Entities;

namespace Contracts.Interface.Repository
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> GetAll();
    }
}