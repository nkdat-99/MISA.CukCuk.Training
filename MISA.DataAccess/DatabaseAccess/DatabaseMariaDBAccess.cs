using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace MISA.CukCuk.Training.DatabaseAccess
{
    public class DatabaseMariaDBAccess<T> : IDisposable, IDatabaseAccess<T>
    {
        #region DECLARE
        readonly string _connectionString = "server=35.194.166.58;port=3306;database=MISACukCuk_F09_NKDAT;user=nvmanh;password=12345678@Abc;CharSet=utf8";
        MySqlConnection _sqlConnection;
        //MySqlCommand _sqlCommand;
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
            //_sqlCommand = _sqlConnection.CreateCommand();
            //_sqlCommand.CommandType = CommandType.StoredProcedure;
        }
        #endregion

        #region METHOD
        public IEnumerable<T> Get()
        {
            var objectT = new List<T>();
            try
            {
                using (var _sqlCommand = _sqlConnection.CreateCommand())
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.Parameters.Clear();
                    var className = typeof(T).Name;
                    _sqlCommand.CommandText = $"Proc_Get{className}s";
                    // Thực hiện đọc dữ liệu
                    using (MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader())
                    {
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return objectT;
        }

        public T GetById(object id)
        {
            var obj = Activator.CreateInstance<T>();
            try
            {
                using (var _sqlCommand = _sqlConnection.CreateCommand())
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    var className = typeof(T).Name;

                    _sqlCommand.CommandText = $"Proc_Get{className}ById";
                    _sqlCommand.Parameters.AddWithValue($"@{className}Id", id);
                    // Thực hiện đọc dữ liệu
                    using MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return obj;
        }

        public int Insert(T entity)
        {
            try
            {
                using (var _sqlCommand = _sqlConnection.CreateCommand())
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    var entityName = typeof(T).Name;
                    _sqlCommand.Parameters.Clear();
                    _sqlCommand.CommandText = $"Proc_Insert{entityName}";
                    MySqlCommandBuilder.DeriveParameters(_sqlCommand);
                    var parameters = _sqlCommand.Parameters;
                    foreach (MySqlParameter param in parameters)
                    {
                        var paramName = param.ParameterName.Replace("@", string.Empty);
                        var property = entity.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        if (property != null)
                            param.Value = property.GetValue(entity);
                    }
                    var result = _sqlCommand.ExecuteNonQuery();
                    return result;
                }
            }
            catch
            {
                return 0;
            }
        }

        public int Update(T entity)
        {
            try
            {
                using (var _sqlCommand = _sqlConnection.CreateCommand())
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    var entityName = typeof(T).Name;
                    _sqlCommand.Parameters.Clear();
                    _sqlCommand.CommandText = $"Proc_Update{entityName}";
                    MySqlCommandBuilder.DeriveParameters(_sqlCommand);
                    var parameters = _sqlCommand.Parameters;
                    foreach (MySqlParameter param in parameters)
                    {
                        var paramName = param.ParameterName.Replace("@", string.Empty);
                        var property = entity.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        if (property != null)
                            param.Value = property.GetValue(entity);
                    }
                    var result = _sqlCommand.ExecuteNonQuery();
                    return result;
                }
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(object code)
        {
            try
            {
                using (var _sqlCommand = _sqlConnection.CreateCommand())
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    var className = typeof(T).Name;
                    _sqlCommand.Parameters.Clear();
                    _sqlCommand.CommandText = $"Proc_Delete{className}";
                    _sqlCommand.Parameters.AddWithValue($"@{className}CodeInput", code);
                    MySqlCommandBuilder.DeriveParameters(_sqlCommand);
                    if (_sqlCommand.Parameters.Count > 0)
                    {
                        _sqlCommand.Parameters[0].Value = code;
                    }
                    var result = _sqlCommand.ExecuteNonQuery();
                    return result;
                }
            }
            catch
            {
                return 0;
            }
        }

        public IEnumerable<T> Get(string storeName)
        {
            try
            {
                using (var _sqlCommand = _sqlConnection.CreateCommand())
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
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
            }
            catch
            {
                return null;
            }
        }

        public object Get(string storeName, string code, object id)
        {var objectT = new List<T>();
            try
            {
                using (var _sqlCommand = _sqlConnection.CreateCommand())
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    
                    var className = typeof(T).Name;
                    _sqlCommand.Parameters.Clear();
                    _sqlCommand.CommandText = storeName;
                    _sqlCommand.Parameters.AddWithValue($"@{className}Id", id);
                    _sqlCommand.Parameters.AddWithValue($"@{className}Code", code);
                    // Thực hiện đọc dữ liệu
                    using MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return objectT.FirstOrDefault();
        }

        public void Dispose()
        {
            _sqlConnection.Close();
        }
        #endregion
    }
}
