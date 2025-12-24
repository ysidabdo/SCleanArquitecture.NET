using Domain.Entities;

public class PersonRepositoryBridge : IPersonRepository
{
    private readonly PersonTableRepository _personTableRepository;

    public PersonRepositoryBridge(PersonTableRepository personTableRepository) 
    {
        _personTableRepository = personTableRepository;
    }

    public async Task<Person> GetPersonById(int id)
    {
        var whereClause = $"Id = {id}";
        var result = await _personTableRepository.GetAllPersonsWhere(whereClause);
        var dbEntity = result.FirstOrDefault();

        if (dbEntity is null)
            throw new KeyNotFoundException($"Person with Id {id} not found");
      
        return dbEntity.MapToDomainEntity();
        
    }

    public async Task AddPerson(Person person)
    {
        throw new NotImplementedException();
    }

    public async Task DeletePerson(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePerson(Person person)
    {
        throw new NotImplementedException();
    }

  
}