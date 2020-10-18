using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (15/10/2020)
        IEnumerable<T> Get();
        IEnumerable<T> Get(string storeName);
        T GetById(object objId);
        ServiceResponse Insert(T obj);
        ServiceResponse Update(T obj);
        int Delete(object objId);
    }
}
