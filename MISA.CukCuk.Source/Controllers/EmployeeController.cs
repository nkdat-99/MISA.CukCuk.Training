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
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employeeService = new ServiceEmployee();
            return employeeService.GetEmployees();
        }

        // GET api/Employee/5
        [HttpGet("{employeeId}")]
        public object Get(Guid employeeId)
        {
            var employeeService = new ServiceEmployee();
            return employeeService.GetEmployeeId(employeeId);
        }

        // POST api/Employee
        [HttpPost]
        public int Post([FromBody] Employee employee)
        {
            var employeeService = new ServiceEmployee();
            return employeeService.PostEmployees(employee);
        }

        //// PUT api/Employee
        [HttpPut]
        public int Put([FromBody] Employee employee)
        {
            var employeeService = new ServiceEmployee();
            return employeeService.PutEmployees(employee);
        }

        // DELETE api/Employee/5
        [HttpDelete("{employeeId}")]
        public int Delete(Guid employeeId)
        {
            var employeeService = new ServiceEmployee();
            return employeeService.DeleteEmployees(employeeId);
        }
    }
}
