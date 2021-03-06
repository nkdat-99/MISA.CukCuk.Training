﻿using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Các phương thức lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (15/10/2020)
        IEnumerable<T> Get();
        int GetCount();
        IEnumerable<T> Get(int page, int size);
        IEnumerable<T> Get(string storeName);
        T GetById(object objId);
        ServiceResponse Insert(T obj);
        ServiceResponse Update(T obj);
        int Delete(object objId);
    }
}
