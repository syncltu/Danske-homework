using Danske.Homework.Application.Contracts.TextProcessing;
using Danske.Homework.Application.Exceptions;

namespace Danske.Homework.Application.Services.TextProcessing;

/// <summary>
/// Service for number parsing from string
/// </summary>
public class TextProcessingService : ITextProcessingService
{
    public IReadOnlyList<int> ConvertStringToNumbers(string input)
    {
        if (input is null)
        {
            throw new ArgumentNullException("input");
        }

        var splitStrings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var numbers = new int[splitStrings.Length];
        for (var i = 0; i < splitStrings.Length; i++)
        {
            if (int.TryParse(splitStrings[i], out var parsedNumber))
            {
                numbers[i] = parsedNumber;
            }
            else
            {
                throw new InvalidInputException($"Failed to parse '{splitStrings[i]}' as an integer.");
            }
        }
        return numbers;
    }
}