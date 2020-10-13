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
        //[HttpGet("{employeeCode}")]
        //public object Get(string employeeCode)
        //{
        //    var employees = Employee.EmployeeList.Where(e => e.EmployeeCode == employeeCode).FirstOrDefault();
        //    return employees;
        //}

        // POST api/Employee
        [HttpPost]
        public int Post([FromBody] Employee employee)
        {
            var employeeService = new ServiceEmployee();
            return employeeService.PostEmployees(employee);
        }

        //// PUT api/Employee
        //[HttpPut]
        //public bool Put([FromBody] Employee employee)
        //{
        //    // Xác định đối tượng employee thực hiện chỉnh sửa thông tin trong List;
        //    var employeeEdit = Employee.EmployeeList.Where(e => e.EmployeeCode == employee.EmployeeCode).FirstOrDefault();
        //    Employee.EmployeeList.Remove(employeeEdit);
        //    Employee.EmployeeList.Add(employee);
        //    return true;
        //}

        //// DELETE api/Employee/5
        //[HttpDelete("{employeeCode}")]
        //public bool Delete(string employeeCode)
        //{
        //    var result = false;
        //    // Xác định đối tượng employee thực hiện xóa thông tin trong List;
        //    var employeeDel = Employee.EmployeeList.Where(e => e.EmployeeCode.Equals(employeeCode)).FirstOrDefault();
        //    if (employeeDel != null)
        //    {
        //        Employee.EmployeeList.Remove(employeeDel);
        //        result = true;
        //    }
        //    return result;
        //}
    }
}
