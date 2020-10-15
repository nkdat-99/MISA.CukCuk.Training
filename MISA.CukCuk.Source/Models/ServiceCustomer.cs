using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Training.Models
{
    public class ServiceCustomer
    {
        readonly string _connectionString = "server=35.194.166.58;port=3306;database=MISACukCuk_F09_NKDAT;user=nvmanh;password=12345678@Abc;CharSet=utf8";
        MySqlConnection _sqlConnection;
        MySqlCommand _sqlCommand;
        public ServiceCustomer()
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

        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_GetCustomers";
            // Thực hiện đọc dữ liệu
            try
            {
                MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    var customer = new Customer();
                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var columnName = mySqlDataReader.GetName(i);
                        var value = mySqlDataReader.GetValue(i);
                        var propertyInfo = customer.GetType().GetProperty(columnName);
                        if (propertyInfo != null && value != DBNull.Value)
                            propertyInfo.SetValue(customer, value);
                    }
                    customers.Add(customer);

                }
                // Đóng kết nối
                _sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return customers;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_GetCustomerById";
            _sqlCommand.Parameters.AddWithValue("@CustomerId", customerId);
            // Thực hiện đọc dữ liệu
            var customer = new Customer();
            try
            {
                MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var columnName = mySqlDataReader.GetName(i);
                        var value = mySqlDataReader.GetValue(i);
                        var propertyInfo = customer.GetType().GetProperty(columnName);
                        if (propertyInfo != null && value != DBNull.Value)
                            propertyInfo.SetValue(customer, value);
                    }

                }
                // Đóng kết nối
                _sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return customer;
        }

        public int PostCustomers(Customer customer)
        {
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_InsertCustomer";
            // Gán giá trị đầu vào cho các tham số trong store:
            _sqlCommand.Parameters.AddWithValue("CustomerId", Guid.NewGuid());
            _sqlCommand.Parameters.AddWithValue("CustomerCode", customer.CustomerCode);
            _sqlCommand.Parameters.AddWithValue("CustomerName", customer.CustomerName);
            _sqlCommand.Parameters.AddWithValue("MemberCard", customer.MemberCard);
            _sqlCommand.Parameters.AddWithValue("Type", customer.Type);
            _sqlCommand.Parameters.AddWithValue("CustomerGroupId", customer.CustomerGroupId);
            _sqlCommand.Parameters.AddWithValue("DayOfBirth", customer.DayOfBirth);
            _sqlCommand.Parameters.AddWithValue("PhoneNumber", customer.PhoneNumber);
            _sqlCommand.Parameters.AddWithValue("Company", customer.Company);
            _sqlCommand.Parameters.AddWithValue("CustomerTax", customer.CustomerTax);
            _sqlCommand.Parameters.AddWithValue("MoneyTax", customer.MoneyTax);
            _sqlCommand.Parameters.AddWithValue("Email", customer.Email);
            _sqlCommand.Parameters.AddWithValue("Address", customer.Address);
            _sqlCommand.Parameters.AddWithValue("Note", customer.Note);
            _sqlCommand.Parameters.AddWithValue("CreateBy", "nkdat");
            //Thực thi công việc
            var result = _sqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            _sqlConnection.Close();
            return result;
        }

        public int PutCustomers(Customer customer)
        {
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_UpdateCustomer";
            // Gán giá trị đầu vào cho các tham số trong store:
            _sqlCommand.Parameters.AddWithValue("CustomerId", customer.CustomerId);
            _sqlCommand.Parameters.AddWithValue("CustomerCode", customer.CustomerCode);
            _sqlCommand.Parameters.AddWithValue("CustomerName", customer.CustomerName);
            _sqlCommand.Parameters.AddWithValue("MemberCard", customer.MemberCard);
            _sqlCommand.Parameters.AddWithValue("Type", customer.Type);
            _sqlCommand.Parameters.AddWithValue("CustomerGroupId", customer.CustomerGroupId);
            _sqlCommand.Parameters.AddWithValue("DayOfBirth", customer.DayOfBirth);
            _sqlCommand.Parameters.AddWithValue("PhoneNumber", customer.PhoneNumber);
            _sqlCommand.Parameters.AddWithValue("Company", customer.Company);
            _sqlCommand.Parameters.AddWithValue("CustomerTax", customer.CustomerTax);
            _sqlCommand.Parameters.AddWithValue("MoneyTax", customer.MoneyTax);
            _sqlCommand.Parameters.AddWithValue("Email", customer.Email);
            _sqlCommand.Parameters.AddWithValue("Address", customer.Address);
            _sqlCommand.Parameters.AddWithValue("Note", customer.Note);
            _sqlCommand.Parameters.AddWithValue("ModifyBy", "nkdat");
            //Thực thi công việc
            var result = _sqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            _sqlConnection.Close();
            return result;
        }

        public int DeleteCustomers(Guid customerId)
        {
            // Khai báo câu truy vấn
            _sqlCommand.CommandText = "Proc_DeleteCustomer";
            // Gán giá trị đầu vào cho các tham số trong store:
            _sqlCommand.Parameters.AddWithValue("CustomerIdInput", customerId);
            //Thực thi công việc
            var result = _sqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            _sqlConnection.Close();
            return result;
        }
    }
}
