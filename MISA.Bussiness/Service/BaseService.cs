using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
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

        /// <summary>
        /// Xóa bản ghi từ DATABASE
        /// </summary>
        /// /// <param name="objectId">Mã Code của nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        public int Delete(object objectId)
        {
            return _baseRepository.Delete(objectId);
        }

        /// <summary>
        /// Lấy tất cả bản ghi từ DATABASE
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        /// <summary>
        /// Lấy số lượng bản ghi DATABASE theo paging
        /// </summary>
        /// <param name="page">Số lượng bản ghi bỏ qua</param>
        /// <param name="size">Số lượng bản ghi lấy về</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        public IEnumerable<T> Get(int page, int size)
        {
            return _baseRepository.Get(page, size);
        }

        /// <summary>
        /// Lấy số lượng tổng số bản ghi DATABASE
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        public int GetCount()
        {
            return _baseRepository.GetCount();
        }
        public IEnumerable<T> Get(string storeName)
        {
            return _baseRepository.Get(storeName);
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo Id
        /// </summary>
        /// <param name="id">Id của nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        public T GetById(object objectId)
        {
            return _baseRepository.GetById(objectId);
        }

        /// <summary>
        /// Thêm mới bản ghi vào DATABASE
        /// </summary>
        /// <param name="entity"></param>
        /// CreatedBy: NKDAT (16/10/2020)
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

        /// <summary>
        /// Sửa mới bản ghi vào DATABASE
        /// </summary>
        /// <param name="entity"></param>
        /// CreatedBy: NKDAT (16/10/2020)
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

        /// <summary>
        /// Kiểm tra các điều kiện nhập dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="returnValue"></param>
        /// CreatedBy: NKDAT (16/10/2020)
        protected virtual bool Validate(T entity, ref T returnValue)
        {
            return true;
        }
    }
}
