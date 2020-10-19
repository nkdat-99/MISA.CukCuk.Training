using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Training.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository):base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public object CheckEmployeeByCode(string employeeCode)
        {
            return _employeeRepository.CheckEmployeeByCode(employeeCode);
        }

        protected override bool Validate(Employee entity, ref Employee outData)
        {
            var isValid = true;
            // Check các trường thông tin bắt buộc nhập:
            if (entity.EmployeeCode.Trim() == "" || entity.EmployeeName.Trim() == "" || entity.Email.Trim() == "" || entity.PhoneNumber.Trim() == "")
            {
                isValid = false;
                validateErrorResponseMsg.Add("Nhập thông tin");
                return isValid;
            }

            // Check định dạng Email:
            try
            {
                MailAddress mail = new MailAddress(entity.Email);
            }
            catch (FormatException)
            {
                isValid = false;
                validateErrorResponseMsg.Add("Sai Email");
                return isValid;
            }

            // Check trùng mã nhân viên:
            var isValidExitsCode = CheckEmployeeByCode(entity.EmployeeCode);
            if (isValidExitsCode!=null)
            {
                isValid = false;
                validateErrorResponseMsg.Add("Mã bị trùng");
                outData = isValidExitsCode as Employee;
                return isValid;
            }
            return isValid;
        }
    }
}
