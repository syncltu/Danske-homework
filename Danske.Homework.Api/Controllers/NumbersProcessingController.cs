using System.Net;
using Danske.Homework.Api.Controllers.Base;
using Danske.Homework.Application.Adapters;
using Danske.Homework.Application.Contracts.Directories;
using Danske.Homework.Application.Contracts.Factories;
using Danske.Homework.Application.Contracts.FileProcessing;
using Danske.Homework.Application.Contracts.TextProcessing;
using Microsoft.AspNetCore.Mvc;

namespace Danske.Homework.Api.Controllers;

public class NumbersProcessingController : BaseController
{
    private readonly ISortingAlgorithmFactory _sortingAlgorithmFactory;
    private readonly IFileSavingService _fileSavingService;
    private readonly IFileReadingService _fileReadingService;
    private readonly ITextProcessingService _textProcessingService;
    private readonly IDirectoryService _directoryService;

    public NumbersProcessingController(ISortingAlgorithmFactory sortingAlgorithmFactory,
        IFileSavingService fileSavingService,
        IFileReadingService fileReadingService,
        ITextProcessingService textProcessingService,
        IDirectoryService directoryService
    )
    {
        _sortingAlgorithmFactory = sortingAlgorithmFactory;
        _fileSavingService = fileSavingService;
        _fileReadingService = fileReadingService;
        _textProcessingService = textProcessingService;
        _directoryService = directoryService;
    }

    /// <summary>
    /// Saves a list of sorted numbers in directory
    /// </summary>
    /// <param name="input">String containing numbers only without commas, example "1 2 3 4 5 6"</param>
    /// <returns></returns>
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [HttpPost("save")]
    public async Task<ActionResult> Save(string input)
    {
        var directory = _directoryService.GetFullFilePath();
        var numbers = _textProcessingService.ConvertStringToNumbers(input);

        var mergeSortService = _sortingAlgorithmFactory.GetMergeSortService();
        var bubbleSortService = _sortingAlgorithmFactory.GetBubbleSortService();
        var quickSortService = _sortingAlgorithmFactory.GetQuickSortService();

        var mergeSortAdapter = new ExecutionTimeSortingAdapter(mergeSortService);
        var bubbleSortAdapter = new ExecutionTimeSortingAdapter(bubbleSortService);
        var quickSortAdapter = new ExecutionTimeSortingAdapter(quickSortService);

        await mergeSortAdapter.GetSortedNumbers(numbers);
        await bubbleSortAdapter.GetSortedNumbers(numbers);
        var quickSortedNumbers = await quickSortAdapter.GetSortedNumbers(numbers);


        await _fileSavingService.SaveNumbers(quickSortedNumbers, directory);

        var executionTimes = $"Merge sort took {mergeSortAdapter.TimeElapsed} ms. " +
                             $"Bubble sort took {bubbleSortAdapter.TimeElapsed} ms. " +
                             $"Quick sort took {quickSortAdapter.TimeElapsed} ms. ";
        return Ok(executionTimes);
    }

    /// <summary>
    /// Retrieves last saved list of numbers
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(typeof(IEnumerable<int>), (int)HttpStatusCode.OK)]
    [HttpGet("retrieve")]
    public async Task<ActionResult> Retrieve()
    {
        var directory = _directoryService.GetFullFilePath();
        var numbers = await _fileReadingService.GetSavedNumbersAsync(directory);
        return Ok(numbers);
    }
    
}