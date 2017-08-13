using Euricom.MjrCenter.ScheduleApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.ScheduleApi.BusinessComponents
{
    public interface ISpeakerBusinessComponent
    {
        Task<IList<Speaker>> GetAll();
        Task<Speaker> GetById(long id);
        Task<bool> Update(Speaker speaker);
        Task<Speaker> Create(Speaker speaker);
        Task<bool> DeleteById(long id);
    }
}
