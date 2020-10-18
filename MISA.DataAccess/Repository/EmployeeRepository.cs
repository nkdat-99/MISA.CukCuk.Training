using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseAccess<Employee> databaseAccess) : base(databaseAccess)
        {
        }

        public object CheckEmployeeByCode(string employeeCode)
        {
            return _databaseAccess.Get("Proc_GetEmployeeByCode", employeeCode);
        }
    }
}
