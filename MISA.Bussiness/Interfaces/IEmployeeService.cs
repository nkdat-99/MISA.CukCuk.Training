﻿using MISA.CukCuk.Training.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// Kiểm tra thông tin nhân viên theo mã
        /// </summary>
        /// <param name="employeeCode"></param>
        /// /// <param name="id"></param>
        /// <returns>true: có; false: không</returns>
        /// CreatedBy: NKDAT (16/10/2020)
        public object CheckEmployeeByCode(string employeeCode, object id);
    }
}
