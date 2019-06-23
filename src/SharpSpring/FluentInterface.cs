using System;
using System.Collections.Generic;
using System.Text;

namespace SharpSpring
{
    public interface IGet
    {
        IGetEntity Get();
    }

    public interface IGetEntity
    {
        IEnumerable<IAccount> Accounts(int id = 0, int ownerId = 0, int limit = Int32.MaxValue, int offset = 0);
        IEnumerable<ICampaign> Campaigns(int id = 0, int ownerId = 0, int limit = Int32.MaxValue, int offset = 0);
        IEnumerable<ILead> Leads(int id = 0, int ownerId = 0, int limit = Int32.MaxValue, int offset = 0);
    }

    public interface IAccount
    {
        long Id { get; set; }
        long? OwnerId { get; set; }
        string AccountName { get; set; }
        string Industry { get; set; }
        string Phone { get; set; }
        int? AnnualRevenue { get; set; }
        int? NumberOfEmployees { get; set; }
        string Website { get; set; }
        int? YearStarted { get; set; }
        string Fax { get; set; }
        string BillingCity { get; set; }
        string BillingPostalCode { get; set; }
        string BillingState { get; set; }
        string BillingStreetAddress { get; set; }
        string ShippingCity { get; set; }
        string ShippingPostalCode { get; set; }
        string ShippingState { get; set; }
        string ShippingStreetAddress { get; set; }
    }

    public interface ICampaign
    {
        long Id { get; set; }
        string CampaignName { get; set; }
        string CampaignType { get; set; }
        string CampaignAlias { get; set; }
        string CampaignOrigin { get; set; }
        int? Qty { get; set; }
        double? Price { get; set; }
        double? Goal { get; set; }
        double? OtherCosts { get; set; }
        DateTime? StartDate { get; set; }
        DateTime? EndDate { get; set; }
        int? IsActive { get; set; }
    }

    public interface ILead
    {
        long Id { get; set; }
        long? OwnerId { get; set; }
        long? AccountId { get; set; }
        long? CampaignId { get; set; }
        string LeadStatus { get; set; }
        int? LeadScore { get; set; }
        int? LeadScoreWeighted { get; set; }
        string Persona { get; set; }
        int Active { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        string CompanyName { get; set; }
        string Title { get; set; }
        string Street { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string State { get; set; }
        string Zipcode { get; set; }
        string Website { get; set; }
        string PhoneNumber { get; set; }
        string TrackingId { get; set; }
        string OfficePhoneNumber { get; set; }
        string PhoneNumberExtension { get; set; }
        string MobilePhoneNumber { get; set; }
        string FaxNumber { get; set; }
        string Description { get; set; }
        string Industry { get; set; }
        int? IsUnsubscribed { get; set; }
        DateTime UpdatedTimestamp { get; set; }
        DateTime CreateTimestamp { get; set; }
    }
}
