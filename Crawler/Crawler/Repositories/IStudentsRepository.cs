using Crawler.Models;

namespace Crawler.Repositories;

public interface IStudentsRepository
{
    HashSet<Student> GetStudents();
    Student? GetStudent(string index);
    Student UpdateStudent(string index, Student updatedStudent);
    Student CreateStudent(Student newStudent);
    Student? DeleteStudent(string index);
}