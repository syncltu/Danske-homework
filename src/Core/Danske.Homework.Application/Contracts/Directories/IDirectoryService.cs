namespace Danske.Homework.Application.Contracts.Directories;

/// <summary>
/// Used for .txt document directory implementation. 
/// </summary>
public interface IDirectoryService
{
    string GetFullFilePath();
}