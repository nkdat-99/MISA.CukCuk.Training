using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Models
{
    public partial class Customer
    {
        public Guid CustomerId { get; set; }

        // Mã khách hàng
        public string CustomerCode { get; set; }

        // Tên khách hàng
        public string CustomerName { get; set; }

        // Hạng thẻ
        public string MemberCard { get; set; }

        // Mã thẻ thành viên
        public TypeEnum Type { set; get; }
        public string MemberType
        {
            get
            {
                switch (Type)
                {
                    case TypeEnum.Normal:
                        return "Normal";
                    case TypeEnum.Platinum:
                        return "Platinum";
                    case TypeEnum.Diamond:
                        return "Diamond";
                    case TypeEnum.Vip:
                        return "Vip";
                    default:
                        return "Không xác định";
                };
            }
        }

        // Nhóm khách hàng
        public Guid CustomerGroupId { get; set; }

        // Tiền Thuế khách hàng
        public double MoneyTax { get; set; }

        // Ngày Sinh khách hàng
        public DateTime? DayOfBirth { get; set; }

        // Công Ty khách hàng
        public string Company { get; set; }

        // Mã Số Thuế khách hàng
        public string CustomerTax { get; set; }

        // Địa Chỉ khách hàng
        public string Address { get; set; }

        // SĐT khách hàng
        public string PhoneNumber { get; set; }

        // Email khách hàng
        public string Email { get; set; }

        // Ghi chú
        public string Note { get; set; }
    }
}
