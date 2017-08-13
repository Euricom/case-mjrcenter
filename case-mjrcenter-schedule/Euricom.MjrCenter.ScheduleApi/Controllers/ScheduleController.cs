using System.Collections.Generic;
using Euricom.MjrCenter.ScheduleApi.BusinessComponents;
using Euricom.MjrCenter.ScheduleApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.ScheduleApi.Controllers
{
    [Route("api/[controller]")]
//    [Authorize()]
    public class ScheduleController : Controller
    {
        private readonly IScheduleBusinessComponent _scheduleBusinessComponent;

        public ScheduleController(IScheduleBusinessComponent scheduleBusinessComponent)
        {
            _scheduleBusinessComponent = scheduleBusinessComponent;
        }
        /// <summary>
        /// Get all Venues.
        /// </summary>
        /// <returns>Schedule list.</returns>
        ///  <response code="200">Schedule List.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IList<Schedule>), 200)]
        public Task<IList<Schedule>> GetAll()
        {
            return _scheduleBusinessComponent.GetAll();
        }

        /// <summary>
        /// Get a Schedule by Id.
        /// </summary>
        /// <param name="id">Schedule Id.</param>
        /// <returns>Schedule.</returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(Schedule), 200)]
        public Task<Schedule> Get(long id)
        {
            return _scheduleBusinessComponent.GetById(id);
        }

        /// <summary>
        /// Create a new Schedule.
        /// </summary>
        /// <param name="schedule">New Schedule.</param>
        /// <response code="200">Schedule created.</response>
        /// <response code="400">Schedule empty or Id defined.</response> 
        /// <returns>Schedule.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Schedule), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<ActionResult> Post([FromBody]Schedule schedule)
        {
            if(schedule?.Id != 0) return new StatusCodeResult(400);
            return Json(await _scheduleBusinessComponent.Create(schedule));
        }

        /// <summary>
        /// Update a Schedule.
        /// </summary>
        /// <param name="id">Schedule Id.</param>
        /// <param name="schedule">Updated Schedule.</param>
        /// <returns></returns>
        /// <response code="204">Update success.</response>
        /// <response code="404">Update failed.</response>
        [HttpPut("{id:long}")]
        public async Task<ActionResult> Put(long id, [FromBody]Schedule schedule)
        {
            if(id != schedule?.Id) return new StatusCodeResult(400);
            return await _scheduleBusinessComponent.Update(schedule) ?
                new StatusCodeResult(204) : new StatusCodeResult(404); 
        }

        /// <summary>
        /// Delete a Schedule.
        /// </summary>
        /// <param name="id">Schedule Id.</param>
        /// <returns></returns>
        /// <response code="204">Customer deleted.</response>
        /// <response code="404">Delete failed.</response>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Delete(long id)
        {
            return await _scheduleBusinessComponent.DeleteById(id) ?
                new StatusCodeResult(204) : new StatusCodeResult(404); 
        }
    }
}
