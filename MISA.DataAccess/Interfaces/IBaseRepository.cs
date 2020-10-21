using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (16/10/2020)
        IEnumerable<T> Get();
        IEnumerable<T> Get(int page, int size);
        IEnumerable<T> Get(string storeName);
        T GetById(object objId);
        int Insert(T obj);
        int Update(T obj);
        int Delete(object objId);
        int GetCount();
    }
}
