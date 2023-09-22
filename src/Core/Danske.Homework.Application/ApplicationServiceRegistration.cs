using Danske.Homework.Application.Contracts.Directories;
using Danske.Homework.Application.Contracts.Factories;
using Danske.Homework.Application.Contracts.FileProcessing;
using Danske.Homework.Application.Contracts.TextProcessing;
using Danske.Homework.Application.Factories;
using Danske.Homework.Application.Services.Directories;
using Danske.Homework.Application.Services.FileProcessing;
using Danske.Homework.Application.Services.TextProcessing;
using Microsoft.Extensions.DependencyInjection;

namespace Danske.Homework.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IFileReadingService, FileReadingService>();
        services.AddScoped<IFileSavingService, FileSavingService>();
        services.AddScoped<ISortingAlgorithmFactory, SortingAlgorithmFactory>();
        services.AddScoped<IDirectoryService, DirectoryService>();
        services.AddScoped<ITextProcessingService, TextProcessingService>();
        return services;
    }
}