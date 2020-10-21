using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using MISA.Common.Models;

namespace MISA.CukCuk.Training.Api
{
    /// <summary>
    /// Lấy dữ liệu bảng Department
    /// </summary>
    /// CreatedBy: NKDAT (16/10/2020)
    [Route("api/department")]
    [ApiController]
    public class DepartmentApi : BaseApi<Department>
    {
        public DepartmentApi(IBaseService<Department> baseService) : base(baseService)
        {

        }
    }
}
