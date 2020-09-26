using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MISA.CukCuk.Training.Models;

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
            return Customer.CustomerList.OrderBy(e => e.CustomerCode);
        }

        // GET api/Customer/5
        [HttpGet("{customerCode}")]
        public object Get(string customerCode)
        {
            var customers = Customer.CustomerList.Where(e => e.CustomerCode == customerCode).FirstOrDefault();
            return customers;
        }

        // POST api/Customer
        [HttpPost]
        public bool Post([FromBody]Customer customer)
        {
            Customer.CustomerList.Add(customer);
            return true;
        }

        // PUT api/Customer
        [HttpPut]
        public bool Put([FromBody]Customer customer)
        {
            // Xác định đối tượng employee thực hiện chỉnh sửa thông tin trong List;
            var customerEdit = Customer.CustomerList.Where(e => e.CustomerCode == customer.CustomerCode).FirstOrDefault();
            Customer.CustomerList.Remove(customerEdit);
            Customer.CustomerList.Add(customer);
            return true;
        }

        // DELETE api/Customer/5
        [HttpDelete("{customerCode}")]
        public bool Delete(string customerCode)
        {
            var result = false;
            // Xác định đối tượng employee thực hiện xóa thông tin trong List;
            var customerDel = Customer.CustomerList.Where(e => e.CustomerCode.Equals(customerCode)).FirstOrDefault();
            if (customerDel != null)
            {
                Customer.CustomerList.Remove(customerDel);
                result = true;
            }
            return result;
        }
    }
}
