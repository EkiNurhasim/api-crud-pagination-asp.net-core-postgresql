using System;
using System.ComponentModel.DataAnnotations;

namespace Practice.Dtos;

public class PersonRequest
{   
    [Required]
    [MinLength(2)]
    public required string Name { get; set; }

    [Range(17, 150)]
    public int? Age { get; set; }
    
    public DateOnly? DateOfBirth { get; set; }
        
    public int? AddressId { get; set; }
}
