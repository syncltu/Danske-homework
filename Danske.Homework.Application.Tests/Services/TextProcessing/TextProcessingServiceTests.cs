using Danske.Homework.Application.Exceptions;
using Danske.Homework.Application.Services.TextProcessing;
using FluentAssertions;

namespace Danske.Homework.Application.Tests.Services.TextProcessing;

public class TextProcessingServiceTests
{
    [Fact]
    public void ConvertStringToNumbers_ValidInput_ReturnsNumbers()
    {
        // arrange
        var textProcessingService = new TextProcessingService();

        // act
        var numbers = textProcessingService.ConvertStringToNumbers("1 2 3 4 5");

        // assert
        numbers.Should().Equal(1, 2, 3, 4, 5);
    }

    [Fact]
    public void ConvertStringToNumbers_InvalidInput_ThrowsInvalidInputException()
    {
        // arrange
        var textProcessingService = new TextProcessingService();

        // act
        Action action = () => textProcessingService.ConvertStringToNumbers("1 2 abc 4 5");
        
        //assert
        action.Should().Throw<InvalidInputException>()
            .WithMessage("Failed to parse 'abc' as an integer.");
    }

    [Fact]
    public void ConvertStringToNumbers_EmptyInput_ReturnsEmptyArray()
    {
        // arrange
        var textProcessingService = new TextProcessingService();

        // act
        var numbers = textProcessingService.ConvertStringToNumbers("");

        // assert
        numbers.Should().BeEmpty();
    }

    [Fact]
    public void ConvertStringToNumbers_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        var textProcessingService = new TextProcessingService();

        // act
        Action action = () => textProcessingService.ConvertStringToNumbers(null);
        
        //assert 
        action.Should().Throw<ArgumentNullException>();
    }
}