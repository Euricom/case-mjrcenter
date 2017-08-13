using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.RegistrationApi.Model
{

    public partial class Customer
    {
        public long Id { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public ContactMethod ContactBy { get; set; }
        public string InvoiceCompanyName { get; set; }
        public string InvoiceAddress { get; set; }
        public VatOption InvoiceVatOption { get; set; }
        public string InvoiceEnterpriseNumber { get; set; }
        public bool IsDeleted { get; set; }
        internal string InterestsJson { get; set; }
        public string[] Interests
        {
            get
            {
                return (InterestsJson == null) ? new string[0] : JsonConvert.DeserializeObject<string[]>(InterestsJson);
            }
            set
            {
                InterestsJson = JsonConvert.SerializeObject(value);
            }
        }
    }
}
