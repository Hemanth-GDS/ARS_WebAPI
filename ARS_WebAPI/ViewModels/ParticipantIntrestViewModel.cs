using ARS_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_WebAPI.ViewModels
{
    public class ParticipantIntrestViewModel
    {
        public int id { get; set; }

        public ParticipantViewModel Participant { get; set; }

        public SessionTypeViewModel SessionType { get; set; }
    }
}
