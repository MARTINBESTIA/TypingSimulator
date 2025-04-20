// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;

public class Person {
    private string _firstName;
    public int Age { get; init; }
    public DateTime? Birthday { get; init; } 
    public string FirstName { get; init; }
    public string FullName { get; init; }
    public Gender Gender { get; init; }
    public string LastName { get; init; }

    public Person() { }
    public Person(string firstName, string lastName, DateTime? birthday, Gender gender = Gender.UNKNOWN) {  
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        Gender = gender;
    }

    public bool Equals(object obj) { 
        return this == (Person)obj;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {Gender} {Age} ";
    }




}

public enum Gender
{
    UNKNOWN,
    MALE,
    FEMALE
}