using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;
using MySql.Data.MySqlClient;

namespace MISA.CukCuk.Training.Api
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeApi : ControllerBase
    {
        IDatabaseAccess _databaseAccess;

        public EmployeeApi(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _databaseAccess.GetEmployees();
            if (employees.Count() > 0)
                return Ok(employees);
            else
                return NoContent();
        }

        // GET api/Employee/5
        [HttpGet("{employeeId}")]
        public IActionResult Get(Guid employeeId)
        {
            var employee = _databaseAccess.GetEmployeeById(employeeId);
            if (employee != null)
                return Ok(employee);
            else
                return NoContent();
        }

        // POST api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var result = _databaseAccess.Insert(employee);
            if (result > 0)
                return CreatedAtAction("POST", result);
            else
                return BadRequest();
        }

        //// PUT api/Employee/id
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Employee employee, string id)
        {
            employee.EmployeeId = Guid.Parse(id);
            var result = _databaseAccess.Update(employee);
            if (result > 0)
                return CreatedAtAction("PUT", result);
            else
                return BadRequest();
        }

        // DELETE api/Employee/5
        [HttpDelete("{employeeId}")]
        public IActionResult Delete(Guid employeeId)
        {
            var result = _databaseAccess.Delete(employeeId);
            if (result > 0)
                return CreatedAtAction("DELETE", result);
            else
                return BadRequest();
        }
    }
}
