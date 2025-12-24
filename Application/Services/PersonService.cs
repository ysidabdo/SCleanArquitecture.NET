using Domain.Entities;

public class PersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person> GetPersonById(int id)
    {
        return await _personRepository.GetPersonById(id);
    }
}