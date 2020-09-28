using System;
using System.Collections.Generic;
using System.Text;

namespace IG.Core.Data.Entities
{
    public class ConnectedPerson:BaseEntity
    {

        public int conectedpersonId { get; set; }

        public ConectedPersonType PersonType { get; set; }

        public int ForeignKey { get; set; }
        public Person Person { get; set; }
    }
}
