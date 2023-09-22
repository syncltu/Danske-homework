using AutoFixture;
using Danske.Homework.Application.Services.FileProcessing;
using FluentAssertions;

namespace Danske.Homework.Application.Tests.Services;

public class FileSavingServiceTests
{
    private readonly Fixture _fixture;

    public FileSavingServiceTests()
    {
        _fixture = new Fixture();
    }
    [Fact]
    public async Task SaveNumbers_ValidNumbers_SavesToFile()
    {
        // arrange
        var tempFilePath = Path.GetTempFileName();
        var numbers = _fixture.CreateMany<int>(100).ToList();
        var fileSavingService = new FileSavingService();

        // act
        await fileSavingService.SaveNumbers(numbers, tempFilePath);
        var savedNumbers = await File.ReadAllLinesAsync(tempFilePath);
        var savedNumbersAsIntegers = savedNumbers.Select(int.Parse).ToList();
        // assert
        
        savedNumbersAsIntegers.Should().BeEquivalentTo(numbers);
        File.Delete(tempFilePath); 
    }

    [Fact]
    public async Task SaveNumbers_EmptyNumbers_SavesEmptyFile()
    {
        // arrange
        var tempFilePath = Path.GetTempFileName();
        var numbers = new List<int>();
        var fileSavingService = new FileSavingService();

        // act
        await fileSavingService.SaveNumbers(numbers, tempFilePath);

        // assert
        var savedNumbers = await File.ReadAllLinesAsync(tempFilePath);
        savedNumbers.Should().BeEmpty();
        File.Delete(tempFilePath); 
    }

    [Fact]
    public async Task SaveNumbers_NullFilePath_ThrowsArgumentNullException()
    {
        // arrange
        var numbers = new List<int> { 1, 2, 3 };
        var fileSavingService = new FileSavingService();

        // act
        var action = async () => await fileSavingService.SaveNumbers(numbers, null);
        
        // assert
        await action.Should().ThrowAsync<ArgumentNullException>();
    }
}