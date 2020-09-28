using IG.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.server.Dtos
{
    public class WriteConnectedPerson
    {
      
        public int conectedpersonId { get; set; }
        public ConectedPersonType PersonType { get; set; }


    }
}
