using MISA.Bussiness.Interfaces;
using MISA.CukCuk.Training.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool CheckCustomerByCode(string employeeCode)
        {
            return _customerRepository.CheckCustomerByCode(employeeCode);
        }

        protected override bool Validate(Customer entity)
        {
            var isValid = true;
            // Check trùng mã:
            var isValidExitsCode = CheckCustomerByCode(entity.CustomerCode);
            if (isValidExitsCode)
            {
                isValid = false;
                validateErrorResponseMsg.Add("Mã bị trùng");
            }

            return isValid;
        }
    }
}
