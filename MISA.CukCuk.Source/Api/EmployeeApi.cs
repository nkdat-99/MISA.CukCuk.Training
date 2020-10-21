using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;

namespace MISA.CukCuk.Training.Api
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeApi : BaseApi<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeeApi(IEmployeeService employeeService):base(employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Lấy dữ liệu mã nhân viên mới nhất từ DATABASE
        /// </summary>
        /// CreatedBy: NKDAT (16/10/2020)
        [HttpGet("NewEmployeeCode")]
        public string NewEmployeeCode()
        {
            var t = _employeeService.Get("Proc_GetNewEmployeeCode");
            if (t.Any())
            {
                return "NV"+ ( int.Parse(t.First().EmployeeCode.Replace("NV", ""))+1).ToString().PadLeft(5, '0');
            }
            else
            {
                return "";
            }
        }
    }
}
