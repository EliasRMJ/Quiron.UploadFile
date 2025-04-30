## What is the Quiron.UploadFile?

A package used to easily upload files. It also allows them to be easily extended in your project.

## Give a Star! ⭐

If you find this project useful, please give it a star! It helps us grow and improve the community.

## Namespaces and Dependencies

- ✅ Quiron.UploadFile
- ✅ Microsoft.AspNetCore.Http

## Basic Usage

### Protected Properties
```csharp
protected virtual string[] AllowExtensions => ["image/jpeg", "image/png", "image/jpg"];
protected virtual long MaxSize => 5 * 1024 * 1024;
```

- ⚠️ You can override these properties when needed.

### One File
```csharp
public async virtual Task<string> File(IFormFile? file, params string[] folders)
{
    if (file is null)
        throw new UploadException("File not informed.");
        
    if (!AllowExtensions.Contains(file.ContentType))
        throw new UploadTypeException("Invalid file type. Please enter only currently allowed extensions.");
      
    if (file.Length > MaxSize)
        throw new UploadMaxSizeException($"The size of the file '{file.FileName}' exceeds the {MaxSize}MB limit.");
    
    var urlResult = string.Empty;

    try
    {
        var parentPath = Directory.GetParent(Directory.GetCurrentDirectory());
        var solutionPath = parentPath!.FullName;
        var pathOrigin = Path.Combine(solutionPath, folders.PathCombane());

        if (!Directory.Exists(pathOrigin)) Directory.CreateDirectory(pathOrigin);

        var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
        var filePath = Path.Combine(pathOrigin, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(stream);

        urlResult = Path.Combine(folders.PathCombane(), fileName);
    }
    catch (Exception ex)
    {
        throw new UploadException($"Error uploading file '{file.FileName}'.", ex);
    }

    return await Task.FromResult(urlResult);
}
```

### Multiple Files
```csharp
public async virtual Task<string[]> Files(IFormFile[]? files, params string[] folder)
{
    if (files is null || files.Length.Equals(0))
        throw new UploadException("Please provide at least 1 file to continue!");

    var urls = new string[files.Length];
    for (int i = 0; i < files.Length; i++)
        urls[i] = await this.File(files[i], folder);

    return urls;
}
```

## Compatibility

Supports:

- ✅ .NET Standard 2.1  
- ✅ .NET 9 through 9 (including latest versions)  
- ⚠️ Legacy support for .NET Core 3.1 and older (with limitations)
  
## About
Quiron.UploadFile was developed by [EliasRMJ](https://www.linkedin.com/in/elias-medeiros-98232066/) under the [MIT license](LICENSE).