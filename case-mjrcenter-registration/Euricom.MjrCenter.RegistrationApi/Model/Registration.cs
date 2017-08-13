using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.RegistrationApi.Model
{
    public enum Status
    {
        New,Approved,Rejected
    }
    public class Registration 
    {
        public long Id { get; set; }
        //public Schedule Schedule { get; set; }
        public string ScheduleId { get; set; }
        public Customer RegistratedCustomer { get; set; }
        public long CustomerId { get; set; }
        public List<Person> Persons { get; set; }
        public string User { get; set; }
        public List<Payment> Payments { get; set; }
        public Status Status { get; set; }
        public string Comments { get; set; }
        public double AmountPayable { get; set; }

        internal string VoucherCodesJson { get; set; }
        public string[] VoucherCodes
        {
            get
            {
                return (VoucherCodesJson == null) ? new string[0] : JsonConvert.DeserializeObject<string[]>(VoucherCodesJson);
            }
            set
            {
                VoucherCodesJson = JsonConvert.SerializeObject(value);
            }
        }
    }
}
