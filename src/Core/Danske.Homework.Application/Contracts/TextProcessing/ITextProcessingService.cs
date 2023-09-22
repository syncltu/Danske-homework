namespace Danske.Homework.Application.Contracts.TextProcessing;

/// <summary>
/// Interface for parsing numbers from input string
/// </summary>
public interface ITextProcessingService
{
    IReadOnlyList<int> ConvertStringToNumbers(string input);
}