using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Models
{
    public class Customer
    {
        public static List<Customer> CustomerList = new List<Customer>() {
            new Customer(){CustomerCode = "KH0001", CustomerName = "Lại Thị Huyền", CustomerCompany = "BKAV", CustomerTax = "012345", CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com"},
            new Customer(){CustomerCode = "KH0002", CustomerName = "Nguyễn Kim Đạt", CustomerCompany = "BKAV", CustomerTax = "012345", CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com"},
            new Customer(){CustomerCode = "KH0003", CustomerName = "Từ Minh Quý", CustomerCompany = "BKAV", CustomerTax = "012345", CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com"},
            new Customer(){CustomerCode = "KH0004", CustomerName = "Lại Thị Huyền", CustomerCompany = "BKAV", CustomerTax = "012345", CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com"},
            new Customer(){CustomerCode = "KH0005", CustomerName = "Nguyễn Kim Đạt", CustomerCompany = "BKAV", CustomerTax = "012345", CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com"},
            new Customer(){CustomerCode = "KH0006", CustomerName = "Từ Minh Quý", CustomerCompany = "BKAV", CustomerTax = "012345", CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com"},
            new Customer(){CustomerCode = "KH0007", CustomerName = "Lại Thị Huyền", CustomerCompany = "BKAV", CustomerTax = "012345", CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com"},
            new Customer(){CustomerCode = "KH0008", CustomerName = "Nguyễn Kim Đạt", CustomerCompany = "BKAV", CustomerTax = "012345", CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com"},
            new Customer(){CustomerCode = "KH0009", CustomerName = "Từ Minh Quý", CustomerCompany = "BKAV", CustomerTax = "012345", CustomerAddress = "Hà Đông, Hà Nội", CustomerMobile = "0359434106", CustomerEmail = "huyenlai99@gmail.com"}
        };

        // Mã khách hàng
        public string CustomerCode { get; set; }

        // Tên khách hàng
        public string CustomerName { get; set; }

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
    }
}
