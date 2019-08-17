using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSpring
{
    public class ListMember : IListMember
    {
        public long Id { get; set; }
        public long ListId { get; set; }
        public long MemberId { get; set; }
        public bool IsRemoved { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public long LeadId { get; set; }
    }
}
