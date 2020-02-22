using CardcomTaskServer.Interfaces;
using CardcomTaskServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardcomTaskServer.Modules
{   

    public class PersonModule : IPersonModule
    {
        private IPersonService _personService;
        private Regex NumericRegexPattern = new Regex(@"^[0-9]+$");
        private Regex LettersRegexPattern = new Regex(@"^[A-Za-z ]+$");
        private Regex EmailRegexPattern = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");      
        

        public PersonModule(IPersonService personService)
        {
            this._personService = personService;
        }


        public  IEnumerable<Person> GetAllRecords()
        {
            try
            {
               var result = this._personService.GetAllRecordsFromDB();

                return result;
            }
            catch (Exception)
            {

                throw new NotImplementedException(); 
            }
            
        }

        public async Task<bool> PostNewPersonRecord(Person person)
        {
            // Verify person data is valid
            if (VerifyPersonData(person)){
                var status = await this._personService.PostNewPersonRecord(person);

                return status;
            }

            return false;
        }

        public async Task<bool> DeletePersonRecord(string personId)
        {
            try
            {
                if (!string.IsNullOrEmpty(personId))
                {
                    var result = await this._personService.DeletePersonRecord(personId);

                    return true;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
           
        }

        public bool UpdateExistPersonRecord(Person person)
        {
            // Get the person record to change
            Person existPerson = this._personService.GetPersonRecord(person.Id);

            //Edit the person with new data
            if (existPerson != null)
            {
                existPerson.Name = person.Name;
                existPerson.Email = person.Email;
                existPerson.Phone = person.Phone;
                existPerson.DateOfBirth = person.DateOfBirth;
                existPerson.Gender = person.Gender;
            }

            // Update in DB via the service
            var res = this._personService.UpdateExistPersonRecord(existPerson);

            return res;
        }

        private bool VerifyPersonData(Person person)
        {
            // 1. Verify name contains only letters
            // 2. Verify name length is 5+
            // 3. Verify email address pattern
            // 4. Verify id and phone contains only numbers

            if (person != null && person.Name.Length >= 5 && this.LettersRegexPattern.IsMatch(person.Name) && 
                this.NumericRegexPattern.IsMatch(person.Id) && this.NumericRegexPattern.IsMatch(person.Phone) &&
                this.EmailRegexPattern.IsMatch(person.Email))
            {
                return true;
            }

            return false;
        }
    }
}
