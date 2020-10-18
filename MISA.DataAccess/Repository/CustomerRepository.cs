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
    }
}
