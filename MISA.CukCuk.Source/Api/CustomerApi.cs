using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MISA.CukCuk.Training.Models;
using MySql.Data.MySqlClient;

namespace MISA.CukCuk.Training.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerApi : ControllerBase
    {
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customerService = new ServiceCustomer();
            return customerService.GetCustomers();
        }

        // GET api/Customer/5
        [HttpGet("{customerId}")]
        public object Get(Guid customerId)
        {
            var customerService = new ServiceCustomer();
            return customerService.GetCustomerById(customerId);
        }

        //// POST api/Customer
        [HttpPost]
        public int Post([FromBody] Customer customer)
        {
            var customerService = new ServiceCustomer();
            return customerService.PostCustomers(customer);
        }

        // PUT api/Customer
        [HttpPut("{id}")]
        public int Put([FromBody] Customer customer, string id)
        {
            customer.CustomerId = Guid.Parse(id);
            var customerService = new ServiceCustomer();
            return customerService.PutCustomers(customer);
        }

        // DELETE api/Customer/5
        [HttpDelete("{customerId}")]
        public int Delete(Guid customerId)
        {
            var customerService = new ServiceCustomer();
            return customerService.DeleteCustomers(customerId);
        }
    }
}
