namespace Danske.Homework.Application.Contracts.FileProcessing;

public interface IFileReadingService
{
    Task<IEnumerable<int>> GetSavedNumbersAsync(string pathToFile);
}