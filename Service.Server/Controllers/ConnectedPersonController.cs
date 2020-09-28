using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using IG.Core.Data.Entities;
using IG.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using service.server.Dtos;
using service.server.HelperClasses;

namespace service.server.Controllers
{
    [Route("api/ConnectedPerson")]
    [ApiController]
    public class ConnectedPersonController : ControllerBase
    {

        private readonly IRepo<Person> _personrepo;
        private readonly IRepo<ConnectedPerson> _connectedPersonrepo;
        private readonly ILogger<ConnectedPersonController> _logger;
        private readonly IMapper _mapper;

        public ConnectedPersonController(ILogger<ConnectedPersonController> logger,IRepo<Person> personrepo, IRepo<ConnectedPerson> connectedPerson, IMapper mapper)
        {
            _personrepo = personrepo;
            _mapper = mapper;
            _connectedPersonrepo = connectedPerson;
            _logger = logger;
        } 

        [HttpPost("Add Connected Person")]
        public async Task<IActionResult> Add(int id, WriteConnectedPerson connectedPerson)
        {
              _logger.LogInformation(Logevents.GetItem, "Add Connected Person {Id}", id);

            try
            {


           

                if (id <= 0)
                    throw new ArgumentNullException();

                var theconnectedPerson = _mapper.Map<ConnectedPerson>(connectedPerson);

                var person = await _personrepo.GetById(id);

                if (person == null)
                {
                    _logger.LogWarning(Logevents.GetItemNotFound, "Get({Id}) NOT FOUND", id);

                    throw new NotFoundException();

                }

                person.ConectedPerson.Add(theconnectedPerson);

               await  _personrepo.Update(person);
          
           
                return Created(nameof(ConnectedPerson), connectedPerson);


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpDelete("Remove Connected Person")]
        public async Task<IActionResult> Remove(int connectedPersonId)
        {
            try { 
           
                _logger.LogInformation(Logevents.DeleteItem, "Delete Connectined Person {Id}", connectedPersonId);

                var theperson=await _connectedPersonrepo.GetById(connectedPersonId);
                
                if(theperson==null)
                {
                    _logger.LogWarning(Logevents.GetItemNotFound, "Get({Id}) NOT FOUND", connectedPersonId);


                    throw new  NotFoundException();
                }    

                await _connectedPersonrepo.Remove(connectedPersonId);



                return NoContent();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
           

        [HttpGet("Get Connected Persons")]
        public async Task<IActionResult> GetAll(int Personid)
        {
            try { 
            
                if (Personid <= 0)
                    throw new ArgumentNullException();


                var predicate = GenericExpressionTree.CreateWhereClause<ConnectedPerson>("ForeignKey", Personid);
                
                var connectedpersons = await _connectedPersonrepo.GetByQueryAsync(predicate);



                if (connectedpersons == null)
                {
                    _logger.LogWarning(Logevents.GetItemNotFound, "Get ({Id}) NOT FOUND", Personid);

                    return NotFound();
                }


                var theconnectedpersons = connectedpersons.Select(s =>
            new {
                 PersonType = s.PersonType.ToString(),
                 ConnectedPersonId= s.conectedpersonId,
                 id = s.Id,
             })
             .ToList();



                return Ok(theconnectedpersons);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
           



        }


    
}
