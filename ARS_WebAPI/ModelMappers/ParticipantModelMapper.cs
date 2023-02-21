using ARS_Models;
using ARS_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARS_WebAPI.ModelMappers
{
    public static class ParticipantModelMapper
    {
        public static ParticipantViewModel ConvertToViewModel(this Participant participant)
        {
            return new ParticipantViewModel()
            {
                Email = participant.Email,
                IsActive = participant.IsActive,
                Name = participant.Name,
                ParticipantId = participant.ParticipantId
            };
        }

        public static List<ParticipantViewModel> ConvertToListViewModel(this List<Participant> lst) 
        {
            List<ParticipantViewModel> result = new List<ParticipantViewModel>();
            foreach (var pcpt in lst)
            {
                result.Add(pcpt.ConvertToViewModel());
            }
            return result;
        }

        public static Participant ConvertToModel(this ParticipantViewModel participantVM) 
        {
            return new Participant()
            {
                Email = participantVM.Email,
                IsActive = participantVM.IsActive,
                Name = participantVM.Name,
                ParticipantId = participantVM.ParticipantId
            };

        }

        public static List<Participant> ConvertToListModel(this List<ParticipantViewModel> lst)
        {
            List<Participant> result = new List<Participant>();
            foreach (var pcpt in lst)
            {
                result.Add(pcpt.ConvertToModel());
            }
            return result;
        }

    }
}
