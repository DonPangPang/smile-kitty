using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileKitty.Application.Contracts.Users.Dtos;
using SmileKitty.Application.Contracts.Users.QueryParameters;
using SmileKitty.AutoMapper;
using SmileKitty.Domain.Resources;
using SmileKitty.Domain.Users;
using SmileKitty.EntityFrameworkCore.UnitOfWorks;

namespace SmileKitty.Api.Controllers;

public class UserController(IUnitOfWork<User> unitOfWork) : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserQueryParameter parameter)
    {
        var res = await unitOfWork.Queryable.Map<User, UserDto>().ToListAsync();

        return Ok(res);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var res = await unitOfWork.Queryable.Map<User, UserDto>().FirstOrDefaultAsync(x => x.Id == id);

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserDto dto)
    {
        var user = dto.MapTo<User>();
        user.CreateUser();
        await unitOfWork.CommitAsync(user);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserDto dto)
    {
        var user = await unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (user is null) return await Add(dto);

        user.UpdateUser(dto.Name, dto.Email, dto.Phone, dto.Avatar?.MapTo<AvatarResource>(), dto.Description);

        await unitOfWork.CommitAsync(user);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await unitOfWork.Queryable.FirstOrDefaultAsync(x => x.Id == id);
        if (user is null) return NotFound();

        user.DeleteUser();

        await unitOfWork.CommitAsync(user);

        return Ok();
    }
}