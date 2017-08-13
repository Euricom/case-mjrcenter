using System.Collections.Generic;
using Euricom.MjrCenter.RegistrationApi.BusinessComponents;
using Euricom.MjrCenter.RegistrationApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.RegistrationApi.Controllers
{
    [Route("api/[Controller]")]
    //    [Authorize()]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationBusinessComponent _registrationBusinessComponent;

        public RegistrationController(IRegistrationBusinessComponent registrationBusinessComponent)
        {
            _registrationBusinessComponent = registrationBusinessComponent;
        }

        /// <summary>
        /// Get all Registrations.
        /// </summary>
        /// <returns>Registration list.</returns>
        ///  <response code="200">Registration List.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IList<Registration>), 200)]
        public Task<IList<Registration>> GetAll()
        {
            return _registrationBusinessComponent.GetAll();
        }

        /// <summary>
        /// Get a Registration by Id.
        /// </summary>
        /// <param name="id">Registration Id.</param>
        /// <returns>Registration.</returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(Registration), 200)]
        public Task<Registration> Get(long id)
        {
            return _registrationBusinessComponent.GetById(id);
        }

        /// <summary>
        /// Create a new Registration.
        /// </summary>
        /// <param name="registration">New registration.</param>
        /// <response code="200">Registration created.</response>
        /// <response code="400">Registration empty or Id defined.</response> 
        /// <returns>Registration.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Registration), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<ActionResult> Post([FromBody]Registration registration)
        {
            if (registration?.Id != 0) return new StatusCodeResult(400);
            return Json(await _registrationBusinessComponent.Create(registration));
        }

        /// <summary>
        /// Update a Registration.
        /// </summary>
        /// <param name="id">Registration Id.</param>
        /// <param name="registration">Updated Registration.</param>
        /// <returns></returns>
        /// <response code="204">Update success.</response>
        /// <response code="404">Update failed.</response>
        [HttpPut("{id:long}")]
        public async Task<ActionResult> Put(long id, [FromBody]Registration registration)
        {
            if (id != registration?.Id) return new StatusCodeResult(400);
            return await _registrationBusinessComponent.Update(registration) ?
                new StatusCodeResult(204) : new StatusCodeResult(404);
        }

        /// <summary>
        /// Delete a Registration.
        /// </summary>
        /// <param name="id">Registration Id.</param>
        /// <returns></returns>
        /// <response code="204">Registration deleted.</response>
        /// <response code="404">Delete failed.</response>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Delete(long id)
        {
            return await _registrationBusinessComponent.DeleteById(id) ?
                new StatusCodeResult(204) : new StatusCodeResult(404);
        }

    }
}
