using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALInterfaces
{
     public interface IParticipantDAL
    {
        Participant GetParticipant(int id);

        List<Participant> GetParticipants();

        bool DeleteParticipant(int id);

        Participant Addparticipant(Participant participant);

        Participant Updateparticipant(int id, Participant participant);


    }
}
