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
            var obj = _baseService.GetById(id);
            if (obj != null)
                return Ok(obj);
            else
                return NoContent();
        }

        // POST api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] T obj)
        {
            var serviceResponse = _baseService.Insert(obj);
            if (serviceResponse.Success)
                return CreatedAtAction("POST", (serviceResponse.Data ?? 0));
            else
                return BadRequest(serviceResponse);
        }

        // PUT api/Employee
        [HttpPut]
        public IActionResult Put([FromBody] T obj)
        {
            var serviceResponse = _baseService.Update(obj);
            var result = serviceResponse.Data != null ? ((int)serviceResponse.Data) : 0;
            if (result > 0)
                return CreatedAtAction("PUT", result);
            else
                return BadRequest(serviceResponse);
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            var obj = 0;
            foreach (var s in id.Split(','))
            {
                obj += _baseService.Delete(Guid.Parse(s));
            }

            if (obj != 0)
                return Ok(obj);
            else
                return NoContent();
        }
    }
}
