using MISA.CukCuk.Training.Interface;
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
        public int Delete(Guid id)
        {
            return _databaseAccess.Delete(id);
        }

        public IEnumerable<T> Get()
        {
            return _databaseAccess.Get();
        }

        public T GetById(Guid objId)
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
