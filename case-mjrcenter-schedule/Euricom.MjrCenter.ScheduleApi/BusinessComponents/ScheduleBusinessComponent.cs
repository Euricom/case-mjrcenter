using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Euricom.MjrCenter.ScheduleApi.Model;
using Euricom.MjrCenter.ScheduleApi.Utilities.RandomCodeGenerator;
using Euricom.MjrCenter.ScheduleApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.ScheduleApi.BusinessComponents
{
    public class ScheduleBusinessComponent : IScheduleBusinessComponent
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleBusinessComponent(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Schedule> Create(Schedule schedule)
        {
            await _scheduleRepository.Add(schedule);
            await _scheduleRepository.Commit();
            return schedule;
        }

        public async Task<bool> DeleteById(long id)
        {
            var voucherCode = await GetById(id);
            if (voucherCode == null) return false;
            await _scheduleRepository.Remove(voucherCode);
            await _scheduleRepository.Commit();
            return true;
        }

        public async Task<IList<Schedule>> GetAll()
        {
            return await _scheduleRepository.All.ToListAsync();
        }

        public Task<Schedule> GetById(long id)
        {
            return _scheduleRepository.All
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<bool> Update(Schedule schedule)
        {
            var dbSchedule = await GetById(schedule.Id);
            if (dbSchedule == null) return false;

            await _scheduleRepository.Commit();
            return true;
        }
    }
}
