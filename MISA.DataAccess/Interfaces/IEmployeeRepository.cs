using MISA.CukCuk.Training.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Kiểm tra thông tin nhân viên theo mã
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>true: có; false: không</returns>
        /// CreatedBy: NKDAT (15/10/2020)
        object CheckEmployeeByCode(string employeeCode);
    }
}
