using IG.Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace service.server.Dtos
{
    public class ReadPersonData
    {
        public int Id { get; set; }
        public string FirstNameENG { get; set; }
        public string LastNameENG { get; set; }
        public string FirstNameGEO { get; set; }
        public string LastNameGEO { get; set; }

        public DateTime BirthDate { get; set; }

        public long PersonalNumber { get; set; }

        public string Adress { get; set; }

        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }

    
        public byte[] Picture { get; set; }

    }
}
