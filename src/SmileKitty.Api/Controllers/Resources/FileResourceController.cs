using SmileKitty.Application.Contracts.Resources;
using SmileKitty.Domain.Resources;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Api.Controllers.Resources;

public class FileResourceController(IUnitOfWork<FileResource> unitOfWork, IWebHostEnvironment webHostEnvironment)
    : ResourceApiControllerBase<FileResource, ResourceQueryParameter, FileResourceDto>(unitOfWork, webHostEnvironment)
{
    private readonly IUnitOfWork<FileResource> _unitOfWork = unitOfWork;
}