using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Entities;

public class Address
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("country", TypeName = "VARCHAR")]
    public required string Country { get; set; }


    [Column("city", TypeName = "VARCHAR")]
    public string? City { get; set; }

    [Column("postalCode", TypeName = "VARCHAR")]
    public string? PostalCode { get; set; }
}
