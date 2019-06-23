using System;
using System.Collections.Generic;
using System.Text;

namespace SharpSpringApi
{
    public interface IGet
    {
        IGetEntity Get();
    }

    public interface IGetEntity
    {
        IEnumerable<IAccount> Accounts(int id = 0, int ownerId = 0, int limit = Int32.MaxValue, int offset = 0);
    }

    public interface IAccount
    {
        int Id { get; set; }
        int OwnerId { get; set; }
        string AccountName { get; set; }
        string Industry { get; set; }
        string Phone { get; set; }
        int AnnualRevenue { get; set; }
        int NumberOfEmployees { get; set; }
        string Website { get; set; }
        int YearStarted { get; set; }
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
}
