using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        public Customer GetCustomer(int id);
    }
}
