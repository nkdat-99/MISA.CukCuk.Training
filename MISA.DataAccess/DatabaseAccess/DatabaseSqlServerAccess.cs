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
        #region DECLARE
        /// <summary>
        /// Khởi tạo kết nối với SQL Server
        /// Mở kết nối
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NKDAT (19/10/2020)
        readonly string _connectionString = "Data Source=35.194.166.58;Initial Catalog=MISACukCuk_F09_NKDAT;User ID=sa;Password=12345678@Abc";
        SqlConnection _sqlConnection;
        SqlCommand _sqlCommand;
        public DatabaseSqlServerAccess()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = CommandType.StoredProcedure;
        }
        #endregion

        #region METHOD
        public int Delete(object id)
        {
            throw new NotImplementedException();
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

        public object Get(string storeName, string code, object id)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(object id)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public int Insert(Employee obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
