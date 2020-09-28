using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IG.Core.Data.Entities;
using IG.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using service.server.Exceptions;
using service.server.HelperClasses;

namespace service.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {

        private readonly IRepo<Person> _personrepo;

        private readonly IMapper _mapper;
        private readonly ILogger<PictureController> _logger;

        public PictureController(ILogger<PictureController> logger, IRepo<Person> personrepo, IMapper mapper)
        {
            _personrepo = personrepo;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("Add  Person Picture")]
        public async Task<IActionResult> Add(int id,IFormFile formFile)
        {
            try
            {

                _logger.LogInformation(Logevents.GetItem, "Add Picture  {Id}", id);

                var person = await _personrepo.GetById(id);

                if (person == null)
                {
                _logger.LogWarning(Logevents.GetItemNotFound, "Get ({Id}) NOT FOUND", id);

                    throw new NotFoundException(nameof(id));


                }

                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    
                    var picture= ms.ToArray();


                    person.Picture = picture;
                    
                }

               var p= await _personrepo.Update(person);


                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        [HttpDelete("Remove Persons Picture")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                _logger.LogInformation(Logevents.GetItem, "Remove Picture   {Id}", id);

                if (id <= 0)
                    throw new ArgumentNullException(nameof(id));


                var person = await _personrepo.GetById(id);


                if (person == null)
                {

                _logger.LogWarning(Logevents.GetItemNotFound, "Get({Id}) NOT FOUND", id);

                     throw new  NotFoundException(nameof(id));
                }


                person.Picture = null;

               var result= await _personrepo.Update(person);
               
                if(result!=null)
                return NoContent();

                throw new  InvalidOperationException().InnerException;

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }



        }

        [HttpPost("Update  Person Picture")]
        public async Task<IActionResult> Update(int id, IFormFile formFile)
        {
            try
            {
                _logger.LogInformation(Logevents.UpdateItem, "Update  Picture {Id}", id);

                var person = await _personrepo.GetById(id);

                if(person==null)
                {

                _logger.LogWarning(Logevents.GetItemNotFound, "Get({Id}) NOT FOUND", id);

                    throw new NotFoundException(nameof(id));


                }

                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);

                  person.Picture = ms.ToArray();


                    await _personrepo.Update(person);


                }


                await _personrepo.Update(person);

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
}
