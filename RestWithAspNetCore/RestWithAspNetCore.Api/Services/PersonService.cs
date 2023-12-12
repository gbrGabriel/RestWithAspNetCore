using RestWithAspNetCore.Api.Interfaces;
using RestWithAspNetCore.Api.Model;

namespace RestWithAspNetCore.Api.Services
{
    public class PersonService : IPersonService
    {
        public Task<Person> Create(Person person)
        {
            return Task.FromResult(person);
        }

        public Task Delete(long id)
        {
            return Task.CompletedTask;
        }

        public Task<List<Person>> FindAll()
        {
            return Task.FromResult(new List<Person> {new Person
            {
                Id = 1,
                FirstName = "Gabriel",
                LastName = "Silva",
                Address = "Irineu",
                Gender = "Male"
            } });
        }

        public Task<Person> FindById(long id)
        {
            return Task.FromResult(new Person
            {
                Id = id,
                FirstName = "Gabriel",
                LastName = "Silva",
                Address = "Irineu",
                Gender = "Male"
            });
        }

        public Task<Person> Update(Person person)
        {
            return Task.FromResult(person);
        }
    }
}
