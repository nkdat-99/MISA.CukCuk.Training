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
    /// Lấy dữ liệu bảng Position
    /// </summary>
    /// CreatedBy: NKDAT (16/10/2020)
    [Route("api/position")]
    [ApiController]
    public class PositionApi : BaseApi<Position>
    {
        public PositionApi(IBaseService<Position> baseService) : base(baseService)
        {
        }
    }
}
