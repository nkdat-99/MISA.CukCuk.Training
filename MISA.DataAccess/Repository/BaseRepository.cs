﻿using MISA.CukCuk.Training.Interface;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected IDatabaseAccess<T> _databaseAccess;
        public BaseRepository(IDatabaseAccess<T> databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }
        public int Delete(object objId)
        {
            return _databaseAccess.Delete(objId);
        }

        public IEnumerable<T> Get()
        {
            return _databaseAccess.Get();
        }

        public IEnumerable<T> Get(string storeName)
        {
            return _databaseAccess.Get(storeName);
        }

        public T GetById(object objId)
        {
            return _databaseAccess.GetById(objId);
        }

        public int Insert(T entity)
        {
            return _databaseAccess.Insert(entity);
        }

        public int Update(T entity)
        {
            return _databaseAccess.Update(entity);
        }
    }
}
