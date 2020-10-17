using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface IDatabaseMariaDBAccess<T>
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(string storeName);
        object Get(string storeName, string code);
        T GetById(Guid objId);
        int Insert(T obj);
        int Update(T obj);
        int Delete(Guid id);
    }
}
