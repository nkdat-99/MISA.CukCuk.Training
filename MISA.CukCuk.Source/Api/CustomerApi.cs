using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Training.Api;
using MISA.CukCuk.Training.Models;

namespace MISA.CukCuk.Training.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerApi : BaseApi<Customer>
    {
        IEmployeeService _employeeService;
        public CustomerApi(IEmployeeService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
    }
}
