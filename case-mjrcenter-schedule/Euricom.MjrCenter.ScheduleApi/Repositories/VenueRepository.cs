using System;
using Euricom.MjrCenter.ScheduleApi.Model;
using Euricom.MjrCenter.ScheduleApi.Utilities.Repositories;

namespace Euricom.MjrCenter.ScheduleApi.Repositories
{
    public class VenueRepository : BaseRepository<MjrContext, Venue>, IVenueRepository
    {
        public VenueRepository(MjrContext context) : base(context)
        { }
    }
}
