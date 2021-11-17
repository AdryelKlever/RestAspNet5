using RestAspNet5.Models;
using System.Collections.Generic;

namespace RestAspNet5.Services
{
    public interface IPersonService
    {
        PersonModel Create(PersonModel person);

        PersonModel FindById(long id);

        List<PersonModel> FindAll();

        PersonModel Update(PersonModel person);

        void Delete(long id);

    }
}
