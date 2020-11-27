using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class JsonCustomerRepository : ICustomerRepository
    {
        string JsonFileName = @"Data\JsonCustomerRepository.json";

        public List<Customer> GetAllCustomers()
        {
            return JsonFileReader.ReadJsonCustomer(JsonFileName);
        }
        public void AddCustomer(Customer customer)
        {
            List<Customer> customers = GetAllCustomers().ToList();
            List<int> customerIDs = new List<int>();

            foreach (Customer customerAlt in customers)
            {
                customerIDs.Add(customerAlt.ID);
            }

            if (customerIDs.Count != 0)
            {
                int i = customerIDs.Max();
                customer.ID = i + 1;
            }
            else
            {
                customer.ID = 1;
            }

            customers.Add(customer);
            JsonFileWriter.WriteToJsonCustomer(customers, JsonFileName);
        }

        public Customer GetCustomer(int id)
        {
            foreach (Customer customer in GetAllCustomers())
            {
                if (customer.ID == id)
                    return customer;
            }
            return new Customer();
        }
    }
}
