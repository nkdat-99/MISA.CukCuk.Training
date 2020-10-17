using MISA.CukCuk.Training.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface ICustomerService : IBaseService<Customer>
    {
        /// <summary>
        /// Kiểm tra thông tin nhân viên theo mã
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>true: có; false: không</returns>
        /// CreatedBy: NKDAT (16/10/2020)
        bool CheckCustomerByCode(string customerCode);
    }
}
