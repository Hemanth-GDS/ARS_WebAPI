using ARS_DAL.DALInterfaces;
using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALImplementations
{
    public class SessionTypeDAL : ISessionTypeDAL
    {
        private List<SessionType> _lstSessionType = new List<SessionType>();
        public SessionTypeDAL()
        {
            _lstSessionType.Add(new SessionType() { Id = 1, Name = ".NET CORE", IsActive = true });
            _lstSessionType.Add(new SessionType() { Id = 2, Name = "Angular", IsActive = true });
            _lstSessionType.Add(new SessionType() { Id = 3, Name = "Azure", IsActive = true });
        }

        public SessionType Add(SessionType model)
        {
            _lstSessionType.Add(model);
            return model;
        }

        public bool Delete(int id)
        {
            _lstSessionType.Remove(GetById(id));
            return true;
        }

        public List<SessionType> Get()
        {
            return _lstSessionType;
        }

        public SessionType GetById(int id)
        {
            return _lstSessionType.Find(x => x.Id == id);
        }

        public SessionType GetByName(string Name)
        {
            return _lstSessionType.Find(x => x.Name == Name);

        }
    }
}
