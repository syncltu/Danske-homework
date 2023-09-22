namespace Danske.Homework.Application.Contracts.FileProcessing;

public interface IFileSavingService
{
    Task SaveNumbers(IEnumerable<int> numbers, string filePath);
}