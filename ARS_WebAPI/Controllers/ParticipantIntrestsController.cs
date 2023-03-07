using ARS_DAL.DALInterfaces;
using ARS_WebAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARS_WebAPI.ModelMappers;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;
using ARS_Models;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARS_WebAPI.Controllers
{
    [EnableCors("AllowOrigin")]
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
        public List<ParticipantIntrestViewModel> Get() {
            return _IParticipantIntrestDAL.get().convertToLISTViewModel(_serviceType, _servicePart);
        }


        [HttpGet]
        public IEnumerable<object> GetParticipantInterest()
        {
            var pis = _IParticipantIntrestDAL.get().convertToLISTViewModel(_serviceType, _servicePart).OrderBy(x => x.Participant.ParticipantId); foreach (var item in pis.Select(x => x.Participant.ParticipantId).Distinct())
            {
                yield return new { Participant = _servicePart.GetParticipant(item).Name, ParticipantIntrests = pis.Where(x => x.Participant.ParticipantId == item).Select(x => x.SessionType.Name) };
            }
        }

        [HttpGet("GetDetails")]
        public IEnumerable<object> GetDetails()
        {
            var pis = _IParticipantIntrestDAL.get().convertToLISTViewModel(_serviceType, _servicePart).OrderBy(x=> x.Participant.ParticipantId);

            foreach (var item in pis.Select(x=> x.Participant.ParticipantId).Distinct())
            {
                yield return new { ParticipantEmail = _servicePart.GetParticipant(item).Email, ParticipantIntrests = pis.Where(x => x.Participant.ParticipantId == item).Select(x => x.SessionType.Name) };
            }

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

        //[HttpPost]
        //public List<ParticipantIntrestViewModel> AddMultiple([FromBody] List<ParticipantIntrestViewModel> value)
        //{
        //    return (_IParticipantIntrestDAL.AddMultiple(value.convertToListModel())).convertToLISTViewModel(_serviceType, _servicePart);
        //}

        [HttpPost]
        public List<ParticipantIntrestViewModel> AddMultiple(int participantId, List<int> sessionTypeIds)
        {
            var ParticipantIntrest = new List<ParticipantIntrests>(); foreach (var item in sessionTypeIds)
            {
                ParticipantIntrest.Add(new ParticipantIntrests()
                {
                    ParticipantID = participantId,
                    SessionTypeId = item
                });
            }
            return (_IParticipantIntrestDAL.AddMultiple(ParticipantIntrest)).convertToLISTViewModel(_serviceType, _servicePart);
        }


        // PUT api/<ParticipantIntrestsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ParticipantIntrestsController>/5
        [HttpDelete("{id}")]
        public bool Delete(ParticipantIntrestViewModel value)
        {
            return _IParticipantIntrestDAL.Delete(value.convertToModel());
        }

        [HttpGet("GetParticipantIntrestfromFile")]
        public List<ParticipantIntrestViewModel> ParticipantIntrestfromFile([FromForm] IFormFile UploadedFile)
        {
            return (_IParticipantIntrestDAL.AddMultiple(ReadFileData(UploadedFile))).convertToLISTViewModel(_serviceType, _servicePart);
        }

        private List<ParticipantIntrests> ReadFileData(IFormFile UploadedFile)
        {
            var ParticipantIntrest = new List<ParticipantIntrests>();
            using (var stream = new MemoryStream())
            {
                UploadedFile.CopyTo(stream);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets[0];
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First(); int rowCount = workSheet.Dimension.Rows;
                    for (int row = 1; row <= rowCount; row++)
                    {
                        ParticipantIntrest.Add(new ParticipantIntrests()
                        {
                            ParticipantID = _servicePart.GetParticipantByEmail( workSheet.Cells[row, 2].Value.ToString().Trim()).ParticipantId,
                            SessionTypeId = _serviceType.GetByName(workSheet.Cells[row, 3].Value.ToString().Trim()).Id
                        });
                    }
                }
            }
            return ParticipantIntrest;
        }

    }
}
