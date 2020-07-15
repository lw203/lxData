using Lx.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByName(string name);
    }
}
