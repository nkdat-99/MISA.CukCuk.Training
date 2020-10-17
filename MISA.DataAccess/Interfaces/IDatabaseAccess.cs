using MISA.CukCuk.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Interface
{
    public interface IDatabaseAccess<T>
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(string storeName);
        object Get(string storeName, string code);
        T GetById(Guid employeeId);
        int Insert(T employee);
        int Update(T employee);
        int Delete(Guid id);
    }
}
