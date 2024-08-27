using System.ComponentModel.DataAnnotations;

namespace AH.Database.Entities;

public class Person
{
    public required long Id { get; set; }
    [MaxLength(255)]
    public required string FirstName { get; set; }
    [MaxLength(255)]
    public required string LastName { get; set; }
}