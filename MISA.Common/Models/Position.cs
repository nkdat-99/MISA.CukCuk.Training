using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    /// Khai báo các trường dữ liệu Position
    /// </summary>
    /// <returns></returns>
    /// CreatedBy: NKDAT (16/10/2020)
    public class Position
    {
        public Guid PositionId { set; get; }
        public string PositionName { set; get; }
    }
}
