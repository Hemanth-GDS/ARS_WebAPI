using ARS_DAL.DALInterfaces;
using ARS_Models;
using ARS_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARS_WebAPI.ModelMappers
{
    public static class ParticipantIntrestModelMapper
    {
        public static ParticipantIntrestViewModel convertToViewModel(this ParticipantIntrests pi, ISessionTypeDAL serviceType, IParticipantDAL servicePart) 
        {
            return new ParticipantIntrestViewModel()
            {
                id = pi.id,
                Participant = servicePart.GetParticipant(pi.ParticipantID).ConvertToViewModel(),
                SessionType = serviceType.GetById(pi.SessionTypeId).ConvertToViewModel()
            };
        }

        public static List<ParticipantIntrestViewModel> convertToLISTViewModel(this List<ParticipantIntrests> lstPi, ISessionTypeDAL serviceType, IParticipantDAL servicePart)
        {
            List<ParticipantIntrestViewModel> res = new List<ParticipantIntrestViewModel>();
            foreach (var item in lstPi)
            {
                res.Add(convertToViewModel(item, serviceType, servicePart));
            }
            return res;
        }


        public static ParticipantIntrests convertToModel(this ParticipantIntrestViewModel pivm) 
        {
            return new ParticipantIntrests() { 
                id= pivm.id,
                ParticipantID = pivm.Participant.ParticipantId,
                SessionTypeId = pivm.SessionType.Id
            };
        }

        public static List<ParticipantIntrests> convertToListModel(this List<ParticipantIntrestViewModel> lstPivm)
        {
            List<ParticipantIntrests> res = new List<ParticipantIntrests>();
            foreach (var item in lstPivm)
            {
                res.Add(convertToModel(item));
            }
            return res;
        }



    }
}
