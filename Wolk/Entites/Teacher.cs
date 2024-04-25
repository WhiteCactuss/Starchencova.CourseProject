using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolk.Entites
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public List<Schedule> Schedules { get; set; }

        private Teacher() { }

        public Teacher(string fullName)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
        }
    }
}
