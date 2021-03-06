﻿using MISA.CukCuk.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Interface
{
    public interface IDatabaseAccess<T>
    {
        /// <summary>
        /// Các phương thức lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (16/10/2020)
        IEnumerable<T> Get();
        int GetCount();
        IEnumerable<T> Get(int page, int name);
        IEnumerable<T> Get(string storeName);
        object Get(string storeName, string code, object id);
        T GetById(object id);
        int Insert(T obj);
        int Update(T obj);
        int Delete(object id);
    }
}
