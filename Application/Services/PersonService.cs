using Domain.Entities;

public class PersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public Person GetPersonById(int id)
    {
        return _personRepository.GetPersonById(id);
    }
}