using System;
using Euricom.MjrCenter.ScheduleApi.Model;
using Euricom.MjrCenter.ScheduleApi.Utilities.Repositories;

namespace Euricom.MjrCenter.ScheduleApi.Repositories
{
    public class SpeakerRepository : BaseRepository<MjrContext, Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(MjrContext context) : base(context)
        {
        }
    }
}
