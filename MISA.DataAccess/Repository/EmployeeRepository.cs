﻿using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseAccess<Employee> databaseAccess) : base(databaseAccess)
        {
        }

        public bool CheckEmployeeByCode(string employeeCode)
        {
            var objectValue = _databaseAccess.Get("Proc_GetEmployeeByCode", employeeCode);
            if (objectValue == null)
                return false;
            else
                return true;
        }
    }
}
