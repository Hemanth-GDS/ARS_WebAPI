using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALInterfaces
{
    public interface ISessionDetailsDAL
    {
        List<SessionDetails> Get();
        SessionDetails GetById(int id);

        SessionDetails GetByName(string Name);

        SessionDetails Add(SessionDetails model);

        bool Delete(int id);
    }
}
