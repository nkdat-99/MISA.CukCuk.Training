using MISA.CukCuk.Training.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Kiểm tra thông tin nhân viên theo mã
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>true: có; false: không</returns>
        /// CreatedBy: NKDAT (15/10/2020)
        bool CheckCustomerByCode(string customerCode);
    }
}
