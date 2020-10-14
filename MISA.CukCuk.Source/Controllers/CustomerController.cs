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
    public class CustomerController : ControllerBase
    {
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customerService = new ServiceCustomer();
            return customerService.GetCustomers();
        }

        //// GET api/Customer/5
        //[HttpGet("{customerCode}")]
        //public object Get(string customerCode)
        //{
        //    var customers = Customer.CustomerList.Where(e => e.CustomerCode == customerCode).FirstOrDefault();
        //    return customers;
        //}

        //// POST api/Customer
        [HttpPost]
        public int Post([FromBody] Customer customer)
        {
            var customerService = new ServiceCustomer();
            return customerService.PostCustomers(customer);
        }

        //// PUT api/Customer
        //[HttpPut]
        //public bool Put([FromBody] Customer customer)
        //{
        //    // Xác định đối tượng employee thực hiện chỉnh sửa thông tin trong List;
        //    var customerEdit = Customer.CustomerList.Where(e => e.CustomerCode == customer.CustomerCode).FirstOrDefault();
        //    Customer.CustomerList.Remove(customerEdit);
        //    Customer.CustomerList.Add(customer);
        //    return true;
        //}

        // DELETE api/Customer/5
        [HttpDelete("{customerId}")]
        public int Delete(Guid customerId)
        {
            var customerService = new ServiceCustomer();
            return customerService.DeleteCustomers(customerId);
        }
    }
}
