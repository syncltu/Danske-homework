using System.Diagnostics;
using Danske.Homework.Application.Contracts.Sorting;

namespace Danske.Homework.Application.Adapters;

/// <summary>
/// Adapter is used to capture ISortingService and wrap it with additional time elapsed functionality 
/// </summary>
public class ExecutionTimeSortingAdapter
{
    private readonly ISortingService _innerService;
    public double TimeElapsed { get; private set; }

    public ExecutionTimeSortingAdapter(ISortingService innerService)
    {
        _innerService = innerService ?? throw new ArgumentNullException(nameof(innerService));
    }

    public async Task<IReadOnlyList<int>> GetSortedNumbers(IReadOnlyList<int> numbers)
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        var sortedNumbers = await _innerService.GetSortedNumbers(numbers);

        stopwatch.Stop();

        TimeElapsed =Math.Round(stopwatch.Elapsed.TotalMilliseconds,3);
        return sortedNumbers;
    }
}