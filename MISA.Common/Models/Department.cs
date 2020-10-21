using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    /// Khai báo các trường dữ liệu Department
    /// </summary>
    /// <returns></returns>
    /// CreatedBy: NKDAT (16/10/2020)
    public class Department
    {
        public Guid DepartmentId { set; get; }
        public string DepartmentCode { set; get; }
        public string DepartmentName { set; get; }
    }
}
