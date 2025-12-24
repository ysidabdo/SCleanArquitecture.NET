using Domain.Entities;
using Infraestructure.DBRepositories;

public static class PersonMapper
{
  public static Person MapToDomainEntity(this PersonDbEntity dbEntity)
    {
        return new Person(dbEntity.FirstName, dbEntity.LastName, dbEntity.Age);
    }
}