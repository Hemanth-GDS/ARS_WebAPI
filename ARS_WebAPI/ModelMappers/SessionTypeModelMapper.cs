using ARS_Models;
using ARS_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARS_WebAPI.ModelMappers
{
    public static class SessionTypeModelMapper
    {
        public static SessionTypeViewModel ConvertToViewModel(this SessionType sessionType)
        {
            return new SessionTypeViewModel()
            {
                Id = sessionType.Id,
                IsActive = sessionType.IsActive,
                Name = sessionType.Name
            };
        }

        public static List<SessionTypeViewModel> ConvertToListViewModel(this List<SessionType> lst)
        {
            List<SessionTypeViewModel> result = new List<SessionTypeViewModel>();
            foreach (var sessionType in lst)
            {
                result.Add(sessionType.ConvertToViewModel());
            }
            return result;
        }

        public static SessionType ConvertToModel(this SessionTypeViewModel participantVM)
        {
            return new SessionType()
            {
                IsActive = participantVM.IsActive,
                Name = participantVM.Name,
                Id = participantVM.Id
            };

        }

        public static List<SessionType> ConvertToListModel(this List<SessionTypeViewModel> lst)
        {
            List<SessionType> result = new List<SessionType>();
            foreach (var sessionType in lst)
            {
                result.Add(sessionType.ConvertToModel());
            }
            return result;
        }

    }
}
