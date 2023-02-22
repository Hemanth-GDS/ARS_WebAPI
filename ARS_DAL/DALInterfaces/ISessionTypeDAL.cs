using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALInterfaces
{
    public interface ISessionTypeDAL
    {
        List<SessionType> Get();
        SessionType GetById(int id);

        SessionType GetByName(string Name);

        SessionType Add(SessionType model);

        bool Delete(int id);
    }
}
