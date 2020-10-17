using MISA.CukCuk.Training.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseMariaDBAccess<Employee> databaseMariaDBContext) : base(databaseMariaDBContext)
        {
        }

        public bool CheckEmployeeByCode(string employeeCode)
        {
            var objectValue = _databaseContext.Get("Proc_GetEmployeeByCode", employeeCode);
            if (objectValue == null)
                return false;
            else
                return true;
        }
    }
}
