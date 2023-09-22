using Danske.Homework.Application.Services.FileProcessing;
using FluentAssertions;

namespace Danske.Homework.Application.Tests.Services;

public class FileReadingServiceTests
{
    [Fact]
    public async Task GetSavedNumbersAsync_FileExists_ReturnsNumbers()
    {
        // arrange
        var tempFilePath = Path.GetTempFileName();
        
        //every number is in a new line I put "n" here. Sure it would take more space but its more readable. 
        //if files are larger, probably not a good way
        await File.WriteAllTextAsync(tempFilePath, "1\n2\n3\n4\n5");
        var fileReadingService = new FileReadingService();

        // act
        var numbers = await fileReadingService.GetSavedNumbersAsync(tempFilePath);

        // assert
        numbers.Should().Equal(1, 2, 3, 4, 5);
        File.Delete(tempFilePath); 
    }

    [Fact]
    public async Task GetSavedNumbersAsync_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        // arrange
        const string nonExistentFilePath = "non_existent_file.txt";
        var fileReadingService = new FileReadingService();

        // act 
        Func<Task> action = async () => await fileReadingService.GetSavedNumbersAsync(nonExistentFilePath);
        
        // assert
        await action.Should().ThrowAsync<FileNotFoundException>();
    }

    [Fact]
    public async Task GetSavedNumbersAsync_InvalidFileContent_ThrowsFormatException()
    {
        // arrange
        var tempFilePath = Path.GetTempFileName();
        await File.WriteAllTextAsync(tempFilePath, "1\n2\nabc\n4\n5");
        var fileReadingService = new FileReadingService();

        // act
        Func<Task> action = async () => await fileReadingService.GetSavedNumbersAsync(tempFilePath);
        
        //assert
        await action.Should().ThrowAsync<FormatException>()
            .WithMessage("The input string 'abc' was not in a correct format.");
        File.Delete(tempFilePath); 
    }
}