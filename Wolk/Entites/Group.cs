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
        public string NameGroup { get; set; }

        public Schedule Schedule { get; set; }
        private Group() { }
        
        public Group(string nameGroup)
        {
            GroupId = Guid.NewGuid();
            NameGroup = nameGroup;
        }
    }
}
