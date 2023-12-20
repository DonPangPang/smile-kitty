using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Api.Exceptions;
using SmileKitty.Application.Contracts.Users.UserAuthorizations;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Users;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers.Users;

public class UserAuthorizationController(IUnitOfWork<UserAuthorization> unitOfWork)
    : CrudeApiControllerBase<UserAuthorization, UserAuthorizationQueryParameter, UserAuthorizationDto, UserAuthorizationAddDto, UserAuthorizationUpdateDto>(unitOfWork)
{
    private readonly IUnitOfWork<UserAuthorization> _unitOfWork = unitOfWork;

    public override async Task<IActionResult> Get(UserAuthorizationQueryParameter parameter)
    {
        var res = await _unitOfWork.Queryable.Map<UserAuthorization, UserAuthorizationDto>().ToListAsync();

        return Ok(res);
    }

    [Obsolete]
    public override Task<IActionResult> Update(UserAuthorizationUpdateDto dto)
    {
        throw new SmileKittyNotSupportException();
    }

    [Obsolete]
    public override Task<IActionResult> Delete(Guid id)
    {
        throw new SmileKittyNotSupportException();
    }

    [HttpGet]
    public async Task<IActionResult> ChangePassword(UserAuthorizationUpdateDto updateDto)
    {
        var userAuthorization = await _unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == updateDto.Id);
        if (userAuthorization is null) return NotFound();

        if (userAuthorization.Password != updateDto.OldPassword) return BadRequest("warn old password");
        userAuthorization.ChangePassword(updateDto.NewPassword);

        await _unitOfWork.UpdateAsync(userAuthorization);
        await _unitOfWork.CommitAsync();

        return Ok();
    }
}