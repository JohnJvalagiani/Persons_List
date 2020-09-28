using AutoMapper;
using IG.Core.Data.Entities;
using service.server.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.server.Profiles
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Person,CreatePerson>();
            CreateMap<CreatePerson,Person>();


            CreateMap<Person, ReadPersonData>();
            CreateMap<ReadPersonData, Person>();


            CreateMap<ConnectedPerson, ReadConnectedPerson>();
            CreateMap<ReadConnectedPerson, ConnectedPerson>();


            CreateMap<ConnectedPerson, WriteConnectedPerson>();
            CreateMap<WriteConnectedPerson, ConnectedPerson>();


        }


    }
}
