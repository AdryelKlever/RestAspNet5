using RestAspNet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAspNet5.Services.Implementations
{
    
    public class PersonServiceImplemetation : IPersonService
    {
        private volatile int count;

        public PersonModel Create(PersonModel person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<PersonModel> FindAll()
        {
            List<PersonModel> persons = new List<PersonModel>();
            for (int i = 0; i < 8; i++) 
            {
                PersonModel person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public PersonModel FindById(long id)
        {
            return new PersonModel
            {
                Id = IncrementAndGet(),
                FirstName = "Adryel",
                LastName = "Almeida",
                Address = "Núcleo Bandeirantes - Brasília DF",
                Gender = "Male"
            };
        }

        public PersonModel Update(PersonModel person)
        {
            return person;
        }

        private PersonModel MockPerson(int i)
        {
            return new PersonModel
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person Last Name " + i,
                Address = "Some Address " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
