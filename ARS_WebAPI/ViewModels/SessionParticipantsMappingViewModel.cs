using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARS_WebAPI.ViewModels
{
    public class SessionParticipantsMappingViewModel
    {
        public int Id { get; set; }

        public SessionDetailsViewModel SessionDetails { get; set; }

        public ParticipantViewModel Participant { get; set; }
    }
}
