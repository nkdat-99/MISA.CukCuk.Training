using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Models
{
    /// <summary>
    /// Khai báo các trường dữ liệu Employee
    /// </summary>
    /// <returns></returns>
    /// CreatedBy: NKDAT (16/10/2020)
    public partial class Employee
    {
        // Id nhân viên
        public Guid EmployeeId { get; set; }

        // Mã nhân viên
        public string EmployeeCode { get; set; }

        // Tên nhân viên
        public string EmployeeName { get; set; }

        // Giới tính nhân viên
        public int? Gender { set; get; }
        public string sex
        {
            get
            {
                if (Gender == null)
                    return string.Empty;
                switch ((GenderEnum)Gender)
                {
                    case GenderEnum.Female:
                        return "Nữ";
                    case GenderEnum.Male:
                        return "Nam";
                    case GenderEnum.Other:
                        return "Khác";
                    default:
                        return "Không xác định";
                };
            }
        }

        // Email nhân viên
        public string Email { get; set; }

        // SĐT nhân viên
        public string PhoneNumber { get; set; }

        // Ngày Sinh nhân viên
        public DateTime? DayOfBirth { get; set; }

        // Số CMT/HC
        public string IdCard { get; set; }

        // Ngày cấp CMT/HC
        public DateTime? DayOfIdCard { get; set; }

        // Nơi chỉ cấp CMT/HC
        public string Address { get; set; }

        // Vị trí công việc
        public Guid? PositionId { get; set; }

        public string PositionName { get; set; }

        // Phòng ban công việc
        public Guid? DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        // Mã số thuế cá nhân
        public string TaxCode { get; set; }

        // Ngày cấp CMT/HC
        public DateTime? DayOfTaxCode { get; set; }

        // Mức Lương nhân viên
        public double Salary { get; set; }

        // Tình trạng nhân viên
        public int? Status { set; get; }
        public string statusShow
        {
            get
            {
                if (Status == null)
                    return string.Empty;
                switch ((StatusEnum)Status)
                {
                    case StatusEnum.Working:
                        return "Đang làm việc";
                    case StatusEnum.Intern:
                        return "Đang thử việc";
                    case StatusEnum.Quit:
                        return "Đã nghỉ việc";
                    default:
                        return "Không xác định";
                };
            }
        }
    }
}