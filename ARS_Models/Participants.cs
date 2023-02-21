using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
