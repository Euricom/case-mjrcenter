using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Euricom.MjrCenter.ScheduleApi.BusinessComponents;
using Euricom.MjrCenter.ScheduleApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Euricom.MjrCenter.ScheduleApi
{
    [Route("api/[controller]")]
    public class SpeakerController : Controller
    {
        private readonly ISpeakerBusinessComponent _speakerBusinessComponent;

        public SpeakerController(ISpeakerBusinessComponent speakerBusinessComponent)
        {
            _speakerBusinessComponent = speakerBusinessComponent;
        }

        /// <summary>
        /// Get all Speakers
        /// </summary>
        /// <returns>Speaker List.</returns>
        /// <response code="200">Speaker list returned.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IList<Speaker>), 200)]
        public Task<IList<Speaker>> GetAll()
        {
            return _speakerBusinessComponent.GetAll();
        }

        /// <summary>
        /// Get a Speaker by Id.
        /// </summary>
        /// <param name="id">Speaker Id.</param>
        /// <returns>Speaker.</returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(Speaker), 200)]
        public Task<Speaker> Get(long id)
        {
            return _speakerBusinessComponent.GetById(id);
        }

        /// <summary>
        /// Create a new Speaker.
        /// </summary>
        /// <param name="speaker"></param>
        /// <response code="200">Speaker created.</response>
        /// <response code="400">Speaker empty or Id defined.</response>
        /// <returns>Speaker</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Speaker), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<ActionResult> Post([FromBody]Speaker speaker)
        {
            if (speaker?.Id!= 0) return new StatusCodeResult(400);
            return Json(await _speakerBusinessComponent.Create(speaker));
        }

        /// <summary>
        /// Update a Speaker.
        /// </summary>
        /// <param name="id">Speaker Id.</param>
        /// <param name="speaker">Updated Speaker.</param>
        /// <returns></returns>
        /// <response code="204">Update success.</response>
        /// <response code="404">Update failed.</response>
        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Put(long id, [FromBody]Speaker speaker)
        {
            if (id != speaker?.Id) return new StatusCodeResult(400);
            return await _speakerBusinessComponent.Update(speaker) ?
                new StatusCodeResult(204) : new StatusCodeResult(404);
        }

        /// <summary>
        /// Delete a Speaker.
        /// </summary>
        /// <param name="id">Speaker Id.</param>
        /// <returns></returns>
        /// <response code="204">Speaker deleted.</response>
        /// <response code="404">Delete failed.</response>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Delete(long id)
        {
            return await _speakerBusinessComponent.DeleteById(id) ?
                new StatusCodeResult(204) : new StatusCodeResult(404);
        }
    }
}
