using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface IBaseBussiness<T>
    {
        /// <summary>
        /// Các phương thức lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (16/10/2020)
        IEnumerable<T> Get();
        T GetById(Guid objId);
        int Insert(T obj);
        int Update(T obj);
        int Delete(Guid id);
    }
}
