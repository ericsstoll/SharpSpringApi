using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSpring
{
    public class Lead: ILead
    {
        public long Id { get; set; }
        public long? OwnerId { get; set; }
        public long? AccountId { get; set; }
        public long? CampaignId { get; set; }
        public string LeadStatus { get; set; }
        public int? LeadScore { get; set; }
        public int? LeadScoreWeighted { get; set; }
        public string Persona { get; set; }
        public int Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string TrackingId { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string PhoneNumberExtension { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Description { get; set; }
        public string Industry { get; set; }
        public int? IsUnsubscribed { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public DateTime CreateTimestamp { get; set; }
    }
}
