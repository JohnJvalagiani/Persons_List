using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using IG.Core.Data.Entities;
using IG.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using service.server.Dtos;
using service.server.Exceptions;
using service.server.HelperClasses;
using service.server.Models;
using service.server.Services;

namespace service.server.Controllers
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRepo<Person> _personrepo;
        private readonly IMapper _mapper;
        private readonly PersonValidation _validator;
        private readonly IStringLocalizer<PersonController> _localizer;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IRepo<Person> personrepo,  IMapper mapper, PersonValidation validator,
            IStringLocalizer<PersonController> localizer,ILogger<PersonController> logger)
        {
            _personrepo = personrepo;
            _mapper = mapper;
            _validator = validator;
            _localizer = localizer;
            _logger = logger;
        }

        [HttpGet("Localization")]
        public IActionResult GetCurrentCultureDate()
        {

            var guid = Guid.NewGuid();

            return Ok(_localizer["RandomGUID", guid.ToString()].Value);


        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search( DetailedSearchParametrs detailSearchParametrs)
        {



            try
            {

                Func<IQueryable<Person>, IOrderedQueryable<Person>> orderByFunc = null;

                switch (detailSearchParametrs.OrderPersonsby)
                {
                    case person.FirstNameENG:
                        orderByFunc = q => q.OrderBy(p => p.FirstNameENG);
                        break;
                    case person.LastNameENG:
                        orderByFunc = q => q.OrderBy(p => p.LastNameENG);

                        break;
                    case person.FirstNameGEO:
                        orderByFunc = q => q.OrderBy(p => p.FirstNameGEO);

                        break;
                    case person.LastNameGEO:
                        orderByFunc = q => q.OrderBy(p => p.LastNameGEO);

                        break;
                    case person.PhoneNumber:
                        orderByFunc = q => q.OrderBy(p => p.PhoneNumber);

                        break;
                    case person.PersonalNumber:
                        orderByFunc = q => q.OrderBy(p => p.PersonalNumber);

                        break;
                    case person.Adress:
                        orderByFunc = q => q.OrderBy(p => p.Adress);
                        break;

                    default:
                        orderByFunc = q => q.OrderBy(p => p.FirstNameENG);
                        break;


                }

                var predicate =  GenericExpressionTree.CreateWhereClause<Person>(detailSearchParametrs.SearchPersonsBy.ToString(), detailSearchParametrs.SearchValue);


                var persons = await _personrepo.GetByQueryAsync(predicate, orderByFunc);

                if(persons==null)
                {

                    throw new NotFoundException();
                }

                var thepersons = persons.Select(p => _mapper.Map<ReadPersonData>(p));

                var result = PagedList<ReadPersonData>
                    .ToPagedList(thepersons.AsQueryable(), detailSearchParametrs.pagingParametrs.PageNumber, detailSearchParametrs.pagingParametrs.PageSize);


                return Ok(result);

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost("Get All Person")]
        public async Task<IActionResult> GetAllPerson(PagingParametrs pagingParametrs)
        {

            try
            {
                _logger.LogInformation(Logevents.GetItem, "Getting All Persons");




                var persons = await _personrepo.GetAll();

                if (persons == null)
                {
                    _logger.LogWarning(Logevents.GetItemNotFound, " NOT FOUND");

                    throw new NotFoundException();
                }

                var thepersons = persons.Select(p => _mapper.Map<ReadPersonData>(p));

                var result = PagedList<ReadPersonData>
                  .ToPagedList(thepersons.AsQueryable(), pagingParametrs.PageNumber, pagingParametrs.PageSize);


                return Ok(result);

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost("Add person")]
        public async Task<IActionResult> AddPerson([FromBody] CreatePerson person) {

            try
            {
                _logger.LogInformation(Logevents.InsertItem, "Adding Person ");

                if(person==null)
                {
                    _logger.LogInformation(Logevents.InsertItem, "Argument was null", nameof(person));

                    throw new ArgumentNullException(nameof(person));
                }

                var validateresult = await _validator.ValidateAsync(person);


                await _validator.ValidateAndThrowAsync(person);

                if (validateresult.IsValid == false)
                {
                    _logger.LogWarning($"{validateresult.Errors.AsEnumerable()}");


                }

                var theperson = _mapper.Map<Person>(person);

                var newperson = await _personrepo.Add(theperson);

                

                return Created(nameof(Person), newperson);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("Get Person By Id {id}")]
        public async Task<IActionResult> GetPersonDetails(int id)
        {
            _logger.LogInformation(Logevents.GetItem, "Get  Person {Id}", id);


            if (id<=0)
                throw new ArgumentException(nameof(id));


            var person = await _personrepo.GetById(id);

            if (person == null)
            {
                
                _logger.LogWarning(Logevents.GetItemNotFound, "Get({Id}) NOT FOUND", id);

                throw new NotFoundException();

            }

            var theperson = _mapper.Map<ReadPersonData>(person);


            
            return Ok(theperson);


        }

        [HttpDelete("Delete Person {id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {

            try
            {
                _logger.LogInformation(Logevents.DeleteItem, "Delete  Person {Id}", id);
                

               var person = await _personrepo.GetById(id);

                if(person==null)
                {
                   
                    _logger.LogWarning(Logevents.GetItemNotFound, "Get({Id}) NOT FOUND", id);

                    throw new NotFoundException();
                }

                await _personrepo.Remove(person.Id);


                return NoContent();

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost("Update Person")]
        public async Task<IActionResult> EditPerson([FromBody] ReadPersonData person)
        {

            try
            {
                _logger.LogInformation(Logevents.UpdateItem, "Update  Person {Id}", person.Id);

                
         if(await _personrepo.GetById(person.Id)==null)
                {

                _logger.LogWarning(Logevents.GetItemNotFound, "Get ({Id}) NOT FOUND", person.Id);

                    throw new NotFoundException();

                }

                var theperson = _mapper.Map<Person>(person);


                theperson = await _personrepo.Update(theperson);


                return Ok(theperson);

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }








    }
}
