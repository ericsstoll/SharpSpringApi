using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSpring
{
    public class List : IList
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int MemberCount { get; set; }
        public int removedCount { get; set; }
        public DateTime CreateTimestamp { get; set; }
        public string Description { get; set; }
    }
}
