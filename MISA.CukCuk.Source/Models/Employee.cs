using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Models
{
    public partial class Employee
    {
        public Guid EmployeeId { get; set; }

        // Mã nhân viên
        public string EmployeeCode { get; set; }

        // Tên nhân viên
        public string EmployeeName { get; set; }

        // Tiền Lương nhân viên
        public double Salary { get; set; }

        // Giới tính nhân viên
        public GenderEnum Gender { set; get; }
        public string Sex
        {
            get
            {
                switch (Gender)
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

        // SĐT nhân viên
        public string PhoneNumber { get; set; }

        // Ngày Sinh nhân viên
        public DateTime? DayOfBirth { get; set; }

        // Vị trí công việc
        public Guid? PositionId { get; set; }

        // Phòng ban công việc
        public Guid? DepartmentId { get; set; }

        // Công Ty nhân viên
        public string Company { get; set; }

        // Số Tài Khoản
        public string BankCard { get; set; }

        // Địa Chỉ nhân viên
        public string Address { get; set; }

        // Email nhân viên
        public string Email { get; set; }

        // Ghi chú
        public string Note { get; set; }
    }
}
