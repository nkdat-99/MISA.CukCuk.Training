using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class BaseService<T> : IBaseService<T> where T: new()
    {
        IBaseRepository<T> _baseRepository;
        protected List<string> validateErrorResponseMsg = new List<string>();
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public int Delete(object objectId)
        {
            return _baseRepository.Delete(objectId);
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }
        public IEnumerable<T> Get(string storeName)
        {
            return _baseRepository.Get(storeName);
        }

        public T GetById(object objectId)
        {
            return _baseRepository.GetById(objectId);
        }

        public ServiceResponse Insert(T entity)
        {
            var serviceResponse = new ServiceResponse();
            T temp = new T();
            if (Validate(entity, ref temp) == true)
            {
                serviceResponse.Success = true;
                serviceResponse.Msg.Add("Thành công");
                serviceResponse.Data = _baseRepository.Insert(entity);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Msg = validateErrorResponseMsg;
                serviceResponse.Data = temp;
            }
            return serviceResponse;
        }


        public ServiceResponse Update(T entity)
        {
            var serviceResponse = new ServiceResponse();
            T temp = new T();
            if (Validate(entity, ref temp) == true)
            {
                serviceResponse.Success = true;
                serviceResponse.Msg.Add("Thành công");
                serviceResponse.Data = _baseRepository.Update(entity);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Msg = validateErrorResponseMsg;
                serviceResponse.Data = temp;
            }
            return serviceResponse;
        }

        protected virtual bool Validate(T entity, ref T returnValue)
        {
            return true;
        }
    }
}
