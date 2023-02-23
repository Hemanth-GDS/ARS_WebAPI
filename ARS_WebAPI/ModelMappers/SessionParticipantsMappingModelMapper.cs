using ARS_DAL.DALInterfaces;
using ARS_Models;
using ARS_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARS_WebAPI.ModelMappers
{
    public static class SessionParticipantsMappingModelMapper
    {
        public static SessionParticipantsMappingViewModel ConvertToViewModel(this SessionParticipantsMapping spvm, ISessionTypeDAL serviceType, IParticipantDAL servicePart,ISessionDetailsDAL sessionDetail)
        {
            return new SessionParticipantsMappingViewModel()
            {
                Id = spvm.Id,
                Participant = servicePart.GetParticipant(spvm.ParticipantId).ConvertToViewModel(),
                SessionDetails = sessionDetail.GetById(spvm.SessionDetailsId).ConvertToViewModel(serviceType,servicePart)

            };
        }


        public static List<SessionParticipantsMappingViewModel> ConvertToListViewModel(this List<SessionParticipantsMapping> lst, ISessionTypeDAL serviceType, IParticipantDAL servicePart, ISessionDetailsDAL sessionDetail)
        {
            List<SessionParticipantsMappingViewModel> result = new List<SessionParticipantsMappingViewModel>();
            foreach (var spvm in lst)
            {
                result.Add(spvm.ConvertToViewModel(serviceType, servicePart,sessionDetail));
            }
            return result;
        }

        public static SessionParticipantsMapping ConvertToModel(this SessionParticipantsMappingViewModel spvm)
        {
            return new SessionParticipantsMapping()
            {
                Id = spvm.Id,
                ParticipantId = spvm.Participant.ParticipantId,
                SessionDetailsId = spvm.SessionDetails.Id
                
            };

        }

        public static List<SessionParticipantsMapping> ConvertToListModel(this List<SessionParticipantsMappingViewModel> lst)
        {
            List<SessionParticipantsMapping> result = new List<SessionParticipantsMapping>();
            foreach (var sessionType in lst)
            {
                result.Add(sessionType.ConvertToModel());
            }
            return result;
        }
    }
}

