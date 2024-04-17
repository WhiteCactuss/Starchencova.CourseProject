using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolk.Entites
{
    public class Audience
    {
        public Guid AudienceId { get; set; }
        public int NumberAudience { get; set; }

        public Schedule Schedule { get; set; }

        public Audience() { }
        
        public Audience(Guid audience, int numberAudience)
        {
            AudienceId = Guid.NewGuid();
            NumberAudience = numberAudience;
        }
    }
}
