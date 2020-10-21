using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    /// <summary>
    /// Lấy dữ liệu
    /// </summary>
    /// <returns></returns>
    /// CreatedBy: NKDAT (20/10/2020)
    /// 
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseAccess<Employee> databaseAccess) : base(databaseAccess)
        {
        }

        public object CheckEmployeeByCode(string employeeCode, object id)
        {
            return _databaseAccess.Get("Proc_GetEmployeeByCode", employeeCode, id);
        }
    }
}
