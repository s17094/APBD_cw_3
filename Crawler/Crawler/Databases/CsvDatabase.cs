using System.Text;
using Crawler.Exceptions;
using Crawler.Models;

namespace Crawler.Databases;

public class CsvDatabase : IDatabase
{
    private const string DatabaseFile = "database.csv";

    public CsvDatabase()
    {
        if (!File.Exists(DatabaseFile))
        {
            File.Create(DatabaseFile);
        }
    }

    public HashSet<Student> GetStudents()
    {
        var studentsMap = LoadStudentsFromCsv();
        return studentsMap.Values.ToHashSet();
    }

    private Dictionary<string, Student> LoadStudentsFromCsv()
    {
        var studentCsvReader = new StreamReader(new FileInfo(DatabaseFile).OpenRead());
        var students = new Dictionary<string, Student>();
        var rowNumber = 1;
        while (studentCsvReader.ReadLine() is { } line)
        {
            var student = Student.CreateStudent(rowNumber, line);
            if (student != null)
            {
                students.Add(student.IndexNumber, student);
            }

            rowNumber++;
        }

        studentCsvReader.Close();

        return students;
    }

    public Student? GetStudent(string index)
    {
        var studentsMap = LoadStudentsFromCsv();
        return studentsMap.GetValueOrDefault(index);
    }

    public Student UpdateStudent(string index, Student updatedStudent)
    {
        var studentsMap = LoadStudentsFromCsv();
        if (studentsMap.ContainsKey(index))
        {
            studentsMap.Remove(index);
            updatedStudent.IndexNumber = index;
            studentsMap.Add(index, updatedStudent);
            var result = new StringBuilder();
            foreach (var student in studentsMap.Values)
            {
                result.AppendLine(student.ToString());
            }
            File.WriteAllText(DatabaseFile, result.ToString());
            return updatedStudent;
        }
        else
        {
            throw new StudentNotFoundException(index);
        }
    }

    public Student CreateStudent(Student newStudent)
    {
        var studentsMap = LoadStudentsFromCsv();
        studentsMap.Add(newStudent.IndexNumber, newStudent);
        var result = new StringBuilder();
        foreach (var student in studentsMap.Values)
        {
            result.AppendLine(student.ToString());
        }
        File.WriteAllText(DatabaseFile, result.ToString());
        return newStudent;
    }

    public Student? DeleteStudent(string index)
    {
        var studentsMap = LoadStudentsFromCsv();
        var deletedStudent = studentsMap.GetValueOrDefault(index);
        studentsMap.Remove(index);
        var result = new StringBuilder();
        foreach (var student in studentsMap.Values)
        {
            result.AppendLine(student.ToString());
        }
        File.WriteAllText(DatabaseFile, result.ToString());
        return deletedStudent;
    }

}