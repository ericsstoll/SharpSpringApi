using SharpSpring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSpring.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiContext ctx = new ApiContext();

            Accounts(ctx);
            Leads(ctx);
            Campaigns(ctx);
            LeadScoresExceptArke(ctx);
            Lists(ctx);

            System.Console.ReadLine();
        }

        private static void Lists(ApiContext ctx)
        {
            var lists = ctx.Get().Lists();
            foreach (IList l in lists)
            {
                System.Console.WriteLine($"{l.Name}");
                var members = ctx.Get().ListMembers(l.Id);
                //foreach (IListMember c in members)
                //{
                //    System.Console.WriteLine($"{c.ListId} {c.LeadId} {c.FirstName} {c.LastName} {c.EmailAddress}");
                //}
                System.Console.WriteLine($"{members.Count()} members");
            }
        }

        private static void Campaigns(ApiContext ctx)
        {
            var campaigns = ctx.Get().Campaigns();
            foreach (ICampaign c in campaigns)
            {
                System.Console.WriteLine($"{c.CampaignName}");
            }
        }

        private static void LeadScoresExceptArke(ApiContext ctx)
        {
            var list = ctx.Get().Lists().FirstOrDefault(a => a.Name == "Arke Employees");
            var members = ctx.Get().ListMembers(list.Id);
            var leads = ctx.Get().Leads();
            var ordered = leads.Where(a => members.FirstOrDefault(b => b.LeadId == a.Id) == null).GroupBy(a => a.LeadScoreWeighted).OrderByDescending(a => a.Key);
            System.Console.WriteLine($"{ordered.Count()} total leads");
            foreach(var l in ordered)
            {
                System.Console.WriteLine($"Score: {l.Key} => {l.Count()}");
            }
        }

        private static void Leads(ApiContext ctx)
        {
            var leads = ctx.Get().Leads();
            foreach (ILead l in leads)
            {
                System.Console.WriteLine($"{l.FirstName} {l.LastName}");
            }
        }

        private static void Accounts(ApiContext ctx)
        {
            var accounts = ctx.Get().Accounts();
            foreach (IAccount a in accounts)
            {
                System.Console.WriteLine(a.AccountName);
            }
        }
    }
}
