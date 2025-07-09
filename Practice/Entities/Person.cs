using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Practice.Entities;

[Index(nameof(AddressId), IsUnique = true)]
public class Person
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MinLength(2)]
    [Column("name", TypeName = "VARCHAR")]
    public required string Name { get; set; }

    [Range(17, 150)]
    [Column("age", TypeName = "INTEGER")]
    public int? Age { get; set; }

    [Column("dateOfBirth", TypeName = "DATE")]
    public DateOnly? DateOfBirth { get; set; }

    public int? AddressId { get; set; }

    [ForeignKey("AddressId")]
    public Address? Address { get; set; }

}
