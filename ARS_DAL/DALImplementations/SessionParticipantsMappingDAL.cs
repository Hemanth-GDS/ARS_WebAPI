using ARS_DAL.DALInterfaces;
using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALImplementations
{
    public class SessionParticipantsMappingDAL : ISessionParticipantsMappingDAL
    {
        List<SessionParticipantsMapping> _lstSessionParticipantsMappings = new List<SessionParticipantsMapping>();
        public SessionParticipantsMappingDAL()
        {
            _lstSessionParticipantsMappings.Add(new SessionParticipantsMapping() {Id=1,ParticipantId=1,SessionDetailsId=1 });
            _lstSessionParticipantsMappings.Add(new SessionParticipantsMapping() {Id=2,ParticipantId=2,SessionDetailsId=1 });
            _lstSessionParticipantsMappings.Add(new SessionParticipantsMapping() {Id=3,ParticipantId=3,SessionDetailsId=1 });
            _lstSessionParticipantsMappings.Add(new SessionParticipantsMapping() {Id=4,ParticipantId=4,SessionDetailsId=1 });
            _lstSessionParticipantsMappings.Add(new SessionParticipantsMapping() {Id=5,ParticipantId=5,SessionDetailsId=1 });
        }

        public List<SessionParticipantsMapping> AddMultipleAttendence(List<SessionParticipantsMapping> lstSessionParticipantsMapping)
        {
            foreach (var item in lstSessionParticipantsMapping)
            {
                AddSingleAttendence(item);
            }
            return _lstSessionParticipantsMappings;
        }

        public SessionParticipantsMapping AddSingleAttendence(SessionParticipantsMapping sessionParticipantsMapping)
        {
            _lstSessionParticipantsMappings.Add(sessionParticipantsMapping);
            return sessionParticipantsMapping;
        }

        public List<SessionParticipantsMapping> get()
        {
            return _lstSessionParticipantsMappings;
        }

        public List<SessionParticipantsMapping> getByParticipantId(int participantId)
        {
            return _lstSessionParticipantsMappings.FindAll(x => x.ParticipantId == participantId);
        }

        public List<SessionParticipantsMapping> getBySessionDetailsId(int SessionDetailsId)
        {
            return _lstSessionParticipantsMappings.FindAll(x => x.SessionDetailsId == SessionDetailsId);

        }

        public List<SessionParticipantsMapping> getReport(List<SessionDetails> sessionDetails)
        {
            List<SessionParticipantsMapping> result = new List<SessionParticipantsMapping>();
            foreach (var item in sessionDetails)
            {
                if (item.TrainerId != 0)
                {
                    result.AddRange(getByParticipantId(item.TrainerId));
                }
                if (item.Id != 0)
                {
                    result.AddRange(getBySessionDetailsId(item.Id));
                }
            }
            return result.Distinct().ToList<SessionParticipantsMapping>();
        }
    }
}
