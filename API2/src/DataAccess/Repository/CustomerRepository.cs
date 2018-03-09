using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Entities;
using Contracts.Interface.Repository;
using DataAccess.Context;

namespace DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IdentityIsolationContext _ctx;

        public CustomerRepository(IdentityIsolationContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _ctx.Customers.ToList();
        }

        public void Dispose()
        {
            _ctx.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}