using Danske.Homework.Application.Contracts.FileProcessing;

namespace Danske.Homework.Application.Services.FileProcessing;

/// <summary>
/// Service used to reading file from directory
/// </summary>
public class FileReadingService : IFileReadingService
{
    public async Task<IEnumerable<int>> GetSavedNumbersAsync(string pathToFile)
    {
        try
        {
            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException("Full path to saved file does not exist", pathToFile);
            }

            var lines = await File.ReadAllLinesAsync(pathToFile);

            return lines.Select(int.Parse).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}