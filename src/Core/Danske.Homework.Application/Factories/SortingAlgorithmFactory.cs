using Danske.Homework.Application.Contracts.Factories;
using Danske.Homework.Application.Contracts.Sorting;
using Danske.Homework.Application.Services.Sorting;

namespace Danske.Homework.Application.Factories;

public class SortingAlgorithmFactory : ISortingAlgorithmFactory
{
    public ISortingService GetBubbleSortService()
    {
        return new BubbleSortingService();
    }

    public ISortingService GetMergeSortService()
    {
        return new MergeSortingService();
    }

    public ISortingService GetQuickSortService()
    {
        return new QuickSortingService();
    }
}