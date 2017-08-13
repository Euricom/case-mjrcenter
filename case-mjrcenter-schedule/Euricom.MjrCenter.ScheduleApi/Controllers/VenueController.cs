using System.Collections.Generic;
using Euricom.MjrCenter.ScheduleApi.BusinessComponents;
using Euricom.MjrCenter.ScheduleApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.ScheduleApi
{
    [Route("api/[controller]")]
    //    [Authorize()]
    public class VenueController : Controller
    {
        private readonly IVenueBusinessComponent _venueBusinessComponent;

        public VenueController(IVenueBusinessComponent venueBusinessComponent)
        {
            _venueBusinessComponent = venueBusinessComponent;
        }
        /// <summary>
        /// Get all Venues.
        /// </summary>
        /// <returns>Venue list.</returns>
        ///  <response code="200">Venue List.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IList<Venue>), 200)]
        public Task<IList<Venue>> GetAll()
        {
            return _venueBusinessComponent.GetAll();
        }

        /// <summary>
        /// Get a Venue by Id.
        /// </summary>
        /// <param name="id">Venue Id.</param>
        /// <returns>Venue.</returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(Venue), 200)]
        public Task<Venue> Get(long id)
        {
            return _venueBusinessComponent.GetById(id);
        }

        /// <summary>
        /// Create a new Venue.
        /// </summary>
        /// <param name="venue">New Venue.</param>
        /// <response code="200">Venue created.</response>
        /// <response code="400">Venue empty or Id defined.</response> 
        /// <returns>Venue.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Venue), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<ActionResult> Post([FromBody]Venue venue)
        {
            if (venue?.Id != 0) return new StatusCodeResult(400);
            return Json(await _venueBusinessComponent.Create(venue));
        }

        /// <summary>
        /// Update a Venue.
        /// </summary>
        /// <param name="id">Venue Id.</param>
        /// <param name="venue">Updated Venue.</param>
        /// <returns></returns>
        /// <response code="204">Update success.</response>
        /// <response code="404">Update failed.</response>
        [HttpPut("{id:long}")]
        public async Task<ActionResult> Put(long id, [FromBody]Venue venue)
        {
            if (id != venue?.Id) return new StatusCodeResult(400);
            return await _venueBusinessComponent.Update(venue) ?
                new StatusCodeResult(204) : new StatusCodeResult(404);
        }

        /// <summary>
        /// Delete a Venue.
        /// </summary>
        /// <param name="id">Venue Id.</param>
        /// <returns></returns>
        /// <response code="204">Customer deleted.</response>
        /// <response code="404">Delete failed.</response>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Delete(long id)
        {
            return await _venueBusinessComponent.DeleteById(id) ?
                new StatusCodeResult(204) : new StatusCodeResult(404);
        }
    }
}
