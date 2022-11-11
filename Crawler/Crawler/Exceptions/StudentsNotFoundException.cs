using Crawler.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crawler.Exceptions;

public class StudentsNotFoundException : StudentException
{
    protected internal override IActionResult GetResponse()
    {
        var errorMessage = new ErrorMessage("Students not found.");
        return new ObjectResult(errorMessage)
        {
            StatusCode = 404
        };
    }
}