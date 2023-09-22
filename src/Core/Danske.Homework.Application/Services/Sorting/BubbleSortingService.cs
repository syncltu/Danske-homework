using Danske.Homework.Application.Contracts.Sorting;

namespace Danske.Homework.Application.Services.Sorting;

public class BubbleSortingService : ISortingService
{
    public async Task<IReadOnlyList<int>> GetSortedNumbers(IReadOnlyList<int> numbers)
    {
        if (numbers.Count <= 1)
        {
            return numbers;
        }

        var numbersList = new List<int>(numbers);

        await BubbleSortAsync(numbersList);

        return numbersList;
    }

    private Task BubbleSortAsync(IList<int> numbers)
    {
        var count = numbers.Count;
        for (var i = 0; i < count - 1; i++)
        {
            var wasSwapped = false;

            for (var j = 0; j < count - i - 1; j++)
            {
                if (numbers[j] <= numbers[j + 1])
                {
                    continue;
                }
                (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                wasSwapped = true;
            }
            if (!wasSwapped)
            {
                break;
            }
        }

        return Task.CompletedTask;
    }
}