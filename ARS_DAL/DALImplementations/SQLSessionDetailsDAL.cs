using ARS_DAL.DALInterfaces;
using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALImplementations
{
    public class SQLSessionDetailsDAL : ISessionDetailsDAL
    {
        private readonly AppDBContext context;

        public SQLSessionDetailsDAL(AppDBContext context)
        {
            this.context = context;
        }
        public SessionDetails Add(SessionDetails model)
        {
            try
            {
                context.Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                context.SessionDetails.Remove(GetById(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SessionDetails> Get()
        {
            return context.SessionDetails.ToList();
        }

        public SessionDetails GetById(int id)
        {
            return context.SessionDetails.Where(x => x.Id == id).FirstOrDefault();
        }

        public SessionDetails GetByName(string Name)
        {
            return context.SessionDetails.Where(x => x.SessionName == Name).FirstOrDefault();
        }
    }
}
