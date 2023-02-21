using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_Models
{
    public class SessionDetails
    {
        public int Id { get; set; }

        public string SessionName { get; set; }

        public DateTime Date { get; set; }

        public Participant Trainer { get; set; }

        public SessionType SessionType { get; set; }

        public string Description { get; set; }
    }
}
