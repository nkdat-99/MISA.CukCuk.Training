using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Models
{
    /// <summary>
    /// Dữ liệu giới tính nhân viên
    /// </summary>
    /// <returns></returns>
    /// CreatedBy: NKDAT (16/10/2020)
    public enum GenderEnum
    {
        Female = 0,
        Male = 1,
        Other = 2
    }

    /// <summary>
    /// Dữ liệu loại thẻ thành viên
    /// </summary>
    /// <returns></returns>
    /// CreatedBy: NKDAT (16/10/2020)
    public enum TypeEnum
    {
        Normal = 0,
        Platinum = 1,
        Diamond = 2,
        Vip = 3
    }

    /// <summary>
    /// Dữ liệu trạng thái làm việc
    /// </summary>
    /// <returns></returns>
    /// CreatedBy: NKDAT (16/10/2020)
    public enum StatusEnum
    {
        Working = 0,
        Intern = 1,
        Quit = 2
    }
}
