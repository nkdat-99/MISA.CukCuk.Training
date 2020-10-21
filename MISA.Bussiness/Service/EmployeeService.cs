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

        /// <summary>
        /// Kiểm tra trùng nhân viên
        /// <param name="employeeCode">Số lượng bản ghi bỏ qua</param>
        /// <param name="id">Số lượng bản ghi lấy về</param>
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (16/10/2020)
        public object CheckEmployeeByCode(string employeeCode, object id)
        {
            return _employeeRepository.CheckEmployeeByCode(employeeCode, id);
        }

        /// <summary>
        /// Kiểm tra các yêu cầu nhập dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (16/10/2020)
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
