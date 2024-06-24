using System.Reflection.Metadata.Ecma335;

namespace tests.Models;

public class Doctor
{
    public Doctor(int idDoctor, string firstName, string lastName, string email)
    {
        IdDoctor = idDoctor;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public int IdDoctor { set; get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}