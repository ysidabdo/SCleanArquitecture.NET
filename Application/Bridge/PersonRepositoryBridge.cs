using Domain.Entities;

public class PersonRepositoryBridge : IPersonRepository
{
    private readonly PersonTableRepository _personTableRepository;

    public PersonRepositoryBridge(PersonTableRepository personTableRepository) 
    {
        _personTableRepository = personTableRepository;
    }

    public Person GetPersonById(int id)
    {
        var whereClause = $"Id = {id}";
        var result = _personTableRepository.GetAllPersonsWhere(whereClause);

       if (result is not Person person)
        {
            throw new InvalidOperationException("El resultado no es un Persona");
        }
        return person;
        
    }

    public void AddPerson(Person person)
    {
        throw new NotImplementedException();
    }

    public void DeletePerson(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdatePerson(Person person)
    {
        throw new NotImplementedException();
    }
}