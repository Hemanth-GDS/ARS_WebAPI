using ARS_DAL;
using ARS_Models;
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
    public class ParticipantController : ControllerBase
    {
        private IParticipantDAL _IparticipantDAL;

        public ParticipantController(IParticipantDAL IparticipantDAL)
        {
            _IparticipantDAL = IparticipantDAL;
        }

        // GET: api/<ParticipantController>
        [HttpGet]
        public IEnumerable<ParticipantViewModel> Get()
        {
            return _IparticipantDAL.GetParticipants().ConvertToListViewModel();

        }

        // GET api/<ParticipantController>/5
        [HttpGet("{id}")]
        public ParticipantViewModel Get(int id)
        {
            return _IparticipantDAL.GetParticipant(id).ConvertToViewModel(); 
        }

        // POST api/<ParticipantController>
        [HttpPost]
        public ParticipantViewModel Post([FromBody] ParticipantViewModel value)
        {
            return _IparticipantDAL.Addparticipant(value.ConvertToModel()).ConvertToViewModel();
        }

        // PUT api/<ParticipantController>/5
        [HttpPut("{id}")]
        public ParticipantViewModel Put(int id, [FromBody] ParticipantViewModel value)
        {
            return _IparticipantDAL.Updateparticipant(id, value.ConvertToModel()).ConvertToViewModel();
        }

        // DELETE api/<ParticipantController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _IparticipantDAL.DeleteParticipant(id);
        }
    }
}
