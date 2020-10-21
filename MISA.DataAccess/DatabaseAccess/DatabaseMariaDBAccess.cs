using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.CukCuk.Training.DatabaseAccess
{
    public class DatabaseMariaDBAccess<T> : IDisposable, IDatabaseAccess<T>
    {
        #region DECLARE
        /// <summary>
        /// Khởi tạo kết nối với MySQL
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        readonly string _connectionString = "server=35.194.166.58;port=3306;database=MISACukCuk_F09_NKDAT;user=nvmanh;password=12345678@Abc;CharSet=utf8";
        MySqlConnection _sqlConnection;
        #endregion

        #region CONSTRUCTOR-OPEN-CONNECTION
        /// <summary>
        /// Mở kết nối
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        public DatabaseMariaDBAccess()
        {
            _sqlConnection = new MySqlConnection(_connectionString);
            _sqlConnection.Open();
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Lấy tất cả bản ghi từ DATABASE
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
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

        /// <summary>
        /// Lấy số lượng bản ghi DATABASE theo paging
        /// </summary>
        /// <param name="page">Số lượng bản ghi bỏ qua</param>
        /// <param name="size">Số lượng bản ghi lấy về</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        public IEnumerable<T> Get(int page, int size)
        {
            var objectT = new List<T>();
            try
            {
                using (var _sqlCommand = _sqlConnection.CreateCommand())
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    _sqlCommand.Parameters.Clear();
                    var className = typeof(T).Name;
                    _sqlCommand.CommandText = $"Proc_Get{className}ByPageSize";
                    _sqlCommand.Parameters.AddWithValue("@page", page);
                    _sqlCommand.Parameters.AddWithValue("@size", size);
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

        /// <summary>
        /// Lấy thông tin bản ghi trong DATABASE theo mã Id
        /// </summary>
        /// <param name="id">Mã Id nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
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

        /// <summary>
        /// Thêm bản ghi mới vào DATABASE
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
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

        /// <summary>
        /// Sửa bản ghi mới vào DATABASE
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
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

        /// <summary>
        /// Xóa bản ghi từ DATABASE
        /// </summary>
        /// /// <param name="code">Mã Code của nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
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

        /// <summary>
        /// Lấy thông tin bản ghi cuối cùng
        /// </summary>
        /// <param name="storeName">Phương thức Proc</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
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

        /// <summary>
        /// Lấy thông tin mã code để kiểm tra trùng mã
        /// </summary>
        /// <param name="storeName">Số lượng bản ghi bỏ qua</param>
        /// <param name="code">Mã code nhân viên</param>
        /// <param name="id">Mã id nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        public object Get(string storeName, string code, object id)
        {
            var objectT = new List<T>();
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

        /// <summary>
        /// Lấy số lượng tổng số bản ghi DATABASE
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        public int GetCount()
        {
            try
            {
                using (var _sqlCommand = _sqlConnection.CreateCommand())
                {
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    var className = typeof(T).Name;
                    _sqlCommand.CommandText = $"Proc_Count{className}";
                    _sqlCommand.Parameters.Clear();
                    var count = _sqlCommand.ExecuteScalar();
                    int countSearch = Convert.ToInt32(count.ToString());
                    return countSearch;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return 0;
        }
        #endregion

        #region CONSTRUCTOR-CLOSE-CONNECTION
        /// <summary>
        /// Đóng kết nối
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        public void Dispose()
        {
            _sqlConnection.Close();
        }
        #endregion
    }
}
