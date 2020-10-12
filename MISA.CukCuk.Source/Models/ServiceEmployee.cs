using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Models
{
    public class ServiceEmployee
    {
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            // Lấy dữ liệu từ Database
            // Khởi tạo thông tin kết nối
            string conectionString = "server=35.194.166.58;port=3306;database=MISACukCuk_F09_NKDAT;user=nvmanh;password=12345678@Abc;CharSet=utf8";
            // Khởi tạo kết nối
            MySqlConnection mySqlConnection = new MySqlConnection(conectionString);
            // Mở kết nối
            mySqlConnection.Open();
            // Đối tượng xử lý command
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            mySqlCommand.CommandText = "Proc_GetEmployees";
            mySqlCommand.ExecuteNonQuery();
            // Thực hiện đọc dữ liệu
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var employee = new Employee();
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = employee.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(employee, value);
                }
                employees.Add(employee);

            }
            // Đóng kết nối
            mySqlConnection.Close();
            return employees;
        }
    }
}
