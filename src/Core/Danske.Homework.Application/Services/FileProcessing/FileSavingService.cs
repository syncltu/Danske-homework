using Danske.Homework.Application.Contracts.FileProcessing;

namespace Danske.Homework.Application.Services.FileProcessing;

/// <summary>
/// Service used to save .txt file to directory
/// </summary>
public class FileSavingService : IFileSavingService
{
    //every number is in a new line. Sure it would take more space but its more readable. 
    //if files are larger, probably not a good way
    public async Task SaveNumbers(IEnumerable<int> numbers, string filePath)
    {
        try
        {
            using (var outputFile = new StreamWriter(filePath))
            {
                foreach (var number in numbers)
                {
                    await outputFile.WriteLineAsync(number.ToString());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}