using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        IEmployeeRepository _employeeRepository;
        public CustomerService(IEmployeeRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
