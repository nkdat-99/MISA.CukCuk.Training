using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected IDatabaseMariaDBAccess<T> _databaseContext;
        public BaseRepository(IDatabaseMariaDBAccess<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public int Delete(Guid id)
        {
            return _databaseContext.Delete(id);
        }

        public IEnumerable<T> Get()
        {
            return _databaseContext.Get();
        }

        public T GetById(Guid objId)
        {
            return _databaseContext.GetById(objId);
        }

        public int Insert(T entity)
        {
            return _databaseContext.Insert(entity);
        }

        public int Update(T entity)
        {
            return _databaseContext.Update(entity);
        }
    }
}
