using ARS_DAL.DALInterfaces;
using ARS_Models;
using ARS_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARS_WebAPI.ModelMappers
{
    public static class SessionDetailsModelMappers
    {
        public static SessionDetailsViewModel ConvertToViewModel(this SessionDetails sessionDetails, ISessionTypeDAL serviceType, IParticipantDAL servicePart)
        {
            return new SessionDetailsViewModel()
            {
                Id = sessionDetails.Id,
                Date = sessionDetails.Date,
                SessionName = sessionDetails.SessionName,
                Description = sessionDetails.Description,
                SessionType = serviceType.GetById(sessionDetails.SessionTypeId).ConvertToViewModel(),
                Trainer = servicePart.GetParticipant(sessionDetails.TrainerId).ConvertToViewModel(),
                UploadLink=sessionDetails.UploadLink
            };
        }

        public static List<SessionDetailsViewModel> ConvertToListViewModel(this List<SessionDetails> lst, ISessionTypeDAL serviceType, IParticipantDAL servicePart)
        {
            List<SessionDetailsViewModel> result = new List<SessionDetailsViewModel>();
            foreach (var sessionType in lst)
            {
                result.Add(sessionType.ConvertToViewModel(serviceType, servicePart));
            }
            return result;
        }

        public static SessionDetails ConvertToModel(this SessionDetailsViewModel sessionDetails)
        {
            return new SessionDetails()
            {
                Id = sessionDetails.Id,
                Date = sessionDetails.Date,
                SessionName = sessionDetails.SessionName,
                Description = sessionDetails.Description,
                SessionTypeId = sessionDetails.SessionType.Id,
                TrainerId = sessionDetails.Trainer.ParticipantId,
                UploadLink = sessionDetails.UploadLink
            };

        }

        public static List<SessionDetails> ConvertToListModel(this List<SessionDetailsViewModel> lst)
        {
            List<SessionDetails> result = new List<SessionDetails>();
            foreach (var sessionType in lst)
            {
                result.Add(sessionType.ConvertToModel());
            }
            return result;
        }
    }
}
