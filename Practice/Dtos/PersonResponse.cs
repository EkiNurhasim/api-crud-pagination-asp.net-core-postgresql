using System;
using System.ComponentModel.DataAnnotations;
using Practice.Entities;

namespace Practice.Dtos;

public class PersonResponse
{     
    [Required]
    public Guid Id { get; set; }

    [Required]
    [MinLength(2)]
    public required string Name { get; set; }

    [Range(17, 150)]
    public int? Age { get; set; }
    
    public DateOnly? DateOfBirth { get; set; }
        
    public Address? Address { get; set; }
}
