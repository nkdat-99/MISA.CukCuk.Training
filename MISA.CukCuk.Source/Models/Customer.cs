﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Models
{
    public class Customer
    {
        public static List<Customer> CustomerList = new List<Customer>() {
            new Customer(){CustomerCode = "KH0001", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0002", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0003", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0004", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0005", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0006", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0007", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0008", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0009", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0010", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0011", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0012", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0013", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0014", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0015", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0016", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0017", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0018", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0019", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0020", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0021", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0022", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0023", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0024", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0025", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0026", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0027", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0028", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0029", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0030", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0031", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0032", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0033", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0034", CustomerName = "Lại Thị Huyền", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0035", CustomerName = "Nguyễn Kim Đạt", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 30), CustomerCompany = "Công ty cổ phần MISA", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""},
            new Customer(){CustomerCode = "KH0036", CustomerName = "Từ Minh Quý", CustomerCard="", CustomerMember="", CustomerGroup="", CustomerBirthday = new DateTime (1999, 10 , 20), CustomerCompany = "BKAV", CustomerTax = "012345", CustomerMoney = 100000, CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com", CustomerNote=""}
        };

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
        public Guid CustomerId { get; set; }

        // Mã khách hàng
        public string CustomerCode { get; set; }

        // Tên khách hàng
        public string CustomerName { get; set; }

        // Hạng thẻ
        public string CustomerCard { get; set; }

        // Mã thẻ thành viên
        public string CustomerMember { get; set; }

        // Nhóm khách hàng
        public string CustomerGroup { get; set; }

        // Tiền Thuế khách hàng
        public double CustomerMoney { get; set; }

        // Ngày Sinh khách hàng
        public DateTime? CustomerBirthday { get; set; }

        // Công Ty khách hàng
        public string CustomerCompany { get; set; }

        // Mã Số Thuế khách hàng
        public string CustomerTax { get; set; }

        // Địa Chỉ khách hàng
        public string CustomerAddress { get; set; }

        // SĐT khách hàng
        public string CustomerMobile { get; set; }

        // Email khách hàng
        public string CustomerEmail { get; set; }

        // Ghi chú
        public string CustomerNote { get; set; }
    }
}
