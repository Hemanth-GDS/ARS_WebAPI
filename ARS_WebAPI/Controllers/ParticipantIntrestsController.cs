using ARS_DAL.DALInterfaces;
using ARS_WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARS_WebAPI.ModelMappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARS_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParticipantIntrestsController : ControllerBase
    {
        private readonly IParticipantIntrestDAL _IParticipantIntrestDAL;
        private readonly ISessionTypeDAL _serviceType;

        public readonly IParticipantDAL _servicePart;

        public ParticipantIntrestsController(IParticipantIntrestDAL iparticipantIntrestDAL, ISessionTypeDAL serviceType, IParticipantDAL servicePart)
        {
            _IParticipantIntrestDAL = iparticipantIntrestDAL;
            _serviceType = serviceType;
            _servicePart = servicePart;
        }
        // GET: api/<ParticipantIntrestsController>
        [HttpGet]
        public List<ParticipantIntrestViewModel> Get()
        {
            return _IParticipantIntrestDAL.get().convertToLISTViewModel(_serviceType, _servicePart);
        }

        // GET api/<ParticipantIntrestsController>/5
        [HttpGet("GetByParticipantID/{id}")]
        public List<ParticipantIntrestViewModel> GetByParticipantID(int id)
        {
            return _IParticipantIntrestDAL.GetByParticipantID(id).convertToLISTViewModel(_serviceType, _servicePart);

        }

        // POST api/<ParticipantIntrestsController>
        [HttpPost]
        public ParticipantIntrestViewModel Add([FromBody] ParticipantIntrestViewModel value)
        {
            return _IParticipantIntrestDAL.Add(value.convertToModel()).convertToViewModel(_serviceType, _servicePart);
        }

        [HttpPost]
        public List<ParticipantIntrestViewModel> AddMultiple([FromBody] List<ParticipantIntrestViewModel> value)
        {
            return (_IParticipantIntrestDAL.AddMultiple(value.convertToListModel())).convertToLISTViewModel(_serviceType, _servicePart);
        }



        // PUT api/<ParticipantIntrestsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ParticipantIntrestsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
