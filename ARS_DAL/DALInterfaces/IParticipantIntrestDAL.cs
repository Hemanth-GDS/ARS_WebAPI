using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALInterfaces
{
    public interface IParticipantIntrestDAL
    {
        List<ParticipantIntrests> get();

        List<ParticipantIntrests> GetByParticipantID(int participantId);

        List<ParticipantIntrests> GetByIntrests(int SessionTypeId);

        ParticipantIntrests Add(ParticipantIntrests participantIntrests, bool fromAPI = true);

        List<ParticipantIntrests> AddMultiple(List<ParticipantIntrests> lstParticipantIntrests);

        bool Delete(ParticipantIntrests participantIntrests);

    }
}
