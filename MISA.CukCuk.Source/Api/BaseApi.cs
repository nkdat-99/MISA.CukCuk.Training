using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApi<T> : ControllerBase
    {
        IBaseService<T> _baseService;
        public BaseApi(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            var rs = _baseService.Get();
            if (rs != null)
                return Ok(rs);
            else
                return NoContent();
        }

        // GET api/Employee/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var employee = _baseService.GetById(id);
            if (employee != null)
                return Ok(employee);
            else
                return NoContent();
        }

        // POST api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] T obj)
        {
            var serviceResponse = _baseService.Insert(obj);
            var result = serviceResponse.Data != null ? ((int)serviceResponse.Data) : 0;
            if (result > 0)
                return CreatedAtAction("POST", result);
            else
                return BadRequest(serviceResponse);
        }

        // PUT api/Employee/id
        public IActionResult Put([FromBody] T employee, string id)
        {
            employee.EmployeeId = Guid.Parse(id);
            var result = _databaseAccess.Update(employee);
            if (result > 0)
                return CreatedAtAction("PUT", result);
            else
                return BadRequest();
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
