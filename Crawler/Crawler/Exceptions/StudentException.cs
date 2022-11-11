using Microsoft.AspNetCore.Mvc;

namespace Crawler.Exceptions;

public abstract class StudentException : Exception
{

    protected internal abstract IActionResult GetResponse();

}