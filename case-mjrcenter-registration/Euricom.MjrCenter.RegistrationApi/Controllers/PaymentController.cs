using System.Collections.Generic;
using System.Threading.Tasks;
using Euricom.MjrCenter.RegistrationApi.BusinessComponents;
using Euricom.MjrCenter.RegistrationApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace Euricom.MjrCenter.RegistrationApi.Controllers
{
    [Route("api/[Controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentBusinessComponent _paymentBusinessComponent;

        public PaymentController(IPaymentBusinessComponent paymentBusinessComponent)
        {
            _paymentBusinessComponent = paymentBusinessComponent;
        }

        /// <summary>Get all Payments.</summary>
        /// <returns>Payment list.</returns>
        /// <response code="200">Payment list returned.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IList<Payment>), 200)]
        public Task<IList<Payment>> getAll()
        {
            return _paymentBusinessComponent.GetAll();
        }

        /// <summary>Get a Payment by id.</summary>
        /// <returns>Payment.</returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(Payment), 200)]
        public Task<Payment> Get(long id)
        {
            return _paymentBusinessComponent.GetById(id);
        }

        /// <summary>
        /// Create a new Payment.
        /// </summary>
        /// <param name="payment">New Payment</param>
        /// <response code="200">Payment created.</response>
        /// <response code="400">Payment empty or Id defined.</response>
        /// <returns>Customer.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Payment), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<ActionResult> Post([FromBody] Payment payment)
        {
            if (payment?.Id != 0) return new StatusCodeResult(400);

            return Json(await _paymentBusinessComponent.Create(payment));
        }

        /// <summary>
        /// Update a Payment.
        /// </summary>
        /// <param name="id">Payment Id.</param>
        /// <param name="payment">Updated Payment.</param>
        /// <returns></returns>
        /// <response code="204">Update success.</response>
        /// <response code="404">Update failed.</response>
        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Put(long id, [FromBody] Payment payment)
        {
            if (payment?.Id != id) return new StatusCodeResult(400);

            return await _paymentBusinessComponent.Update(payment) ? new StatusCodeResult(204) : new StatusCodeResult(404);
        }

        /// <summary>
        /// Delete a Payment.
        /// </summary>
        /// <param name="id">Payment Id.</param>
        /// <returns></returns>
        /// <response code="204">Payment deleted.</response>
        /// <response code="404">Delete failed.</response>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Delete(long id)
        {
            return await _paymentBusinessComponent.DeleteById(id) ? new StatusCodeResult(204) : new StatusCodeResult(404);
        }
    }
}
