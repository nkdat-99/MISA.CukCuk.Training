using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.CukCuk.Training.DatabaseAccess
{
    public class DatabaseMariaDBAccess<T> : IDisposable, IDatabaseAccess<T>
    {
        #region DECLARE
        readonly string _connectionString = "server=35.194.166.58;port=3306;database=MISACukCuk_F09_NKDAT;user=nvmanh;password=12345678@Abc;CharSet=utf8";
        MySqlConnection _sqlConnection;
        MySqlCommand _sqlCommand;
        #endregion

        #region CONSTRUCTOR
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
        #endregion

        #region METHOD
        public IEnumerable<T> Get()
        {
            var objectT = new List<T>();
            var className = typeof(T).Name;
            _sqlCommand.CommandText = $"Proc_Get{className}s";
            try
            {
                // Thực hiện đọc dữ liệu
                MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    var obj = Activator.CreateInstance<T>();
                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var columnName = mySqlDataReader.GetName(i);
                        var value = mySqlDataReader.GetValue(i);
                        var propertyInfo = obj.GetType().GetProperty(columnName);
                        if (propertyInfo != null && value != DBNull.Value)
                            propertyInfo.SetValue(obj, value);
                    }
                    objectT.Add(obj);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return objectT;
        }

        public T GetById(Guid id)
        {
            var obj = Activator.CreateInstance<T>();
            _sqlCommand.CommandText = "Proc_GetEmployeeById";
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", id);
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
                        var propertyInfo = obj.GetType().GetProperty(columnName);
                        if (propertyInfo != null && value != DBNull.Value)
                            propertyInfo.SetValue(obj, value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return obj;
        }

        public int Insert(T entity)
        {
            _sqlCommand.Parameters.Clear();
            var employee = entity as Employee;
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
            var result = _sqlCommand.ExecuteNonQuery();
            return result;
        }

        public int Update(T entity)
        {
            _sqlCommand.Parameters.Clear();
            var employee = entity as Employee;
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
            var result = _sqlCommand.ExecuteNonQuery();
            return result;
        }

        public int Delete(Guid objId)
        {
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_DeleteEmployee";
            // Gán giá trị đầu vào cho các tham số trong store:
            _sqlCommand.Parameters.AddWithValue("EmployeeIdInput", objId);
            //Thực thi công việc
            var result = _sqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            return result;
        }

        public void Dispose()
        {
            _sqlConnection.Close();
        }

        public IEnumerable<T> Get(string storeName)
        {
            var entities = new List<T>();
            _sqlCommand.CommandText = storeName;
            // Thực hiện đọc dữ liệu
            MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var entity = Activator.CreateInstance<T>();
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = entity.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(entity, value);
                }
                entities.Add(entity);
            }
            return entities;
        }

        public object Get(string storeName, string code)
        {
            _sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = storeName;
            _sqlCommand.Parameters.AddWithValue("@EmployeeCode", code);
            return _sqlCommand.ExecuteScalar();
        }
        #endregion
    }
}
