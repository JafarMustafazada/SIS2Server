using Microsoft.AspNetCore.Mvc;
using SIS2Server.BLL.DTO.UserDTO;
using SIS2Server.BLL.Services.Interfaces;

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

    // POST api/<UserController>/ConfirmRegistration
    [HttpGet("ConfirmRegistration")]
    public async Task<IActionResult> Get(string token)
    {
        if (await this._authService.ConfirmRegistration(token)) return Ok();
        else return Problem();
    }

    // PUT api/<UserController>/jhonny
    //[HttpPut("{userName}")]
    //public void Put(string userName, [FromBody] string newEmail)
    //{
    //}

    // DELETE api/<UserController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
