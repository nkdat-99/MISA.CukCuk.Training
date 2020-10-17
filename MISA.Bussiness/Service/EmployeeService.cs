using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Training.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool CheckEmployeeByCode(string employeeCode)
        {
            return _employeeRepository.CheckEmployeeByCode(employeeCode);
        }

        protected override bool Validate(Employee entity)
        {
            var isValid = true;
            // Check trùng mã:
            var isValidExitsCode = CheckEmployeeByCode(entity.EmployeeCode);
            if (isValidExitsCode)
            {
                isValid = false;
                validateErrorResponseMsg.Add("Mã bị trùng 1");
            }

            // Check trùng số chứng minh thư:
            var isValidExitsMobile = CheckEmployeeByCode(entity.EmployeeCode);
            if (isValidExitsMobile)
            {
                isValid = false;
                validateErrorResponseMsg.Add("Bị trùng số điện thoại");
            }

            return isValid;
        }
    }
}
