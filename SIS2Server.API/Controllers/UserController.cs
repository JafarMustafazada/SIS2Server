using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS2Server.BLL.DTO.UserDTO;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Constants;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIS2Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    IAuthService _authService {  get; }

    public UserController(IAuthService authService)
    {
        this._authService = authService;
    }

    // POST api/<UserController>/Register
    [HttpPost("Register")]
    public async Task<IActionResult> Post([FromBody] RegisterDto dto)
    {
        await this._authService.Register(dto);
        return Ok();
    }

    // POST api/<UserController>/Login
    [HttpPost("Login")]
    public async Task<string> Post([FromBody] LoginDto dto)
    {
        return await this._authService.Login(dto);
    }

    // GET api/<UserController>/ConfirmRegistration
    [HttpGet("ConfirmRegistration")]
    public async Task<IActionResult> Get(string token)
    {
        if (await this._authService.ConfirmRegistration(token)) return Ok();
        else return Problem();
    }

    // GET api/<UserController>/ConfirmRegistration
    [HttpGet("ChangeUserRole")]
    [Authorize(Roles = ConstRoles.AccessLevel0)]
    public async Task<IActionResult> Get(string username, ConstRoles.UserRoles role)
    {
        await this._authService.ChangeUserRole(username, role);
        return Ok(true);
    }

    // GET api/<UserController>/SetConstantEducationRole
    [HttpGet("SetConstantEducationRole")]
    [Authorize(Roles = ConstRoles.AccessLevel1)]
    public async Task<IActionResult> Get(string username, ConstRoles.EducationRoles role, int entityId)
    {
        await this._authService.AddEducationRoleOnce(username, role, entityId);
        return Ok(true);
    }
}
