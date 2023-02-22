using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARS_WebAPI.ViewModels
{
    public class SessionDetailsViewModel
    {
        public int Id { get; set; }

        public string SessionName { get; set; }

        public DateTime Date { get; set; }

        public ParticipantViewModel Trainer { get; set; }

        public SessionTypeViewModel SessionType { get; set; }

        public string Description { get; set; }

        public string UploadLink { get; set; }
    }
}
