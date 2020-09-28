using IG.Core.Data;
using IG.Core.Data.Entities;
using IG.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonsList.Core.Services
{
    public class PersonRepo:Repo<Person>
    {

        public PersonRepo(AplicationDbContext context):base(context)
        {

        }


        public async Task<IEnumerable<ConnectedPerson>> GetConnectedPeople(int Id)
        {

            var person=await GetById(Id);


           
            

            return person.ConectedPerson;

        }


    }
}
