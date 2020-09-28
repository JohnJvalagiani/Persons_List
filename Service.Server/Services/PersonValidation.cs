using FluentValidation;
using service.server.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.server.Services
{
    public class PersonValidation : AbstractValidator<CreatePerson>
    {


        public PersonValidation()
        {
            RuleFor(x => x.FirstNameENG).Length(1,250).NotEmpty();
            RuleFor(x => x.PhoneNumber).Length(9,12).NotEmpty();
            RuleFor(x => x.EmailAdress).EmailAddress().NotEmpty();
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.Adress).NotEmpty();
            RuleFor(x => x.FirstNameGEO).NotEmpty().WithMessage("Please specify a first name");
            RuleFor(x => x.Adress).Length(1,250).NotEmpty();
            RuleFor(x => x.PersonalNumber).Length(11, 11).NotEmpty();

        }




    }
}