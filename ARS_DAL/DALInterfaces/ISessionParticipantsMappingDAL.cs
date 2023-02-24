using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALInterfaces
{
    public interface ISessionParticipantsMappingDAL
    {
        List<SessionParticipantsMapping> get();

        List<SessionParticipantsMapping> getBySessionDetailsId(int sessionDetailsId);

        List<SessionParticipantsMapping> getByParticipantId(int participantId);

        List<SessionParticipantsMapping> getReport(List<SessionDetails> sessionDetails);

        SessionParticipantsMapping AddSingleAttendence(SessionParticipantsMapping sessionParticipantsMapping, bool fromAPI = true);

        List<SessionParticipantsMapping> AddMultipleAttendence(List<SessionParticipantsMapping> lstSessionParticipantsMapping);

    }
}
 