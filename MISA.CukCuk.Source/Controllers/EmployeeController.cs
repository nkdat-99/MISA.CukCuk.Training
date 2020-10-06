using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MISA.CukCuk.Training.Models;

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
            return Employee.EmployeeList.OrderBy(e => e.EmployeeCode);
        }

        // GET api/Employee/5
        [HttpGet("{employeeCode}")]
        public object Get(string employeeCode)
        {
            var employees = Employee.EmployeeList.Where(e => e.EmployeeCode == employeeCode).FirstOrDefault();
            return employees;
        }

        // POST api/Employee
        [HttpPost]
        public bool Post([FromBody] Employee employee)
        {
            Employee.EmployeeList.Add(employee);
            return true;
        }

        // PUT api/Employee
        [HttpPut]
        public bool Put([FromBody] Employee employee)
        {
            // Xác định đối tượng employee thực hiện chỉnh sửa thông tin trong List;
            var employeeEdit = Employee.EmployeeList.Where(e => e.EmployeeCode == employee.EmployeeCode).FirstOrDefault();
            Employee.EmployeeList.Remove(employeeEdit);
            Employee.EmployeeList.Add(employee);
            return true;
        }

        // DELETE api/Employee/5
        [HttpDelete("{employeeCode}")]
        public bool Delete(string employeeCode)
        {
            var result = false;
            // Xác định đối tượng employee thực hiện xóa thông tin trong List;
            var employeeDel = Employee.EmployeeList.Where(e => e.EmployeeCode.Equals(employeeCode)).FirstOrDefault();
            if (employeeDel != null)
            {
                Employee.EmployeeList.Remove(employeeDel);
                result = true;
            }
            return result;
        }
    }
}
