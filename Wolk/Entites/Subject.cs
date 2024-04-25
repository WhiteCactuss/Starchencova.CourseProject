using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolk.Entites
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Schedule> Schedules { get; set; }

        private Subject() { }

        public Subject(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
