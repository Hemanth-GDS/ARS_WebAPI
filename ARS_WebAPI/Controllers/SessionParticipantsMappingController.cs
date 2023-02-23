using ARS_DAL.DALInterfaces;
using ARS_WebAPI.ModelMappers;
using ARS_WebAPI.ViewModels;
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
    public class SessionParticipantsMappingController : ControllerBase
    {
        private readonly ISessionParticipantsMappingDAL _ISessionParticipantsMappingDAL;
        private readonly ISessionDetailsDAL _ISessionDetailsDAL;
        private readonly ISessionTypeDAL _ISessionTypeDAL;
        private readonly IParticipantDAL _IParticipantDAL;

        public SessionParticipantsMappingController(ISessionParticipantsMappingDAL ISessionParticipantsMappingDAL, ISessionDetailsDAL ISessionDetailsDAL,
            ISessionTypeDAL ISessionTypeDAL, IParticipantDAL IParticipantDAL)
        {
            _ISessionParticipantsMappingDAL = ISessionParticipantsMappingDAL;
            _ISessionDetailsDAL = ISessionDetailsDAL;
            _ISessionTypeDAL = ISessionTypeDAL;
            _IParticipantDAL = IParticipantDAL;
        }
        // GET: api/<SessionParticipantsMappingController>
        [HttpGet]
        public IEnumerable<SessionParticipantsMappingViewModel> Get()
        {
            return _ISessionParticipantsMappingDAL.get().ConvertToListViewModel(_ISessionTypeDAL,_IParticipantDAL,_ISessionDetailsDAL);
        }

        // GET api/<SessionParticipantsMappingController>/5
        [HttpGet("getByParticipantId/{id}")]
        public IEnumerable<SessionParticipantsMappingViewModel> getByParticipantId(int id)
        {
            return _ISessionParticipantsMappingDAL.getByParticipantId(id).ConvertToListViewModel(_ISessionTypeDAL, _IParticipantDAL, _ISessionDetailsDAL);
        }


        [HttpGet("getBySessionDetailsId/{id}")]
        public IEnumerable<SessionParticipantsMappingViewModel> getBySessionDetailsId(int id)
        {
            return _ISessionParticipantsMappingDAL.getBySessionDetailsId(id).ConvertToListViewModel(_ISessionTypeDAL, _IParticipantDAL, _ISessionDetailsDAL);
        }

        // POST api/<SessionParticipantsMappingController>
        [Route("[action]")]
        [HttpPost]
        public SessionParticipantsMappingViewModel Post([FromBody] SessionParticipantsMappingViewModel value)
        {
            return _ISessionParticipantsMappingDAL.AddSingleAttendence(value.ConvertToModel()).ConvertToViewModel(_ISessionTypeDAL, _IParticipantDAL, _ISessionDetailsDAL);
        }

        [Route("[action]")]
        [HttpPost]
        public List<SessionParticipantsMappingViewModel> PostMultipleAttendence([FromBody] List<SessionParticipantsMappingViewModel> value)
        {
            return _ISessionParticipantsMappingDAL.AddMultipleAttendence(value.ConvertToListModel()).ConvertToListViewModel(_ISessionTypeDAL, _IParticipantDAL, _ISessionDetailsDAL);
        }

        // PUT api/<SessionParticipantsMappingController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<SessionParticipantsMappingController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}
