using Persons.Models; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System; 
using System.Collections.Generic; 

namespace Persons.Controllers
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person Add(Person person);
        void Update(int id, Person person);
        void Delete(int id);
    }
}