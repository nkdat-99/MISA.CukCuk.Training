using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.DatabaseAccess
{
    public class DatabaseMariaDBAccess : IDisposable, IDatabaseAccess
    {
        readonly string _connectionString = "server=35.194.166.58;port=3306;database=MISACukCuk_F09_NKDAT;user=nvmanh;password=12345678@Abc;CharSet=utf8";
        MySqlConnection _sqlConnection;
        MySqlCommand _sqlCommand;
        public DatabaseMariaDBAccess()
        {
            // Lấy dữ liệu từ Database
            // Khởi tạo kết nối
            _sqlConnection = new MySqlConnection(_connectionString);
            // Mở kết nối
            _sqlConnection.Open();
            // Đối tượng xử lý command
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = CommandType.StoredProcedure;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            _sqlCommand.CommandText = "Proc_GetEmployees";
            try
            {
                // Thực hiện đọc dữ liệu
                MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            // Đóng kết nối
            return employees;
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            var employee = new Employee();
            _sqlCommand.CommandText = "Proc_GetEmployeeById";
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
            try
            {
                // Thực hiện đọc dữ liệu
                MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var columnName = mySqlDataReader.GetName(i);
                        var value = mySqlDataReader.GetValue(i);
                        var propertyInfo = employee.GetType().GetProperty(columnName);
                        if (propertyInfo != null && value != DBNull.Value)
                            propertyInfo.SetValue(employee, value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            // Đóng kết nối
            return employee;
        }

        public int Insert(Employee employee)
        {
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_InsertEmployee";
            // Gán giá trị đầu vào cho các tham số trong store:
            _sqlCommand.Parameters.AddWithValue("EmployeeId", Guid.NewGuid());
            _sqlCommand.Parameters.AddWithValue("EmployeeCode", employee.EmployeeCode);
            _sqlCommand.Parameters.AddWithValue("EmployeeName", employee.EmployeeName);
            _sqlCommand.Parameters.AddWithValue("Salary", employee.Salary);
            _sqlCommand.Parameters.AddWithValue("Gender", employee.Gender);
            _sqlCommand.Parameters.AddWithValue("PhoneNumber", employee.PhoneNumber);
            _sqlCommand.Parameters.AddWithValue("DepartmentId", employee.DepartmentId);
            _sqlCommand.Parameters.AddWithValue("DayOfBirth", employee.DayOfBirth);
            _sqlCommand.Parameters.AddWithValue("PositionId", employee.PositionId);
            _sqlCommand.Parameters.AddWithValue("Company", employee.Company);
            _sqlCommand.Parameters.AddWithValue("BankCard", employee.BankCard);
            _sqlCommand.Parameters.AddWithValue("Email", employee.Email);
            _sqlCommand.Parameters.AddWithValue("Address", employee.Address);
            _sqlCommand.Parameters.AddWithValue("Note", employee.Note);
            _sqlCommand.Parameters.AddWithValue("CreateBy", "nkdat");

            //Thực thi công việc
            var result = _sqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            return result;
        }

        public int Update(Employee employee)
        {
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_UpdateEmployee";
            // Gán giá trị đầu vào cho các tham số trong store:
            _sqlCommand.Parameters.AddWithValue("EmployeeIdInput", employee.EmployeeId);
            _sqlCommand.Parameters.AddWithValue("EmployeeCode", employee.EmployeeCode);
            _sqlCommand.Parameters.AddWithValue("EmployeeName", employee.EmployeeName);
            _sqlCommand.Parameters.AddWithValue("Salary", employee.Salary);
            _sqlCommand.Parameters.AddWithValue("Gender", employee.Gender);
            _sqlCommand.Parameters.AddWithValue("PhoneNumber", employee.PhoneNumber);
            _sqlCommand.Parameters.AddWithValue("DepartmentId", employee.DepartmentId);
            _sqlCommand.Parameters.AddWithValue("DayOfBirth", employee.DayOfBirth);
            _sqlCommand.Parameters.AddWithValue("PositionId", employee.PositionId);
            _sqlCommand.Parameters.AddWithValue("Company", employee.Company);
            _sqlCommand.Parameters.AddWithValue("BankCard", employee.BankCard);
            _sqlCommand.Parameters.AddWithValue("Email", employee.Email);
            _sqlCommand.Parameters.AddWithValue("Address", employee.Address);
            _sqlCommand.Parameters.AddWithValue("Note", employee.Note);
            _sqlCommand.Parameters.AddWithValue("ModifyBy", "nkdat");

            //Thực thi công việc
            var result = _sqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            return result;
        }

        public int Delete(Guid employeeId)
        {
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_DeleteEmployee";
            // Gán giá trị đầu vào cho các tham số trong store:
            _sqlCommand.Parameters.AddWithValue("EmployeeIdInput", employeeId);
            //Thực thi công việc
            var result = _sqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            return result;
        }

        public void Dispose()
        {
            _sqlConnection.Close();
        }
    }
}
