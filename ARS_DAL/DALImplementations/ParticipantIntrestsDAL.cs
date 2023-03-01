using ARS_DAL.DALInterfaces;
using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALImplementations
{
    public class ParticipantIntrestsDAL : IParticipantIntrestDAL
    {
        private readonly AppDBContext context;

        public ParticipantIntrestsDAL(AppDBContext context)
        {
            this.context = context;
        }
        public ParticipantIntrests Add(ParticipantIntrests participantIntrests,bool fromAPI = true)
        {
            try
            {
                var res = context.ParticipantIntrests.Add(participantIntrests);
                if (fromAPI)
                    context.SaveChanges();
                return res.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ParticipantIntrests> AddMultiple(List<ParticipantIntrests> lstParticipantIntrests)
        {
            try
            {
                List<ParticipantIntrests> res = new List<ParticipantIntrests>();
                foreach (var item in lstParticipantIntrests)
                {
                    res.Add(Add(item, false));
                }
                context.SaveChanges();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ParticipantIntrests> get()
        {
            return context.ParticipantIntrests.ToList();
        }

        public List<ParticipantIntrests> GetByIntrests(int SessionTypeId)
        {
            return context.ParticipantIntrests.Where(x => x.SessionTypeId==SessionTypeId).ToList();
        }

        public List<ParticipantIntrests> GetByParticipantID(int participantId)
        {
            return context.ParticipantIntrests.Where(x => x.ParticipantID == participantId).ToList();
        }

        public bool Delete(ParticipantIntrests participantIntrests) 
        {
            try
            {
                context.ParticipantIntrests.Remove(participantIntrests);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
