using System;
using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Dtos;
using Practice.Entities;
using Practice.Mapper;

namespace Practice.Services;

public class PersonService : IPersonService
{
    private readonly ApplicationContext _context;

    public PersonService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PersonResponse>> GetPersons()
    {
        List<PersonResponse>? response = await _context.Persons.Include(p => p.Address).Select(p => p.ToPersonResponseDTO()).AsNoTracking().ToListAsync();
        return response;
    }

    public async Task<PersonResponse?> GetPersonById(Guid id)
    {
        Person? response = await _context.Persons.Include(address => address.Address).FirstOrDefaultAsync(person => person.Id == id);
        return response?.ToPersonResponseDTO();
    }

    public async Task<PersonResponse> CreatePerson(PersonRequest personRequest)
    {
        Person person = personRequest.ToPersonEntity();
        _context.Persons.Add(person);
        await _context.SaveChangesAsync();

        return person.ToPersonResponseDTO();
    }

    public async Task<PersonResponse?> UpdatePerson(Guid id, PersonRequest personRequest)
    {
        Person? response = await _context.Persons.Include(person => person.Address).FirstOrDefaultAsync(person => person.Id == id);
        if (response is not null)
        {
            response.Name = personRequest.Name;
            response.Age = personRequest.Age;
            response.DateOfBirth = personRequest.DateOfBirth;
            response.AddressId = personRequest.AddressId;
            await _context.SaveChangesAsync();
        }

        return response?.ToPersonResponseDTO();
    }

    public async Task<bool> DeletePerson(Guid id)
    {
        Person? response = await _context.Persons.FindAsync(id);
        if (response is not null)
        {
            _context.Persons.Remove(response);
            await _context.SaveChangesAsync();
        }

        return response == null ? false : true;
    }

    public async Task<Pageable<PersonResponse>> PaginationPerson(int page, int size)
    {
        int totalRecords = await _context.Persons.CountAsync();
        int skip = (page - 1) * size;
        int totalPage = (int)Math.Ceiling((double)totalRecords / size);

        List<Person> people = await _context.Persons.Skip(skip).Take(size).Include(person => person.Address).ToListAsync();
        Pageable<PersonResponse> response = new()
        {
            Page = page,
            Size = size,
            TotalPages = totalPage,
            TotalRecords = totalRecords,
            Data = people.Select(person => person.ToPersonResponseDTO())
        };

        return response;
    }
}
