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
        

        public Employee GetById(object employeeId)
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
            return employee;
        }

        public IEnumerable<Employee> Get(string page, string size)
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
            return employees;
        }

        public int Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }

        object IDatabaseAccess<Employee>.Get(string storeName, string code, object id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _sqlConnection.Close();
        }

        public IEnumerable<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get(int page, int name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get(string storeName)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }
    }
}
