using Microsoft.AspNetCore.Mvc;
using SmileKitty.Domain.Resources;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Resources;

public class ImageResourceController(IUnitOfWork<ImageResource> unitOfWork, IWebHostEnvironment webHostEnvironment)
    : ApiControllerBase
{
    private readonly IUnitOfWork<ImageResource> _unitOfWork = unitOfWork;
    private readonly IWebHostEnvironment _environment = webHostEnvironment;

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile? file, [FromQuery]int width = 512, [FromQuery] int height = 512)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var extension = Path.GetExtension(file.FileName);
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var resourceUri = $"/uploads/{fileName}";

        var resource = new ImageResource()
        {
            Name = file.FileName,
            Extension = extension,
            Url = resourceUri,
            Size = file.Length,
            MimeType = file.ContentType,
            Path = filePath,
            Width = width,
            Height = height
        };

        await _unitOfWork.InsertAsync(resource);
        await _unitOfWork.CommitAsync();

        return Ok(resource);
    }
}