using Crawler.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crawler.Exceptions;

public class StudentNotFoundException : StudentException
{

    private readonly string _index;

    public StudentNotFoundException(string index)
    {
        _index = index;
    }

    protected internal override IActionResult GetResponse()
    {
        var errorMessage = new ErrorMessage("Student with index " + _index + " not found.");
        return new ObjectResult(errorMessage)
        {
            StatusCode = 404
        };
    }
}