using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Euricom.MjrCenter.RegistrationApi.Model;
using Euricom.MjrCenter.RegistrationApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.RegistrationApi.BusinessComponents
{
    public class RegistrationBusinessComponent : IRegistrationBusinessComponent
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationBusinessComponent(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<Registration> Create(Registration registration)
        {
            await _registrationRepository.Add(registration);
            await _registrationRepository.Commit();
            return registration;

        }

        public async Task<bool> DeleteById(long id)
        {
            var registration = await GetById(id);
            if (registration == null) return false;
            await _registrationRepository.Remove(registration);
            await _registrationRepository.Commit();
            return true;
        }

        public async Task<IList<Registration>> GetAll()
        {
            return await _registrationRepository.All.ToListAsync();
        }

        public Task<Registration> GetById(long id)
        {
            return _registrationRepository.All
                 .Include(r => r.Persons)
                 .Include(r=>r.Payments)
                 //.Include(r => r.Schedule)
                 .Include(r => r.VoucherCodes)
                 .SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> Update(Registration registration)
        {
            var dbRegistration = await GetById(registration.Id);
            if (dbRegistration == null) return false;

            dbRegistration.VoucherCodes = registration.VoucherCodes;
            dbRegistration.AmountPayable = registration.AmountPayable;
            dbRegistration.Comments = registration.Comments;
            dbRegistration.Payments = registration.Payments;
            dbRegistration.Persons = registration.Persons;
            dbRegistration.Status = registration.Status;
            dbRegistration.ScheduleId = registration.ScheduleId;

            await _registrationRepository.Commit();
            return true;
        }
    }
}
