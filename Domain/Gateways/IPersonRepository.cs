using Domain.Entities;

public interface IPersonRepository
{
    Task<Person> GetPersonById(int id);
    Task AddPerson(Person person);
    Task UpdatePerson(Person person);
    Task DeletePerson(int id);
}