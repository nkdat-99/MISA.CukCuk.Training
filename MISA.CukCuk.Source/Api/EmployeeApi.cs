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
        public EmployeeApi(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
    }
}
