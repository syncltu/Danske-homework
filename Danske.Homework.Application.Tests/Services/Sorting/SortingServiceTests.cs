using AutoFixture;
using Danske.Homework.Application.Contracts.Sorting;
using Danske.Homework.Application.Services.Sorting;
using FluentAssertions;

namespace Danske.Homework.Application.Tests.Services.Sorting;

public class SortingServiceTests
{
    private readonly Fixture _fixture;

    public SortingServiceTests()
    {
        _fixture = new Fixture();
    }

    public static IEnumerable<object[]> SortingServicesTestData()
    {
        yield return new object[] { new BubbleSortingService() };
        yield return new object[] { new QuickSortingService() };
        yield return new object[] { new MergeSortingService() };
    }

    [Theory]
    [MemberData(nameof(SortingServicesTestData))]
    public async Task GetSortedNumbers_EmptyList_ReturnsEmptyList(ISortingService sortingService)
    {
        // arrange
        var emptyList = new List<int>();

        // act
        var sortedNumbers = await sortingService.GetSortedNumbers(emptyList);

        // assert
        sortedNumbers.Should().BeEmpty();
    }

    [Theory]
    [MemberData(nameof(SortingServicesTestData))]
    public async Task GetSortedNumbers_SingleElementList_ReturnsSameList(ISortingService sortingService)
    {
        // arrange
        var singleElementList = new List<int> { 999 };

        // act
        var sortedNumbers = await sortingService.GetSortedNumbers(singleElementList);

        // assert
        sortedNumbers.Should().Equal(singleElementList);
    }

    [Theory]
    [MemberData(nameof(SortingServicesTestData))]
    public async Task GetSortedNumbers_UnsortedList_ReturnsSortedList(ISortingService sortingService)
    {
        // arrange
        var unsortedList = _fixture.CreateMany<int>(100).ToList();

        // act
        var sortedNumbers = await sortingService.GetSortedNumbers(unsortedList);

        // assert
        sortedNumbers.Should().Equal(unsortedList.OrderBy(x => x));
    }
}