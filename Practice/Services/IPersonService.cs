using System;
using Practice.Dtos;

namespace Practice.Services;

public interface IPersonService
{
    public Task<IEnumerable<PersonResponse>> GetPersons();
    public Task<PersonResponse?> GetPersonById(Guid id);
    public Task<PersonResponse> CreatePerson(PersonRequest personRequest);
    public Task<PersonResponse?> UpdatePerson(Guid id, PersonRequest personRequest);
    public Task<bool> DeletePerson(Guid id);
    public Task<Pageable<PersonResponse>> PaginationPerson(int page, int size );
}
