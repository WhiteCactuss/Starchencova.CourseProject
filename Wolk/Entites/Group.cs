using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolk.Entites
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Schedule> Schedules { get; set; }
        private Group() { }
        
        public Group(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
