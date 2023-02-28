using ARS_DAL.DALInterfaces;
using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALImplementations
{
    public class SQLSessionParticipantsMappingDAL : ISessionParticipantsMappingDAL
    {
        private readonly AppDBContext context;

        public SQLSessionParticipantsMappingDAL(AppDBContext context)
        {
            this.context = context;
        }
        public List<SessionParticipantsMapping> AddMultipleAttendence(List<SessionParticipantsMapping> lstSessionParticipantsMapping)
        {
            try
            {
                foreach (var item in lstSessionParticipantsMapping)
                {
                    AddSingleAttendence(item, false);
                }
                context.SaveChanges();
                return get();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SessionParticipantsMapping AddSingleAttendence(SessionParticipantsMapping sessionParticipantsMapping, bool fromAPI = true)
        {
            try
            {
                var spm = context.SessionParticipantsMapping.Where(x => x.ParticipantId == sessionParticipantsMapping.ParticipantId && x.SessionDetailsId == sessionParticipantsMapping.SessionDetailsId).FirstOrDefault();
                if (spm == null)
                {

                    context.SessionParticipantsMapping.Add(sessionParticipantsMapping);
                    if (fromAPI)
                        context.SaveChanges();
                    return sessionParticipantsMapping;
                }
                else
                    return spm;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SessionParticipantsMapping> get()
        {
            return context.SessionParticipantsMapping.ToList();
        }

        public List<SessionParticipantsMapping> getByParticipantId(int participantId)
        {
            return context.SessionParticipantsMapping.Where(x => x.ParticipantId == participantId).ToList();
        }

        public List<SessionParticipantsMapping> getBySessionDetailsId(int sessionDetailsId)
        {
            return context.SessionParticipantsMapping.Where(x => x.SessionDetailsId == sessionDetailsId).ToList();

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
