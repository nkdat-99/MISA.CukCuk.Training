using MISA.CukCuk.Training.Interface;
using MISA.CukCuk.Training.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseAccess<Customer> databaseAccess) : base(databaseAccess)
        {
        }

        public bool CheckCustomerByCode(string customerCode)
        {
            var objectValue = _databaseAccess.Get("Proc_GetCustomerByCode", customerCode);
            if (objectValue == null)
                return false;
            else
                return true;
        }
    }
}
