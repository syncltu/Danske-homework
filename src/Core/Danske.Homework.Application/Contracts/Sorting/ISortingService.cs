namespace Danske.Homework.Application.Contracts.Sorting;

/// <summary>
/// Interface for sorting integers
/// </summary>
public interface ISortingService
{
    Task<IReadOnlyList<int>> GetSortedNumbers(IReadOnlyList<int> numbers);
}