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
        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            // Lấy dữ liệu từ Database
            // Khởi tạo thông tin kết nối
            string conectionString = "server=35.194.166.58;port=3306;database=MISACukCuk_F09_NKDAT;user=nvmanh;password=12345678@Abc;CharSet=utf8";
            // Khởi tạo kết nối
            MySqlConnection mySqlConnection = new MySqlConnection(conectionString);
            // Mở kết nối
            // Đối tượng xử lý command
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            // Khai báo câu truy vấn
            mySqlCommand.CommandText = "Proc_GetCustomers";
            // Thực hiện đọc dữ liệu
            try
            {
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
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
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return customers;
        }

        public Customer GetCustomerId(Guid customerId)
        {
            // Lấy dữ liệu từ Database
            // Khởi tạo thông tin kết nối
            string conectionString = "server=35.194.166.58;port=3306;database=MISACukCuk_F09_NKDAT;user=nvmanh;password=12345678@Abc;CharSet=utf8";
            // Khởi tạo kết nối
            MySqlConnection mySqlConnection = new MySqlConnection(conectionString);
            // Mở kết nối
            // Đối tượng xử lý command
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = CommandType.StoredProcedure;
            // Khai báo câu truy vấn
            mySqlCommand.CommandText = "Proc_GetCustomerById";
            mySqlCommand.Parameters.AddWithValue("@CustomerId", customerId);
            // Thực hiện đọc dữ liệu
            var customer = new Customer();
            try
            {
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
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
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return customer;
        }

        public int PostCustomers(Customer customer)
        {
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
            // Khai báo câu truy vấn
            mySqlCommand.CommandText = "Proc_InsertCustomer";
            // Gán giá trị đầu vào cho các tham số trong store:
            mySqlCommand.Parameters.AddWithValue("CustomerId", Guid.NewGuid());
            mySqlCommand.Parameters.AddWithValue("CustomerCode", customer.CustomerCode);
            mySqlCommand.Parameters.AddWithValue("CustomerName", customer.CustomerName);
            mySqlCommand.Parameters.AddWithValue("MemberCard", customer.MemberCard);
            mySqlCommand.Parameters.AddWithValue("Type", customer.Type);
            mySqlCommand.Parameters.AddWithValue("CustomerGroupId", customer.CustomerGroupId);
            mySqlCommand.Parameters.AddWithValue("DayOfBirth", customer.DayOfBirth);
            mySqlCommand.Parameters.AddWithValue("PhoneNumber", customer.PhoneNumber);
            mySqlCommand.Parameters.AddWithValue("Company", customer.Company);
            mySqlCommand.Parameters.AddWithValue("CustomerTax", customer.CustomerTax);
            mySqlCommand.Parameters.AddWithValue("MoneyTax", customer.MoneyTax);
            mySqlCommand.Parameters.AddWithValue("Email", customer.Email);
            mySqlCommand.Parameters.AddWithValue("Address", customer.Address);
            mySqlCommand.Parameters.AddWithValue("Note", customer.Note);
            mySqlCommand.Parameters.AddWithValue("CreateBy", "nkdat");
            //Thực thi công việc
            var result = mySqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            mySqlConnection.Close();
            return result;
        }

        public int PutCustomers(Customer customer)
        {
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
            // Khai báo câu truy vấn
            mySqlCommand.CommandText = "Proc_UpdateCustomer";
            // Gán giá trị đầu vào cho các tham số trong store:
            mySqlCommand.Parameters.AddWithValue("CustomerId", customer.CustomerId);
            mySqlCommand.Parameters.AddWithValue("CustomerCode", customer.CustomerCode);
            mySqlCommand.Parameters.AddWithValue("CustomerName", customer.CustomerName);
            mySqlCommand.Parameters.AddWithValue("MemberCard", customer.MemberCard);
            mySqlCommand.Parameters.AddWithValue("Type", customer.Type);
            mySqlCommand.Parameters.AddWithValue("CustomerGroupId", customer.CustomerGroupId);
            mySqlCommand.Parameters.AddWithValue("DayOfBirth", customer.DayOfBirth);
            mySqlCommand.Parameters.AddWithValue("PhoneNumber", customer.PhoneNumber);
            mySqlCommand.Parameters.AddWithValue("Company", customer.Company);
            mySqlCommand.Parameters.AddWithValue("CustomerTax", customer.CustomerTax);
            mySqlCommand.Parameters.AddWithValue("MoneyTax", customer.MoneyTax);
            mySqlCommand.Parameters.AddWithValue("Email", customer.Email);
            mySqlCommand.Parameters.AddWithValue("Address", customer.Address);
            mySqlCommand.Parameters.AddWithValue("Note", customer.Note);
            mySqlCommand.Parameters.AddWithValue("ModifyBy", "nkdat");
            //Thực thi công việc
            var result = mySqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            mySqlConnection.Close();
            return result;
        }

        public int DeleteCustomers(Guid customerId)
        {
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
            // Khai báo câu truy vấn
            mySqlCommand.CommandText = "Proc_DeleteCustomer";
            // Gán giá trị đầu vào cho các tham số trong store:
            mySqlCommand.Parameters.AddWithValue("CustomerIdInput", customerId);
            //Thực thi công việc
            var result = mySqlCommand.ExecuteNonQuery();
            // Đóng kết nối
            mySqlConnection.Close();
            return result;
        }
    }
}
