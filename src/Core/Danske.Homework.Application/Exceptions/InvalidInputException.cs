namespace Danske.Homework.Application.Exceptions;

/// <summary>
/// Custom exception for invalid data parsed from string
/// </summary>
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message)
    {
        
    }
}