using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSpring
{
    public class Campaign: ICampaign
    {
        public long Id { get; set; }
        public string CampaignName { get; set; }
        public string CampaignType { get; set; }
        public string CampaignAlias { get; set; }
        public string CampaignOrigin { get; set; }
        public int? Qty { get; set; }
        public double? Price { get; set; }
        public double? Goal { get; set; }
        public double? OtherCosts { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IsActive { get; set; }
    }
}
