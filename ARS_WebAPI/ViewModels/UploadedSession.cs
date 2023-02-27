using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARS_WebAPI.ViewModels
{
    public class UploadedSession
    {
        public int SessionId { get; set; }
        public int TrainerId { get; set; }
        public int SessionTypeId { get; set; }
        public DateTime SessionDate { get; set; }
        public IFormFile UploadedFile { get; set; }
    }
}
