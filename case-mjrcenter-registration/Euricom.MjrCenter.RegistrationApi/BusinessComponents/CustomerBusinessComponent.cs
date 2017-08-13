using Euricom.MjrCenter.RegistrationApi.Model;
using Euricom.MjrCenter.RegistrationApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.RegistrationApi.BusinessComponents
{
    public class CustomerBusinessComponent : ICustomerBusinessComponent
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessComponent(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Create(Customer customer)
        {
            await _customerRepository.Add(customer);
            await _customerRepository.Commit();
            return customer;
        }

        public async Task<IList<Customer>> GetAll(int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex < 0) pageIndex = 0;
            if (pageSize < 0) pageSize = 100;
            if (pageSize > 1000) pageSize = 1000;

            return await _customerRepository.All
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public Task<Customer> GetById(long Id, bool includeDeleted)
        {
            return _customerRepository.All
                .SingleOrDefaultAsync(c => c.Id == Id && c.IsDeleted == includeDeleted);
        }

        public async Task<bool> SoftDeleteById(long id, bool deleted)
        {
            var dbCustomer = await GetById(id, !deleted);
            if (dbCustomer == null)
                return false;

            dbCustomer.IsDeleted = deleted;
            await _customerRepository.Commit();
            return true;
        }

        public async Task<bool> Update(Customer customer, bool includeDeleted)
        {
            var dbCustomer = await GetById(customer.Id,includeDeleted);
            if (dbCustomer == null)
                return false;

            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.Email = customer.Email;
            dbCustomer.Mobile = customer.Mobile;
            dbCustomer.JobTitle = customer.JobTitle;
            dbCustomer.ContactBy = customer.ContactBy;
            dbCustomer.Interests = customer.Interests;
            dbCustomer.InvoiceCompanyName = customer.InvoiceCompanyName;
            dbCustomer.InvoiceAddress = customer.InvoiceAddress;
            dbCustomer.InvoiceVatOption = customer.InvoiceVatOption;
            dbCustomer.InvoiceEnterpriseNumber = customer.InvoiceEnterpriseNumber;
            await _customerRepository.Commit();
            return true;
        }
    }
}
