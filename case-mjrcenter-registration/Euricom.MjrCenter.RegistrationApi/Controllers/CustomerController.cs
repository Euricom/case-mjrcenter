using Euricom.MjrCenter.RegistrationApi.BusinessComponents;
using Euricom.MjrCenter.RegistrationApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.RegistrationApi.Controllers
{
    [Route("api/[Controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerBusinessComponent _customerBusinessComponent;

        public CustomerController(ICustomerBusinessComponent customerBusinessComponent)
        {
            _customerBusinessComponent = customerBusinessComponent;
        }

        /// <summary>
        /// Get all Customers.
        /// </summary>
        /// <param name="pageIndex">Optional (default 1).</param>
        /// <param name="pageSize">Optional (default 100; max 1000).</param>
        /// <response code="200">Customer list returned.</response>
        /// <returns>Customer List.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<Customer>), 200)]
        public Task<IList<Customer>> GetAll([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 100)
        {
            return _customerBusinessComponent.GetAll(pageIndex, pageSize);
        }

        /// <summary>
        /// Get a Customer by Id
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <param name="includeDeleted">Allow selection of deleted customers</param>
        /// <returns>Customer.</returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(Customer), 200)]
        public Task<Customer> Get(long id, [FromQuery] bool includeDeleted = false)
        {
            return _customerBusinessComponent.GetById(id, includeDeleted);
        }

        /// <summary>
        /// Create a new Customer.
        /// </summary>
        /// <param name="customer">new customer</param>
        /// <response code="200">Customer created.</response>
        /// <response code="400">Customer empty or Id defined.</response>
        /// <returns>Customer.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Customer),200)]
        [ProducesResponseType(typeof(void),400)]
        public async Task<ActionResult> Post([FromBody]Customer customer)
        {
            if (customer?.Id != 0) return new StatusCodeResult(400);
            return Json(await _customerBusinessComponent.Create(customer));
        }

        /// <summary>
        /// Update a Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <param name="customer">Updated Customer.</param>
        /// <param name="includeDeleted">Allow operations on deleted Customers (default: false).</param>
        /// <returns></returns>
        /// <response code="204">Update success.</response>
        /// <response code="404">Update failed.</response>
        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(void),204)]
        [ProducesResponseType(typeof(void),404)]
        public async Task<ActionResult> Put(long id, [FromBody]Customer customer, [FromQuery] bool includeDeleted = false)
        {
            if (id != customer?.Id) return new StatusCodeResult(400);
            return await _customerBusinessComponent.Update(customer, includeDeleted) ?
                new StatusCodeResult(204) : new StatusCodeResult(404);
        }

        /// <summary>
        /// Delete a customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <param name="delete">Set deleted status of Customer (default: true).</param>
        /// <returns></returns>
        /// <response code="204">Customer deleted.</response>
        /// <response code="404">Delete failed.</response>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Delete(long id, [FromQuery] bool delete = true)
        {
            return await _customerBusinessComponent.SoftDeleteById(id, delete) ?
                new StatusCodeResult(204) : new StatusCodeResult(404);
        }
    }
}
