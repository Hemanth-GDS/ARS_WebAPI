using ARS_DAL.DALInterfaces;
using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALImplementations
{
    public class SessionDetailsDAL : ISessionDetailsDAL
    {
        private List<SessionDetails> _lstSessionDetails;

        public SessionDetailsDAL()
        {
            _lstSessionDetails.Add(new SessionDetails() { Id = 1, Date= DateTime.Now, Description="Session 1 DESC",SessionName="Session 1",SessionTypeId=1,TrainerId=1 });
            _lstSessionDetails.Add(new SessionDetails() { Id = 2, Date= DateTime.Now.AddDays(-1), Description="Session 2 DESC",SessionName="Session 2",SessionTypeId=2,TrainerId=2 });
            _lstSessionDetails.Add(new SessionDetails() { Id = 3, Date= DateTime.Now.AddDays(-2), Description="Session 3 DESC",SessionName="Session 3",SessionTypeId=3,TrainerId=3 });

        }
        public SessionDetails Add(SessionDetails model)
        {
            _lstSessionDetails.Add(model);
            return model;
        }

        public bool Delete(int id)
        {
            _lstSessionDetails.Remove(GetById(id));
            return true;
        }

        public List<SessionDetails> Get()
        {
            return _lstSessionDetails;
        }

        public SessionDetails GetById(int id)
        {
            return _lstSessionDetails.Find(x => x.Id == id);
        }

        public SessionDetails GetByName(string Name)
        {
            return _lstSessionDetails.Find(x => x.SessionName == Name);
        }
    }
}
