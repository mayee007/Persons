using Persons.Models; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Data.Entity; 
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GenFu;


namespace Persons.Controllers 
{
    public class PersonService : IPersonService
    {
        private List<Person> Persons { get; set; }

        public PersonService()
        {
            var i = 0;
            //Persons = new List<Person>(50);
            Persons = A.ListOf<Person>(50);
            Persons.ForEach(person =>
            {
                i++;
                person.Id = i;
            });
        }

        public IEnumerable<Person> GetAll()
        {
            return Persons;
        }

        public Person Get(int id)
        {
            return Persons.First(_ => _.Id == id);
        }

        public Person Add(Person person)
        {
            var newid = Persons.OrderBy(_ => _.Id).Last().Id + 1;
            person.Id = newid;

            Persons.Add(person);

            return person;
        }

        public void Update(int id, Person person)
        {
            var existing = Persons.First(_ => _.Id == id);
            existing.FirstName = person.FirstName;
            existing.LastName = person.LastName;
            existing.Address = person.Address;
            existing.Age = person.Age;
            existing.City = person.City;
            existing.Email = person.Email;
            existing.Phone = person.Phone;
            existing.Title = person.Title;
        }

        public void Delete(int id)
        {
            var existing = Persons.First(_ => _.Id == id);
            Persons.Remove(existing);
        }
    }
}