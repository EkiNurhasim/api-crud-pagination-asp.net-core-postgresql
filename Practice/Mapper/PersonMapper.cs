using System;
using Practice.Dtos;
using Practice.Entities;

namespace Practice.Mapper;

public static class PersonMapper
{
    public static PersonResponse ToPersonResponseDTO(this Person person)
    {
        PersonResponse result = new PersonResponse()
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age,
            DateOfBirth = person.DateOfBirth,
            Address = person.Address != null ? new Address()
            {
                Id = person.Address.Id,
                Country = person.Address.Country,
                City = person.Address.City,
                PostalCode = person.Address.PostalCode
            } : null
        };

        return result;
    }

    public static Person ToPersonEntity(this PersonRequest personRequest)
    {
        Person result = new()
        {
            Id = Guid.NewGuid(),
            Name = personRequest.Name,
            Age = personRequest.Age,
            DateOfBirth = personRequest.DateOfBirth,
            AddressId = personRequest.AddressId,
        };

        return result;
    }
}
