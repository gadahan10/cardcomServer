using CardcomTaskServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardcomTaskServer.Interfaces
{
    public interface IPersonModule
    {
        Task<bool> PostNewPersonRecord(Person person);

        IEnumerable<Person> GetAllRecords();

        Task<bool> DeletePersonRecord(string personId);

        bool UpdateExistPersonRecord(Person person);
    }
}
