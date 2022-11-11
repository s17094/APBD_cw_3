namespace Crawler.Models;

public class Student
{
    public string FirstName { get; }
    public string LastName { get; }
    public string IndexNumber { get; set; }
    public string Birthdate { get; }
    public Studies Studies { get; }
    public string Email { get; }
    public string FathersName { get; }
    public string MothersName { get; }

    public Student(string firstName, string lastName, string indexNumber, string birthdate,
        Studies studies, string email, string fathersName, string mothersName)
    {
        FirstName = firstName;
        LastName = lastName;
        IndexNumber = indexNumber;
        Birthdate = birthdate;
        Studies = studies;
        Email = email;
        FathersName = fathersName;
        MothersName = mothersName;
    }

    public static Student? CreateStudent(int rowNumber, string studentInfo)
    {
        var studentParams = studentInfo.Split(",");
        if (studentParams.Length != 9)
        {
            return null;
        }

        var student = FetchStudent(studentParams);

        if (NonValid(student))
        {
            return null;
        }

        return student;
    }

    private static Student FetchStudent(IReadOnlyList<string> studentParams)
    {
        var firstName = studentParams[0].Trim();
        var lastName = studentParams[1].Trim();
        var indexNumber = studentParams[2].Trim();
        var birthdate = studentParams[3].Trim();
        var studies = new Studies(studentParams[4].Trim(), studentParams[5].Trim());
        var email = studentParams[6].Trim();
        var fathersName = studentParams[7].Trim();
        var mothersName = studentParams[8].Trim();

        return new Student(firstName, lastName, indexNumber, birthdate,
            studies, email, fathersName, mothersName);
    }

    private static bool NonValid(Student student)
    {
        return string.IsNullOrEmpty(student.FirstName) ||
               string.IsNullOrEmpty(student.LastName) ||
               string.IsNullOrEmpty(student.IndexNumber) ||
               string.IsNullOrEmpty(student.Birthdate) ||
               string.IsNullOrEmpty(student.Studies.Name) ||
               string.IsNullOrEmpty(student.Studies.Mode) ||
               string.IsNullOrEmpty(student.Email) ||
               string.IsNullOrEmpty(student.FathersName) ||
               string.IsNullOrEmpty(student.MothersName);
    }

    public override string ToString()
    {
        return FirstName +
               "," + LastName +
               "," + IndexNumber +
               "," + Birthdate +
               "," + Studies +
               "," + Email +
               "," + FathersName +
               "," + MothersName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IndexNumber);
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Student)obj);
    }

    private bool Equals(Student other)
    {
        return IndexNumber == other.IndexNumber;
    }

}