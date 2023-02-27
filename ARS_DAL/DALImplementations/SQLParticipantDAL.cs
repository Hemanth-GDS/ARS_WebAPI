using ARS_DAL.DALInterfaces;
using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALImplementations
{
    public class SQLParticipantDAL : IParticipantDAL
    {
        private readonly AppDBContext context;

        public SQLParticipantDAL(AppDBContext context)
        {
            this.context = context;
        }
        public Participant Addparticipant(Participant participant)
        {
            try
            {
                context.Participant.Add(participant);
                context.SaveChanges();
                return participant;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteParticipant(int id)
        {
            try
            {
                context.Participant.Remove(GetParticipant(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Participant GetParticipant(int id)
        {
            return context.Participant.Where(x => x.ParticipantId == id).FirstOrDefault();
        }

        public Participant GetParticipantByEmail(string email)
        {
            return context.Participant.Where(x => x.Email == email).FirstOrDefault();
        }

        public List<Participant> GetParticipants()
        {
            return context.Participant.ToList();
        }

        public Participant Updateparticipant(int id, Participant participant)
        {
            try
            {
                var part = context.Participant.Attach(participant);
                part.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return participant;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
