using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MISA.CukCuk.Training.DatabaseAccess
{
    public class DatabaseSqlServerAccess : IDatabaseAccess<Employee>
    {
        readonly string _connectionString = "Data Source=35.194.166.58;Initial Catalog=MISACukCuk_F09_NKDAT;User ID=sa;Password=12345678@Abc";
        SqlConnection _sqlConnection;
        SqlCommand _sqlCommand;
        public DatabaseSqlServerAccess()
        {
            // Lấy dữ liệu từ Database
            // Khởi tạo kết nối
            _sqlConnection = new SqlConnection(_connectionString);
            // Mở kết nối
            _sqlConnection.Open();
            // Đối tượng xử lý command
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = CommandType.StoredProcedure;
        }
        public int Delete(Guid id)
        {
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_DeleteEmployee";
            // Gán giá trị đầu vào cho các tham số trong store:
            _sqlCommand.Parameters.AddWithValue("@EmployeeIdInput", id);
            //Thực thi công việc
            var result = _sqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            return result;
        }

        public Employee GetById(Guid employeeId)
        {
            var employee = new Employee();
            _sqlCommand.CommandText = "Proc_GetEmployeeById";
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
            try
            {
                // Thực hiện đọc dữ liệu
                SqlDataReader SqlDataReader = _sqlCommand.ExecuteReader();
                while (SqlDataReader.Read())
                {
                    for (int i = 0; i < SqlDataReader.FieldCount; i++)
                    {
                        var columnName = SqlDataReader.GetName(i);
                        var value = SqlDataReader.GetValue(i);
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

        public IEnumerable<Employee> Get()
        {
            var employees = new List<Employee>();
            _sqlCommand.CommandText = "Proc_GetEmployees";
            try
            {
                // Thực hiện đọc dữ liệu
                SqlDataReader SqlDataReader = _sqlCommand.ExecuteReader();
                while (SqlDataReader.Read())
                {
                    var employee = new Employee();
                    for (int i = 0; i < SqlDataReader.FieldCount; i++)
                    {
                        var columnName = SqlDataReader.GetName(i);
                        var value = SqlDataReader.GetValue(i);
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

        public int Insert(Employee employee)
        {
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_InsertEmployee";
            // Gán giá trị đầu vào cho các tham số trong store:
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", Guid.NewGuid());
            _sqlCommand.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
            _sqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            _sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            _sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
            _sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            _sqlCommand.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            _sqlCommand.Parameters.AddWithValue("@DayOfBirth", employee.DayOfBirth);
            _sqlCommand.Parameters.AddWithValue("@PositionId", employee.PositionId);
            _sqlCommand.Parameters.AddWithValue("@Company", employee.Company);
            _sqlCommand.Parameters.AddWithValue("@BankCard", employee.BankCard);
            _sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            _sqlCommand.Parameters.AddWithValue("@Address", employee.Address);
            _sqlCommand.Parameters.AddWithValue("@Note", employee.Note);
            _sqlCommand.Parameters.AddWithValue("@CreateBy", "nkdat");

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
            _sqlCommand.Parameters.AddWithValue("@EmployeeIdInput", employee.EmployeeId);
            _sqlCommand.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
            _sqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            _sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            _sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
            _sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            _sqlCommand.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            _sqlCommand.Parameters.AddWithValue("@DayOfBirth", employee.DayOfBirth);
            _sqlCommand.Parameters.AddWithValue("@PositionId", employee.PositionId);
            _sqlCommand.Parameters.AddWithValue("@Company", employee.Company);
            _sqlCommand.Parameters.AddWithValue("@BankCard", employee.BankCard);
            _sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            _sqlCommand.Parameters.AddWithValue("@Address", employee.Address);
            _sqlCommand.Parameters.AddWithValue("@Note", employee.Note);
            _sqlCommand.Parameters.AddWithValue("@ModifyBy", "nkdat");

            //Thực thi công việc
            var result = _sqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            return result;
        }

        public IEnumerable<Employee> Get(string storeName)
        {
            throw new NotImplementedException();
        }

        public object Get(string storeName, string code)
        {
            throw new NotImplementedException();
        }

        object IDatabaseAccess<Employee>.Get(string storeName, string code)
        {
            throw new NotImplementedException();
        }
    }
}
