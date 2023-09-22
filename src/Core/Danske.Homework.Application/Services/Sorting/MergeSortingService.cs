using Danske.Homework.Application.Contracts.Sorting;

namespace Danske.Homework.Application.Services.Sorting;

public class MergeSortingService : ISortingService
{
    public async Task<IReadOnlyList<int>> GetSortedNumbers(IReadOnlyList<int> numbers)
    {
        if (numbers.Count <= 1)
        {
            return numbers;
        }

        var numbersList = new List<int>(numbers);

        await MergeSortAsync(numbersList, 0, numbersList.Count - 1);

        return numbersList;
    }

    private async Task MergeSortAsync(List<int> numbers, int low, int high)
    {
        if (low < high)
        {
            var mid = (low + high) / 2;

            await MergeSortAsync(numbers, low, mid);
            await MergeSortAsync(numbers, mid + 1, high);

            await MergeAsync(numbers, low, mid, high);
        }
    }

    private Task MergeAsync(IList<int> numbers, int low, int mid, int high)
    {
        var leftSize = mid - low + 1;
        var rightSize = high - mid;

        var leftList = new List<int>(leftSize);
        var rightList = new List<int>(rightSize);

        for (var i = 0; i < leftSize; i++)
        {
            leftList.Add(numbers[low + i]);
        }

        for (var i = 0; i < rightSize; i++)
        {
            rightList.Add(numbers[mid + 1 + i]);
        }

        var leftIndex = 0;
        var rightIndex = 0;
        var k = low;

        while (leftIndex < leftSize && rightIndex < rightSize)
        {
            if (leftList[leftIndex] <= rightList[rightIndex])
            {
                numbers[k++] = leftList[leftIndex++];
            }
            else
            {
                numbers[k++] = rightList[rightIndex++];
            }
        }

        while (leftIndex < leftSize)
        {
            numbers[k++] = leftList[leftIndex++];
        }

        while (rightIndex < rightSize)
        {
            numbers[k++] = rightList[rightIndex++];
        }

        return Task.CompletedTask;
    }
}