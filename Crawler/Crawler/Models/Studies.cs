namespace Crawler.Models;

public record Studies(string Name, string Mode)
{
    public override string ToString()
    {
        return Name + "," + Mode;
    }
}

