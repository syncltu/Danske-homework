using Danske.Homework.Application.Contracts.Sorting;

namespace Danske.Homework.Application.Services.Sorting;

public class QuickSortingService : ISortingService
{
    public async Task<IReadOnlyList<int>> GetSortedNumbers(IReadOnlyList<int> numbers)
    {
        if (numbers.Count == 1)
        {
            return numbers;
        }

        var numbersList = new List<int>(numbers);

        await QuickSortAsync(numbersList, 0, numbersList.Count - 1);

        return numbersList;
    }

    private async Task QuickSortAsync(List<int> numbers, int low, int high)
    {
        if (low < high)
        {
            var pivotIndex = await PartitionAsync(numbers, low, high);

            await QuickSortAsync(numbers, low, pivotIndex - 1);
            await QuickSortAsync(numbers, pivotIndex + 1, high);
        }
    }

    private Task<int> PartitionAsync(List<int> numbers, int low, int high)
    {
        var pivot = numbers[high];
        var i = low - 1;

        for (var j = low; j < high; j++)
        {
            if (numbers[j] > pivot)
            {
                continue;
            }

            i++;

            (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
        }

        (numbers[i + 1], numbers[high]) = (numbers[high], numbers[i + 1]);

        return Task.FromResult(i + 1);
    }
}