using Crawler.Databases;
using Crawler.Models;

namespace Crawler.Repositories;

public class StudentsRepository : IStudentsRepository
{

    private readonly IDatabase _database;

    public StudentsRepository(IDatabase database)
    {
        _database = database;
    }

    public HashSet<Student> GetStudents()
    {
        return _database.GetStudents();
    }

    public Student? GetStudent(string index)
    {
        return _database.GetStudent(index);
    }

    public Student UpdateStudent(string index, Student updatedStudent)
    {
        return _database.UpdateStudent(index, updatedStudent);
    }

    public Student CreateStudent(Student newStudent)
    {
        return _database.CreateStudent(newStudent);
    }

    public Student? DeleteStudent(string index)
    {
        return _database.DeleteStudent(index);
    }
}