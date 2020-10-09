using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Models
{
    public class Employee
    {
        public static List<Employee> EmployeeList = new List<Employee>() {
            new Employee(){EmployeeCode = "NV0001", EmployeeName = "Nguyễn Đức Nhân", EmployeeSalary = 100000, Gender = 0, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0002", EmployeeName = "Vũ Quang Sơn", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0003", EmployeeName = "Vũ Văn Thức", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0004", EmployeeName = "Nguyễn Đức Nhân", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0005", EmployeeName = "Vũ Quang Sơn", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0006", EmployeeName = "Vũ Văn Thức", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0007", EmployeeName = "Nguyễn Đức Nhân", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0008", EmployeeName = "Vũ Quang Sơn", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0009", EmployeeName = "Vũ Văn Thức", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0010", EmployeeName = "Nguyễn Đức Nhân", EmployeeSalary = 100000,Gender = 0, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0011", EmployeeName = "Vũ Quang Sơn", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0012", EmployeeName = "Vũ Văn Thức", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0013", EmployeeName = "Nguyễn Đức Nhân", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0014", EmployeeName = "Vũ Quang Sơn", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0015", EmployeeName = "Vũ Văn Thức", EmployeeSalary = 100000, Gender = 2, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0016", EmployeeName = "Nguyễn Đức Nhân", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0017", EmployeeName = "Vũ Quang Sơn", EmployeeSalary = 100000, Gender = 2, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0018", EmployeeName = "Vũ Văn Thức", EmployeeSalary = 100000, Gender = 1, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeePosition = "Nhân Viên", EmployeeCompany = "MISA", EmployeeDepartment = "Web", EmployeeBankCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""}
        };

        public Employee()
        {
            EmployeeId = Guid.NewGuid();
        }
        public Guid EmployeeId { get; set; }

        // Mã nhân viên
        public string EmployeeCode { get; set; }

        // Tên nhân viên
        public string EmployeeName { get; set; }

        // Tiền Lương nhân viên
        public double EmployeeSalary { get; set; }

        //GenderEnum
        //public GenderEnum Gender;
        //public string EmployeeSex
        //{
        //    get
        //    {
        //        switch (Gender)
        //        {
        //            case GenderEnum.Female:
        //                return "Nữ";
        //            case GenderEnum.Male:
        //                return "Nam";
        //            case GenderEnum.Other:
        //                return "Khác";
        //            default:
        //                return "Không xác định";
        //        };
        //    }
        //    set
        //    {
        //        if (value == "Nữ")
        //        {
        //            Gender = GenderEnum.Female;
        //        }
        //        else if (value == "Nam")
        //        {
        //            Gender = GenderEnum.Male;
        //        }
        //        else
        //        {
        //            Gender = GenderEnum.Other;

        //        }
        //    }
        //}

        public int Gender;
        public string EmployeeSex
        {
            get
            {
                switch (Gender)
                {
                    case 0:
                        return "Nữ";
                    case 1:
                        return "Nam";
                    case 2:
                        return "Khác";
                    default:
                        return "Không xác định";
                };
            }
            set
            {
                if (value == "Nữ")
                {
                    Gender = 0;
                }
                else if (value == "Nam")
                {
                    Gender = 1;
                }
                else
                {
                    Gender = 2;

                }
            }
        }

        // SĐT nhân viên
        public string EmployeeMobile { get; set; }

        // Ngày Sinh nhân viên
        public DateTime? EmployeeBirthday { get; set; }

        // Vị trí công việc
        public string EmployeePosition { get; set; }

        // Phòng ban công việc
        public string EmployeeDepartment { get; set; }

        // Công Ty nhân viên
        public string EmployeeCompany { get; set; }

        // Số Tài Khoản
        public string EmployeeBankCard { get; set; }

        // Địa Chỉ nhân viên
        public string EmployeeAddress { get; set; }

        // Email nhân viên
        public string EmployeeEmail { get; set; }

        // Ghi chú
        public string EmployeeNote { get; set; }
    }
}
