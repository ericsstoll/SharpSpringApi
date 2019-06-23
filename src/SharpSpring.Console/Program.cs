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

            var accounts = ctx.Get().Accounts();
            foreach(IAccount a in accounts)
            {
                System.Console.WriteLine(a.AccountName);
            }

            var leads = ctx.Get().Leads();
            foreach(ILead l in leads)
            {
                System.Console.WriteLine($"{l.FirstName} {l.LastName}");
            }

            var campaigns = ctx.Get().Campaigns();
            foreach(ICampaign c in campaigns)
            {
                System.Console.WriteLine($"{c.CampaignName}");
            }

            System.Console.ReadLine();
        }
    }
}
