using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolk.Entites
{
    public class Teacher
    {
        public Guid TeacherId { get; set; }
        public string FLMName { get; set; }

        public Schedule Schedule { get; set; }

        private Teacher() { }

        public Teacher(string flmname)
        {
            TeacherId = Guid.NewGuid();
            FLMName = flmname;
        }
    }
}
