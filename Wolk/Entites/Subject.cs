using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolk.Entites
{
    public class Subject
    {
        public Guid SubjectId { get; set; }
        public string NameSubject { get; set; }

        public Schedule Schedule { get; set; }

        public Subject() { }

        public Subject(Guid subjectId, string nameObj)
        {
            SubjectId = Guid.NewGuid();
            NameSubject = nameObj;
        }
    }
}
