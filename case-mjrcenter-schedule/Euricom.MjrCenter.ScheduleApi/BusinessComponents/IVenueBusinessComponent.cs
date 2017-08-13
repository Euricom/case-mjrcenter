using System.Collections.Generic;
using System.Threading.Tasks;
using Euricom.MjrCenter.ScheduleApi.Model;

namespace Euricom.MjrCenter.ScheduleApi.BusinessComponents
{
    public interface IVenueBusinessComponent
    {
        Task<IList<Venue>> GetAll();
        Task<Venue> GetById(long id);
        Task<bool> Update(Venue venue);
        Task<Venue> Create(Venue venue);
        Task<bool> DeleteById(long id);
    }
}