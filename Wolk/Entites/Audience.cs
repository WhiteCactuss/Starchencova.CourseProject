using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolk.Entites
{
    public class Audience
    {
        public Guid Id { get; set; }
        public string Number { get; set; }

        public List<Schedule> Schedules { get; set; }

        private Audience() { }
        
        public Audience(string number)
        {
            Id = Guid.NewGuid();
            Number = number;
        }
    }
}
