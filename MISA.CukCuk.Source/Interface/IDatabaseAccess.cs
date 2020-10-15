using MISA.CukCuk.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Interface
{
    public interface IDatabaseAccess
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(Guid employeeId);
        int Insert(Employee employee);
        int Update(Employee employee);
        int Delete(Guid id);
    }
}
