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

        /// <summary>
        /// Lấy tất cả bản ghi từ DATABASE
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        [HttpGet]
        public IActionResult Get()
        {
            var rs = _baseService.Get();
            if (rs != null)
                return Ok(rs);
            else
                return NoContent();
        }

        /// <summary>
        /// Lấy số lượng tổng số bản ghi DATABASE
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            var rs = _baseService.GetCount();
            if (rs >= 0)
                return Ok(rs);
            else
                return NoContent();
        }

        /// <summary>
        /// Lấy số lượng bản ghi DATABASE theo paging
        /// </summary>
        /// <param name="page">Số lượng bản ghi bỏ qua</param>
        /// <param name="size">Số lượng bản ghi lấy về</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        [HttpGet("paging")]
        public IActionResult Get([FromQuery] int page, int size)
        {
            var rs = _baseService.Get(page, size);
            if (rs != null)
                return Ok(rs);
            else
                return NoContent();
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo Id
        /// </summary>
        /// <param name="id">Id của nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var obj = _baseService.GetById(id);
            if (obj != null)
                return Ok(obj);
            else
                return NoContent();
        }

        /// <summary>
        /// Thêm bản ghi mới vào DATABASE
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        [HttpPost]
        public IActionResult Post([FromBody] T obj)
        {
            var serviceResponse = _baseService.Insert(obj);
            if (serviceResponse.Success)
                return CreatedAtAction("POST", (serviceResponse.Data ?? 0));
            else
                return BadRequest(serviceResponse);
        }

        /// <summary>
        /// Sửa bản ghi mới vào DATABASE
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        [HttpPut]
        public IActionResult Put([FromBody] T obj)
        {
            var serviceResponse = _baseService.Update(obj);
            if (serviceResponse.Success)
                return CreatedAtAction("PUT", (serviceResponse.Data ?? 0));
            else
                return BadRequest(serviceResponse);
        }

        /// <summary>
        /// Xóa bản ghi từ DATABASE
        /// </summary>
        /// /// <param name="code">Mã Code của nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        [HttpDelete("{code}")]
        public IActionResult Delete([FromRoute] string code)
        {
            var obj = 0;
            foreach (var s in code.Split(','))
            {
                obj += _baseService.Delete(s);
            }

            if (obj != 0)
                return Ok(obj);
            else
                return NoContent();
        }
    }
}
