using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Training.Models;

namespace MISA.CukCuk.Training.Api
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerApi : BaseApi<Customer>
    {
        ICustomerService _customerService;
        public CustomerApi(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
    }
}
