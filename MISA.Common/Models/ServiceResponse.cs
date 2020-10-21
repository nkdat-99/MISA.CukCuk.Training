using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    /// Khai báo các trường dữ liệu trả về
    /// </summary>
    /// <returns></returns>
    /// CreatedBy: NKDAT (16/10/2020)
    public class ServiceResponse
    {
        public List<string> Msg { get; set; } = new List<string>();
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}
