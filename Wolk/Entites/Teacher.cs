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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }

        public Schedule Schedule { get; set; }

        private Teacher() { }

        public Teacher(Guid teacherId, string firstname, string lastname, string? middlename)
        {
            TeacherId = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            MiddleName = middlename;
        }
    }
}
