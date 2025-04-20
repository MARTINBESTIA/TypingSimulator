namespace Uniza.CSharp.Lab.Delegates
{
    public record Person(string FirstName, string LastName, DateOnly Birthdate)
    {
        public string FullName => $"{FirstName} {LastName}";

        public override string ToString() => $"{FullName} ({Birthdate:dd.MM.yyyy})";
    }
}
