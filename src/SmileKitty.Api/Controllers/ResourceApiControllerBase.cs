using Microsoft.AspNetCore.Mvc;
using SmileKitty.Domain.Resources;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.Infrastructure.Dto;
using SmileKitty.Infrastructure.QueryParameter;

namespace SmileKitty.Api.Controllers;

public abstract class ResourceApiControllerBase<TEntity, TQueryParameter, TDto>(
    IUnitOfWork<TEntity> unitOfWork
    , IWebHostEnvironment webHostEnvironment)
    : ApiControllerBase where TEntity : Resource, new()
    where TQueryParameter : IQueryParameter
    where TDto : DtoBase
{
    private readonly IUnitOfWork<TEntity> _unitOfWork = unitOfWork;
    private readonly IWebHostEnvironment _environment = webHostEnvironment;

    [HttpPost("upload")]
    public virtual async Task<IActionResult> UploadFile(IFormFile? file)
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

        var resource = new TEntity()
        {
            Name = file.FileName,
            Extension = extension,
            Url = resourceUri,
            Size = file.Length,
            MimeType = file.ContentType,
            Path = filePath
        };

        await _unitOfWork.InsertAsync(resource);
        await _unitOfWork.CommitAsync();

        return Ok(resource);
    }
}