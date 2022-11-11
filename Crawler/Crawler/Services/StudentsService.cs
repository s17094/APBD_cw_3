using System.Text.RegularExpressions;
using Crawler.Exceptions;
using Crawler.Models;
using Crawler.Repositories;

namespace Crawler.Services;

public class StudentsService : IStudentsService
{
    private const string StudentIndexRegex = "s\\d{1,6}";
    private static readonly Regex StudentIndexPattern = new(StudentIndexRegex, RegexOptions.IgnoreCase);

    private readonly IStudentsRepository _studentsRepository;

    public StudentsService(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public HashSet<Student> GetStudents()
    {
        var students = _studentsRepository.GetStudents();
        if (students.Count == 0)
        {
            throw new StudentsNotFoundException();
        }
        return _studentsRepository.GetStudents();
    }

    public Student GetStudent(string index)
    {
        var student = _studentsRepository.GetStudent(index);
        if (student == null)
        {
            throw new StudentNotFoundException(index);
        }

        return student;
    }

    public Student UpdateStudent(string index, Student updatedStudent)
    {
        var student = _studentsRepository.GetStudent(index);
        if (student == null)
        {
            throw new StudentNotFoundException(index);
        }
        return _studentsRepository.UpdateStudent(index, updatedStudent);
    }

    public Student CreateStudent(Student newStudent)
    {
        if (Exists(newStudent))
        {
            throw new StudentAlreadyExistsException(newStudent.IndexNumber);
        }

        if (BadIndexNumber(newStudent))
        {
            throw new StudentBadIndexNumberException(newStudent.IndexNumber);
        }

        return _studentsRepository.CreateStudent(newStudent);
    }

    private bool Exists(Student newStudent)
    {
        try
        {
            GetStudent(newStudent.IndexNumber);
            return true;
        }
        catch (StudentNotFoundException ex)
        {
            return false;
        }
    }

    private bool BadIndexNumber(Student newStudent)
    {
        return !StudentIndexPattern
            .Match(newStudent.IndexNumber)
            .Success;
    }

    public Student DeleteStudent(string index)
    {
        var student = _studentsRepository.DeleteStudent(index);
        if (student == null)
        {
            throw new StudentNotFoundException(index);
        }

        return student;
    }
}