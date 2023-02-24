using ARS_DAL.DALInterfaces;
using ARS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL.DALImplementations
{
    public class SQLSessionTypeDAL : ISessionTypeDAL
    {
        private readonly AppDBContext context;

        public SQLSessionTypeDAL(AppDBContext context)
        {
            this.context = context;

        }
        public SessionType Add(SessionType model)
        {
            try
            {
                context.SessionType.Add(model);
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
                context.Remove(GetById(id));
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
                
        }

        public List<SessionType> Get()
        {
            return context.SessionType.ToList();
        }

        public SessionType GetById(int id)
        {
            return context.SessionType.Where(x=> x.Id == id).FirstOrDefault();
        }

        public SessionType GetByName(string Name)
        {
            return context.SessionType.Where(x=> x.Name == Name).FirstOrDefault();

        }
    }
}
