using CardcomTaskServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardcomTaskServer.Interfaces
{
    public interface IPersonService
    {
        Task<bool> PostNewPersonRecord(Person person);

        IEnumerable<Person> GetAllRecordsFromDB();

        Task<bool> DeletePersonRecord(string personId);

        bool UpdateExistPersonRecord(Person person);

        Person GetPersonRecord(string id);
    }
}
