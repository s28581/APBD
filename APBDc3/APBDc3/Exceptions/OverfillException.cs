using APBDc3.Models.Base;

namespace APBDc3.Exceptions;

public class OverfillException : Exception
{
    public OverfillException() : base(string.Format("Container is overfilled!!"))
    {
        
    }
}