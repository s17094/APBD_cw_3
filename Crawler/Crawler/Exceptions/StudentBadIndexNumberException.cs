using Crawler.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crawler.Exceptions;

public class StudentBadIndexNumberException : StudentException
{
    private readonly string _index;

    public StudentBadIndexNumberException(string index)
    {
        _index = index;
    }

    protected internal override IActionResult GetResponse()
    {
        var errorMessage = new ErrorMessage("BadIndexFormat, current index: " + _index + ", expected: " + "s\\d{1,5}");
        return new ObjectResult(errorMessage)
        {
            StatusCode = 400
        };
    }
}