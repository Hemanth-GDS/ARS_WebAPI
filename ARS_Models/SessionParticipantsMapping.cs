using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_Models
{
    public class SessionParticipantsMapping
    {
        public int Id { get; set; }

        public int SessionDetailsId { get; set; }

        public int ParticipantId { get; set; }
    }
}
