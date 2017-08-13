using System;
using Euricom.MjrCenter.ScheduleApi.Model;
using Euricom.MjrCenter.ScheduleApi.Utilities.Repositories;

namespace Euricom.MjrCenter.ScheduleApi.Repositories
{
    public class ScheduleRepository : BaseRepository<MjrContext, Schedule>, IScheduleRepository
    {
        public ScheduleRepository(MjrContext context) : base(context)
        { }
    }
}
