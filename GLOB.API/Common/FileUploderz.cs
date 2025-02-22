using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Apps.Common;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GLOB.Common.API;
[ApiExplorerSettings(IgnoreApi = true)]
public class FileUploderz : AlphaController<FileUploderz>
{
  private readonly IWebHostEnvironment hostEnv;
  private string storageFiles = "/assets/ouz";
  public FileUploderz(
  ILogger<FileUploderz> logger,
  IMapper mapper,
  IWebHostEnvironment hostingEnvironment
  ) :

  base(logger, mapper)
  {
    hostEnv = hostingEnvironment;
  }
  // Async Methods Cannot have output parameters
  // Don't use this methods
  public async Task<IActionResult> UploadFile(IFormFile file, string fileName)
  {
    if (file == null || file.Length == 0) return BadRequest("Invalid file");

    // Specify the directory where you want to save the file
    //var uploadDirectory = "D:/Directory";
    var uploadDirectory = hostEnv.ContentRootPath + storageFiles;
    Console.WriteLine(hostEnv.ContentRootPath);

    // Create the directory if it doesn't exist
    if (!Directory.Exists(uploadDirectory))
      Directory.CreateDirectory(uploadDirectory);

    // Generate a unique file name (e.g., using a Guid)
    string extension = Path.GetExtension(file.FileName);
    string allowedExtensions = ".png .jpeg .webp .jpg";
    if (allowedExtensions.IndexOf(extension) == -1)
    {
      return FileInvalid($"Invalid File Type {file.FileName} Only {allowedExtensions} allowed");
    }
    fileName += Guid.NewGuid().ToString() + extension;

    // Combine the directory and file name to get the full path
    var filePath = Path.Combine(uploadDirectory, fileName);

    // Save the file to the specified path
    using (var stream = new FileStream(filePath, FileMode.Create))
    {
      await file.CopyToAsync(stream);
    }
    return Ok(this.storageFiles + "/" + fileName);
  }

  public async Task<IActionResult> UploadFileReflection(
  IFormFile file,
  string propertyName,
  object obj
  )
  {
    if (file == null || file.Length == 0) return BadRequest("Invalid file");

    // Specify the directory where you want to save the file
    //var uploadDirectory = "D:/Directory";
    var uploadDirectory = hostEnv.ContentRootPath + storageFiles;
    Console.WriteLine(hostEnv.ContentRootPath);

    // Create the directory if it doesn't exist
    if (!Directory.Exists(uploadDirectory))
      Directory.CreateDirectory(uploadDirectory);

    // Generate a unique file name (e.g., using a Guid)
    string extension = Path.GetExtension(file.FileName);
    string allowedExtensions = ".png .jpeg .webp .jpg";
    if (allowedExtensions.IndexOf(extension) == -1)
    {
      return FileInvalid($"Invalid File Type {file.FileName} Only {allowedExtensions} allowed");
    }
    PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
    propertyName += Guid.NewGuid().ToString() + extension;

    // Combine the directory and file name to get the full path
    var filePath = Path.Combine(uploadDirectory, propertyName);

    // Save the file to the specified path
    using (var stream = new FileStream(filePath, FileMode.Create))
    {
      await file.CopyToAsync(stream);
    }
    // Assign Property Value using Reflection
    if (propertyInfo != null)
    {
      propertyInfo.SetValue(obj, this.storageFiles + "/" + propertyName);
    }
    return Ok("Worked Correctly");
  }
}