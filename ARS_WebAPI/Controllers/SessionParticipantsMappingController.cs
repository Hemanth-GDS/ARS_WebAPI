using ARS_DAL.DALInterfaces;
using ARS_WebAPI.ModelMappers;
using ARS_WebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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
            return _ISessionParticipantsMappingDAL.get().ConvertToListViewModel(_ISessionTypeDAL, _IParticipantDAL, _ISessionDetailsDAL);
        }

        [HttpGet("GetDetails")]
        public IEnumerable<object> GetDetails() 
        {
            return
            from item in _ISessionParticipantsMappingDAL.get().ConvertToListViewModel(_ISessionTypeDAL, _IParticipantDAL, _ISessionDetailsDAL) 
            select new { id = item.Id, sessionName = item.SessionDetails.SessionName, 
                date =item.SessionDetails.Date, trainerName = item.SessionDetails.Trainer.Name,
                sessionType = item.SessionDetails.SessionType.Name,
                participant = item.Participant.Name
            };
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

        [Route("[action]")]
        [HttpPost]
        public List<SessionParticipantsMappingViewModel> AddAttendenceFromFile([FromForm]UploadedSession uploadedSession)
        {
            #region add new participants if not added else fetch particpants
            List<ParticipantViewModel> tempPVM = ReadFileData(uploadedSession.UploadedFile);
            List<ParticipantViewModel> resPVM = new List<ParticipantViewModel>();

            foreach (var item in tempPVM)
            {
                var part = _IParticipantDAL.GetParticipantByEmail(item.Email);

                if (part == null)
                {
                    resPVM.Add(
                        _IParticipantDAL.Addparticipant((new ParticipantViewModel()
                        {
                            Email = item.Email,
                            Name = item.Name
                        }).ConvertToModel()).ConvertToViewModel()
                    );
                }
                else {
                    resPVM.Add(part.ConvertToViewModel());
                }
            }
            #endregion


            #region add new SessionDetails if not added else fetch SessionDetails
            List<SessionDetailsViewModel> lstSessionDtls = _ISessionDetailsDAL.Get().ConvertToListViewModel(_ISessionTypeDAL, _IParticipantDAL);

            var tempSession = lstSessionDtls
                                .Where(x => x.Date == uploadedSession.SessionDate && 
                                x.SessionType.Id == uploadedSession.SessionTypeId && 
                                x.Trainer.ParticipantId == uploadedSession.TrainerId).FirstOrDefault();

            if (tempSession == null) {
                //then create a new Session Details
                var s1 = _ISessionTypeDAL.GetById(uploadedSession.SessionTypeId).ConvertToViewModel();
                var p1 = _IParticipantDAL.GetParticipant(uploadedSession.TrainerId).ConvertToViewModel();
                tempSession = (_ISessionDetailsDAL.Add((new SessionDetailsViewModel()
                {
                    Date = uploadedSession.SessionDate,
                    SessionType = s1,
                    Trainer = p1,
                    SessionName = s1.Name + " BY - " + p1.Name +" " + uploadedSession.SessionDate.Date.ToShortDateString(),
                    Description = s1.Name + " BY - " + p1.Name + " " + uploadedSession.SessionDate.Date.ToUniversalTime(),
                    UploadLink = string.Empty

                }).ConvertToModel())).ConvertToViewModel(_ISessionTypeDAL, _IParticipantDAL);
            }

            #endregion

            List<SessionParticipantsMappingViewModel> resultPost = new List<SessionParticipantsMappingViewModel>();
            foreach (var item in resPVM)
            {
                resultPost.Add(new SessionParticipantsMappingViewModel()
                {
                    Participant = new ParticipantViewModel() { ParticipantId = item.ParticipantId },
                    SessionDetails = new SessionDetailsViewModel() { Id = tempSession.Id }
                });
            }

            return _ISessionParticipantsMappingDAL.AddMultipleAttendence(resultPost.ConvertToListModel()).ConvertToListViewModel(_ISessionTypeDAL, _IParticipantDAL, _ISessionDetailsDAL);
        }

        [Route("[action]")]
        [HttpPost]
        private List<ParticipantViewModel> ReadFileData(IFormFile UploadedFile)
        {
            var Participants = new List<ParticipantViewModel>();
            using (var stream = new MemoryStream())
            {
                UploadedFile.CopyTo(stream);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets[0];
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First(); int rowCount = workSheet.Dimension.Rows;
                    for (int row = 1; row <= rowCount; row++)
                    {
                        Participants.Add(new ParticipantViewModel()
                        {
                            Name = workSheet.Cells[row, 5].Value.ToString().Trim(),
                            Email = workSheet.Cells[row, 4].Value.ToString().Trim()
                        });
                    }
                }
            }
            return Participants;
        }


    }
}
