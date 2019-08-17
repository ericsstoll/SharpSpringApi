using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSpring
{
    public class Account : IAccount
    {
        public long Id { get; set; }
        public long? OwnerId { get; set; }
        public string AccountName { get; set; }
        public string Industry { get; set; }
        public string Phone { get; set; }
        public int? AnnualRevenue { get; set; }
        public int? NumberOfEmployees { get; set; }
        public string Website { get; set; }
        public int? YearStarted { get; set; }
        public string Fax { get; set; }
        public string BillingCity { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingState { get; set; }
        public string BillingStreetAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingState { get; set; }
        public string ShippingStreetAddress { get; set; }
    }
}
