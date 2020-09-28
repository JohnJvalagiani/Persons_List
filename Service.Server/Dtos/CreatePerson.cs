using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace service.server.Dtos
{
    public class CreatePerson
    {

        public string FirstNameENG { get; set; }
        public string LastNameENG { get; set; }
        public string FirstNameGEO { get; set; }
        public string LastNameGEO { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        public string PersonalNumber { get; set; }
        public string Adress { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
