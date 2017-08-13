using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Euricom.MjrCenter.VoucherApi.Model;
using Euricom.MjrCenter.VoucherApi.Utilities.RandomCodeGenerator;
using Euricom.MjrCenter.VoucherApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.VoucherApi.BusinessComponents
{
    public class VoucherCodeBusinessComponent : IVoucherCodeBusinessComponent
    {
        private readonly IVoucherCodeRepository _voucherCodeRepository;
        private IRandomCodeGenerator _randomCodeGenerator;

        public VoucherCodeBusinessComponent(IVoucherCodeRepository voucherCodeRepository,
                                            IRandomCodeGenerator randomCodeGenerator)
        {
            _voucherCodeRepository = voucherCodeRepository;
            _randomCodeGenerator = randomCodeGenerator;
        }

        /// <summary>
        /// Generates a voucher code. 
        /// Only admins are allowed to use this functionality
        /// </summary>
        /// <returns></returns>
        public async Task<VoucherCode> GenerateVoucherCode(VoucherStatus status, short numberOfSeats, long scheduleId)
        {
            var voucherCode = new VoucherCode()
            {
                Code = _randomCodeGenerator.Next(),
                NumberOfFreeSeats = numberOfSeats,
                ScheduleId = scheduleId,
                Status = status
            };

            await _voucherCodeRepository.Add(voucherCode);
            await _voucherCodeRepository.Commit();
            return voucherCode;
        }

        public async Task<bool> DeleteById(long id)
        {
            var voucherCode = await GetById(id);
            if (voucherCode == null) return false;
            await _voucherCodeRepository.Remove(voucherCode);
            await _voucherCodeRepository.Commit();
            return true;
        }

        public async Task<IList<VoucherCode>> GetAll()
        {
            return await _voucherCodeRepository.All.ToListAsync();
        }

        public Task<VoucherCode> GetById(long id)
        {
            return _voucherCodeRepository.All
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public Task<VoucherCode> GetByCode(string code)
        {
            return _voucherCodeRepository.All
                .SingleOrDefaultAsync(v => v.Code == code);
        }

        public async Task<bool> Update(VoucherCode voucher)
        {
            var dbVoucher = await GetById(voucher.Id);
            if (voucher == null) return false;
            if (voucher.Code != dbVoucher.Code)
                throw new InvalidOperationException("Can't update voucher because vouchercode is not a db match");

            dbVoucher.NumberOfFreeSeats = voucher.NumberOfFreeSeats;
            dbVoucher.ScheduleId = voucher.ScheduleId;
            dbVoucher.Status = voucher.Status;
            await _voucherCodeRepository.Commit();
            return true;
        }
    }
}
