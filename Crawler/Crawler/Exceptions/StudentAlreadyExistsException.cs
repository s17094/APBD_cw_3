using Crawler.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crawler.Exceptions;

public class StudentAlreadyExistsException : StudentException
{
    private readonly string _index;

    public StudentAlreadyExistsException(string index)
    {
        _index = index;
    }

    protected internal override IActionResult GetResponse()
    {
        var errorMessage = new ErrorMessage("Student with index " + _index + " already exists.");
        return new ObjectResult(errorMessage)
        {
            StatusCode = 400
        };
    }
}