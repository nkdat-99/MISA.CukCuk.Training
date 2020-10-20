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
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public object CheckEmployeeByCode(string employeeCode, object id)
        {
            return _employeeRepository.CheckEmployeeByCode(employeeCode, id);
        }

        protected override bool Validate(Employee entity, ref Employee outData)
        {
            var isValid = true;
            var announce = "";
            // Check các trường thông tin bắt buộc nhập:
            if (entity.EmployeeCode.Trim() == "")
            {
                isValid = false;
                announce += "Mã nhân viên";
            }
            if (entity.EmployeeName.Trim() == "")
            {
                isValid = false;
                if (announce != "")
                    announce += ", ";
                announce += "Họ và tên nhân viên";
            }
            if (entity.Email.Trim() == "")
            {
                isValid = false;
                if (announce != "")
                    announce += ", ";
                announce += "Email";
            }
            if (entity.PhoneNumber.Trim() == "")
            {
                isValid = false;
                if (announce != "")
                    announce += ", ";
                announce += "Số điện thoại";
            }
            if (isValid == false) {
                validateErrorResponseMsg.Add(announce);
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
                validateErrorResponseMsg.Add("Sai email");
                return isValid;
            }

            // Check trùng mã nhân viên:
            var isValidExitsCode = CheckEmployeeByCode(entity.EmployeeCode, entity.EmployeeId);
            if (isValidExitsCode != null)
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
