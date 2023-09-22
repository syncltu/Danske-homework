using Danske.Homework.Application.Contracts.Directories;

namespace Danske.Homework.Application.Services.Directories;

/// <summary>
/// Service used to determine path to related files
/// </summary>
public class DirectoryService : IDirectoryService
{
    public string GetFullFilePath()
    {
        var tempFolderPath = Path.GetTempPath();
        
        var folderPath = Path.Combine(tempFolderPath, "Danske_Homework");
        
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        var filePath = Path.Combine(folderPath, "Numbers.txt");
        return filePath;
    }
}