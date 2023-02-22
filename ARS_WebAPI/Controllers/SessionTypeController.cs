using ARS_DAL.DALInterfaces;
using ARS_WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ARS_WebAPI.ModelMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARS_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionTypeController : ControllerBase
    {
        private readonly ISessionTypeDAL _iSessionTypeDAL;

        public SessionTypeController(ISessionTypeDAL IsessionDAL)
        {
            _iSessionTypeDAL = IsessionDAL;
        }
        // GET: api/<SessionTypeController>
        [HttpGet]
        public IEnumerable<SessionTypeViewModel> Get()
        {
           return _iSessionTypeDAL.Get().ConvertToListViewModel();
        }

        // GET api/<SessionTypeController>/5
        [HttpGet("Get/{id}")]
        public SessionTypeViewModel Get(int id)
        {
            return _iSessionTypeDAL.GetById(id).ConvertToViewModel();
        }


        [HttpGet("GetByName/{name}")]
        public SessionTypeViewModel GetByName(string name)
        {
            return _iSessionTypeDAL.GetByName(name).ConvertToViewModel();
        }

        // POST api/<SessionTypeController>
        [HttpPost]
        public SessionTypeViewModel Post([FromBody] SessionTypeViewModel value)
        {
            return _iSessionTypeDAL.Add(value.ConvertToModel()).ConvertToViewModel();
        }

        // PUT api/<SessionTypeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<SessionTypeController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _iSessionTypeDAL.Delete(id);
        }
    }
}
