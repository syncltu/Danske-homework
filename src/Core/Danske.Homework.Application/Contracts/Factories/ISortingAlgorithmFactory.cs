using Danske.Homework.Application.Contracts.Sorting;

namespace Danske.Homework.Application.Contracts.Factories;

/// <summary>
/// Used to get a sorting algorithm of choice
/// </summary>
public interface ISortingAlgorithmFactory
{
    ISortingService GetBubbleSortService();
    ISortingService GetMergeSortService();
    ISortingService GetQuickSortService();
    
}