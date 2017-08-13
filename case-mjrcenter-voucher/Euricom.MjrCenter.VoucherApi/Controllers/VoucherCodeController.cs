using Euricom.MjrCenter.VoucherApi.BusinessComponents;
using Euricom.MjrCenter.VoucherApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.VoucherApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize()] //TODO only allow admins to use this functionality
    public class VoucherCodeController : Controller
    {
        private readonly IVoucherCodeBusinessComponent _voucherCodeBusinessComponent;

        public VoucherCodeController(IVoucherCodeBusinessComponent voucherCodeBusinessComponent)
        {
            _voucherCodeBusinessComponent = voucherCodeBusinessComponent;
        }

        /// <summary>
        /// Get all voucher codes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<VoucherCode>), 200)]
        public Task<IList<VoucherCode>> GetAll()
        {
            return _voucherCodeBusinessComponent.GetAll();
        }

        /// <summary>
        /// Get a vouchercode by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(VoucherCode), 200)]
        public Task<VoucherCode> Get(long id)
        {
            return _voucherCodeBusinessComponent.GetById(id);
        }

        /// <summary>
        /// Generates voucher code and stores it in database
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <response code="200">Voucher code created</response>
        /// <returns></returns>
        [HttpPost(Name = "Generate")]
        [ProducesResponseType(typeof(VoucherCode), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public async Task<ActionResult> Post([FromBody]VoucherCode voucherCode)
        {
            var voucher = await _voucherCodeBusinessComponent.GenerateVoucherCode(voucherCode.Status, voucherCode.NumberOfFreeSeats, voucherCode.ScheduleId);
            return Json(voucher);
        }

        /// <summary>
        /// Updates a voucher code (NumberOfSeats, ScheduleId and Status fields can be updated)
        /// The voucher code itself cannot be changed..
        /// </summary>
        /// <param name="id"></param>
        /// <param name="voucher"></param>
        /// <returns></returns>
        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Put(int id, [FromBody]VoucherCode voucher)
        {
            if (id != voucher?.Id) return new StatusCodeResult(400);
            return await _voucherCodeBusinessComponent.Update(voucher) ?
                new StatusCodeResult(204) : new StatusCodeResult(404);
        }

        /// <summary>
        /// Delete a voucher code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(void), 404)]
        public async Task<ActionResult> Delete(int id)
        {
            return await _voucherCodeBusinessComponent.DeleteById(id) ?
                new StatusCodeResult(204) : new StatusCodeResult(404);
        }
    }
}
