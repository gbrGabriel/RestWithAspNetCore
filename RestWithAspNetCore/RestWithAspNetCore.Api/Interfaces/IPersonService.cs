using RestWithAspNetCore.Api.Model;

namespace RestWithAspNetCore.Api.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAll();
        Task<Person> FindById(long id);
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task Delete(long id);
    }
}
