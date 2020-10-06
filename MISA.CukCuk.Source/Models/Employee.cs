using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Models
{
    public class Employee
    {
        public static List<Employee> EmployeeList = new List<Employee>() {
            new Employee(){EmployeeCode = "NV0001", EmployeeName = "Nguyễn Đức Nhân", EmployeeMoney = 100000, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeeCompany = "MISA", EmployeeCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0002", EmployeeName = "Vũ Quang Sơn", EmployeeMoney = 100000, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeeCompany = "MISA", EmployeeCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0003", EmployeeName = "Vũ Văn Thức", EmployeeMoney = 100000, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeeCompany = "MISA", EmployeeCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0004", EmployeeName = "Nguyễn Đức Nhân", EmployeeMoney = 100000, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeeCompany = "MISA", EmployeeCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0005", EmployeeName = "Vũ Quang Sơn", EmployeeMoney = 100000, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeeCompany = "MISA", EmployeeCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0006", EmployeeName = "Vũ Văn Thức", EmployeeMoney = 100000, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeeCompany = "MISA", EmployeeCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0007", EmployeeName = "Nguyễn Đức Nhân", EmployeeMoney = 100000, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeeCompany = "MISA", EmployeeCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0008", EmployeeName = "Vũ Quang Sơn", EmployeeMoney = 100000, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeeCompany = "MISA", EmployeeCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0009", EmployeeName = "Vũ Văn Thức", EmployeeMoney = 100000, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeeCompany = "MISA", EmployeeCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0010", EmployeeName = "Nguyễn Đức Nhân", EmployeeMoney = 100000, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeeCompany = "MISA", EmployeeCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0011", EmployeeName = "Vũ Quang Sơn", EmployeeMoney = 100000, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeeCompany = "MISA", EmployeeCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0012", EmployeeName = "Vũ Văn Thức", EmployeeMoney = 100000, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeeCompany = "MISA", EmployeeCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0013", EmployeeName = "Nguyễn Đức Nhân", EmployeeMoney = 100000, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeeCompany = "MISA", EmployeeCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0014", EmployeeName = "Vũ Quang Sơn", EmployeeMoney = 100000, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeeCompany = "MISA", EmployeeCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0015", EmployeeName = "Vũ Văn Thức", EmployeeMoney = 100000, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeeCompany = "MISA", EmployeeCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0016", EmployeeName = "Nguyễn Đức Nhân", EmployeeMoney = 100000, EmployeeMobile = "0359484106", EmployeeBirthday = new DateTime (1999, 10 , 20), EmployeeCompany = "MISA", EmployeeCard = "0325 0154 359", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12321323@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0017", EmployeeName = "Vũ Quang Sơn", EmployeeMoney = 100000, EmployeeMobile = "0359834106", EmployeeBirthday = new DateTime (1999, 10 , 4), EmployeeCompany = "MISA", EmployeeCard = "3568 1021 0214", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "aaaaabbbbbb@gmail.com", EmployeeNote=""},
            new Employee(){EmployeeCode = "NV0018", EmployeeName = "Vũ Văn Thức", EmployeeMoney = 100000, EmployeeMobile = "0389434106", EmployeeBirthday = new DateTime (1999, 5 , 30), EmployeeCompany = "MISA", EmployeeCard = "3695 0154 016", EmployeeAddress = "Hà Đông, Hà Nội",  EmployeeEmail = "12ooooooorrrr@gmail.com", EmployeeNote=""}
        };

        // Mã nhân viên
        public string EmployeeCode { get; set; }

        // Tên nhân viên
        public string EmployeeName { get; set; }

        // Tiền Lương nhân viên
        public double EmployeeMoney { get; set; }

        // SĐT nhân viên
        public string EmployeeMobile { get; set; }

        // Ngày Sinh nhân viên
        public DateTime? EmployeeBirthday { get; set; }

        // Công Ty nhân viên
        public string EmployeeCompany { get; set; }

        // Số Tài Khoản
        public string EmployeeCard { get; set; }

        // Địa Chỉ nhân viên
        public string EmployeeAddress { get; set; }

        // Email nhân viên
        public string EmployeeEmail { get; set; }

        // Ghi chú
        public string EmployeeNote { get; set; }
    }
}
