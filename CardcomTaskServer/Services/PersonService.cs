using CardcomTaskServer.Interfaces;
using CardcomTaskServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardcomTaskServer.Services
{   

    public class PersonService : IPersonService
    {
        private PersonDBContext _personContext;

        public PersonService(PersonDBContext personContext)
        {
            this._personContext = personContext;
        }


        public async Task<bool> DeletePersonRecord(string personId)
        {
            try
            {
                this._personContext.Persons.Remove(new Person() { Id = personId });
                await this._personContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Person> GetAllRecordsFromDB()
        {
            List<Person> pList = this._personContext.Persons.ToList();

            return pList;
        }

        public async Task<bool> PostNewPersonRecord(Person person)
        {
            var result = await this._personContext.Persons.AddAsync(person);

            this._personContext.SaveChanges();

            return true;
        }

        public bool UpdateExistPersonRecord(Person person)
        {
            try
            {
                this._personContext.Persons.Update(person);
                this._personContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Person GetPersonRecord(string id)
        {
            try
            {
                return this._personContext.Persons.FirstOrDefault(person => person.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
