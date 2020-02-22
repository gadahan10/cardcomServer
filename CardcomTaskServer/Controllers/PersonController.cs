using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardcomTaskServer.Interfaces;
using CardcomTaskServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardcomTaskServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonModule _personModule;

        public PersonController(IPersonModule personModule)
        {
            this._personModule = personModule;
        }

        [HttpPost]
        [Route("AddNewPerson")]
        public async Task<IActionResult> AddNewPerson(Person person)
        {
            try
            {
                if (person != null)
                {
                    var isAdded = await this._personModule.PostNewPersonRecord(person);

                    return Ok(new { status = isAdded });
                }
                else
                {
                    throw new Exception();
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteExistPerson/{personId}")]
        public async Task<IActionResult> DeleteExistPerson(string personId)
        {
            if (!string.IsNullOrEmpty(personId)){
                var isDeleted = await this._personModule.DeletePersonRecord(personId);

                return Ok(new { status = isDeleted });
            }

            return NotFound();
        }

        [HttpGet]
        [Route("GetAllPersons")]
        public IEnumerable<Person> GetAllPersons()
        {
            try
            {
                IEnumerable<Person> personArray = this._personModule.GetAllRecords();
                return personArray;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpPut]
        [Route("UpdatePersonRecord")]
        public bool UpdatePersonRecord(Person person)
        {
            if (person != null)
            {
                var status = this._personModule.UpdateExistPersonRecord(person);
                return status;
            }

            return false;
            
        }
    }
}