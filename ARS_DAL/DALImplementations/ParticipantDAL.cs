using ARS_Models;
using System;
using System.Collections.Generic;

namespace ARS_DAL
{
    public class ParticipantDAL : IParticipantDAL
    {
        private List<Participant> _lstparticipants = new List<Participant>();
        public ParticipantDAL()
        {
            _lstparticipants.Add(new Participant() { Email = "a1@gds.com", Name = "a1", ParticipantId = 1, IsActive = true });
            _lstparticipants.Add(new Participant() { Email = "a2@gds.com", Name = "a2", ParticipantId = 2, IsActive = true });
            _lstparticipants.Add(new Participant() { Email = "a3@gds.com", Name = "a3", ParticipantId = 3, IsActive = true });
            _lstparticipants.Add(new Participant() { Email = "a4@gds.com", Name = "a4", ParticipantId = 4, IsActive = true });
            _lstparticipants.Add(new Participant() { Email = "a5@gds.com", Name = "a5", ParticipantId = 5, IsActive = true });
            _lstparticipants.Add(new Participant() { Email = "a6@gds.com", Name = "a6", ParticipantId = 6, IsActive = true });
            _lstparticipants.Add(new Participant() { Email = "a7@gds.com", Name = "a7", ParticipantId = 7, IsActive = true });
        }
        public Participant GetParticipant(int id) 
        {
            return _lstparticipants.Find(x => x.ParticipantId == id);
        }


        public List<Participant> GetParticipants() 
        {
            return _lstparticipants;
        }

        public bool DeleteParticipant(int id) 
        {
            var _part = GetParticipant(id);
            if (_part != null)
            {
                _lstparticipants.Remove(_lstparticipants.Find(x => x.ParticipantId == id));
                return true;
            }

            return false;
            
        }


        public Participant Addparticipant(Participant participant) 
        {
            _lstparticipants.Add(participant);
            return participant;
        }

        public Participant Updateparticipant(int id,Participant participant)
        {
            for (int i = 0; i < _lstparticipants.Count; i++)
            {
                if (_lstparticipants[i].ParticipantId == id) 
                {
                    _lstparticipants[i] = participant;
                    return _lstparticipants[i];
                }
            }
            throw new Exception("Invalid operation Attemped");
        }
    }
}
