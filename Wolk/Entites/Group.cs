using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolk.Entites
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }

        public Schedule Schedule { get; set; }
        private Group() { }
        
        public Group(Guid groupId, string groupName)
        {
            GroupId = Guid.NewGuid();
            GroupName = groupName;
        }
    }
}
