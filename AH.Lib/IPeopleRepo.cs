using AH.Database.Entities;

namespace AH.Lib;

public interface IPeopleRepo
{
    Task<IEnumerable<Person>> GetPeopleAsync();
    void Dispose();
}