using ARS_DAL.DALInterfaces;
using ARS_WebAPI.ViewModels;
using ARS_WebAPI.ModelMappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionDetailsController : ControllerBase
    {
        private ISessionDetailsDAL _ISessionDetailsDAL;
        private ISessionTypeDAL _ISessionTypeDAL;
        private IParticipantDAL _IParticipantDAL;

        public SessionDetailsController(ISessionDetailsDAL ISessionDetailsDAL,ISessionTypeDAL ISessionTypeDAL, IParticipantDAL IParticipantDAL)
        {

            _ISessionDetailsDAL = ISessionDetailsDAL;
            _ISessionTypeDAL = ISessionTypeDAL;
            _IParticipantDAL = IParticipantDAL;
        }
        // GET: api/<SessionDetailsController>
        [HttpGet]
        public IEnumerable<SessionDetailsViewModel> Get()
        {
            return _ISessionDetailsDAL.Get().ConvertToListViewModel(_ISessionTypeDAL, _IParticipantDAL);
        }

        // GET api/<SessionDetailsController>/5
        [HttpGet("{id}")]
        public SessionDetailsViewModel Get(int id)
        {
            return _ISessionDetailsDAL.GetById(id).ConvertToViewModel(_ISessionTypeDAL,_IParticipantDAL);
        }

        [HttpGet("GetByName/{name}")]
        public SessionDetailsViewModel GetByName(string name)
        {
            return _ISessionDetailsDAL.GetByName(name).ConvertToViewModel(_ISessionTypeDAL, _IParticipantDAL);
        }


        // POST api/<SessionDetailsController>
        [HttpPost]
        public SessionDetailsViewModel Post([FromBody] SessionDetailsViewModel value)
        {
            return _ISessionDetailsDAL.Add(value.ConvertToModel()).ConvertToViewModel(_ISessionTypeDAL, _IParticipantDAL);
        }

        
        // DELETE api/<SessionDetailsController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _ISessionDetailsDAL.Delete(id);
        }
    }
}
