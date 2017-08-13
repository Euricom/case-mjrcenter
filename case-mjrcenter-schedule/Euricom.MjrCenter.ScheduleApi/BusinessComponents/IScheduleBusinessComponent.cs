using Euricom.MjrCenter.ScheduleApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.ScheduleApi.BusinessComponents
{
    public interface IScheduleBusinessComponent
    {
        Task<IList<Schedule>> GetAll();
        Task<Schedule> GetById(long id);
        Task<bool> Update(Schedule schedule);
        Task<Schedule> Create(Schedule venue);
        Task<bool> DeleteById(long id);
    }
}
