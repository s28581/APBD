using APBDc3.Models.Base;

namespace APBDc3.Exceptions;

public class OverfillException : Exception
{
    public OverfillException()
    {
        Console.WriteLine("Containers is overfilled!!");
    }
}