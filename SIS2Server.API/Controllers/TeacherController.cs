using Microsoft.AspNetCore.Mvc;
using SIS2Server.BLL.DTO.SubjectDTO;
using SIS2Server.BLL.DTO.TeacherDTO;
using SIS2Server.BLL.ExternalServices.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Constants;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIS2Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    ITeacherService _service { get; }
    IConfiguration _configuration { get; }
    ITokenService _tokenService { get; }

    public TeacherController(ITeacherService service, IConfiguration configuration, ITokenService tokenService)
    {
        this._service = service;
        this._configuration = configuration;
        this._tokenService = tokenService;
    }

    // GET: api/<TeacherController>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(this._service.GetAll());
    }

    // GET api/<TeacherController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(this._service.GetById(id));
    }

    // POST api/<TeacherController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TeacherCreateDto dto)
    {
        await this._service.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<TeacherController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TeacherCreateDto dto)
    {
        await this._service.UpdateAsync(id, dto);
        return Ok();
    }

    // PUT api/<TeacherController>/5
    [HttpPut("AddSubject/{id}")]
    public async Task<IActionResult> Put(int id, int subjectId, bool remove = false)
    {
        await this._service.AddSubjectAsync(id, subjectId, remove);
        return Ok();
    }

    // DELETE api/<TeacherController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, bool soft)
    {
        await this._service.RemoveAsync(id, soft);
        return Ok();
    }

    // PUT api/<TeacherController>/Score
    [HttpPut("Score")]
    public async Task<IActionResult> Put(bool asAdmin, [FromBody] SubjectScoreDto dto)
    {
        string token = Request.Headers.Authorization
            .First(x => x.StartsWith(this._configuration["Token:Scheme"])).Split(' ').Last();

        IEnumerable<Claim> claims = this._tokenService.GetClaims(token);

        if (asAdmin)
        {
            if (claims.Any(x => x.Type == this._configuration["RoleClaim"]
            && (ConstRoles.AccessLevel1.Split(',').Contains(x.Value))))
            {
                await this._service.ModifyScore(dto);
                return Ok();
            }
            else return StatusCode(StatusCodes.Status401Unauthorized);

        }
        else
        {
            if (this._service.ConfirmTeacher(claims.First(x => x.Type == "UserName").Value,
                dto.SubjectId, dto.StudentId)) return Problem();

            await this._service.ModifyScore(dto);

            return Ok();
        }
    }

    // PUT api/<TeacherController>/Attendance
    [HttpPut("Attendance")]
    public async Task<IActionResult> Put(bool asAdmin, [FromBody] SubjectAttendanceDto dto)
    {
        string token = Request.Headers.Authorization
            .First(x => x.StartsWith(this._configuration["Token:Scheme"])).Split(' ').Last();

        IEnumerable<Claim> claims = this._tokenService.GetClaims(token);

        if (asAdmin)
        {
            if (claims.Any(x => x.Type == this._configuration["RoleClaim"] 
            && (ConstRoles.AccessLevel1.Split(',').Contains(x.Value))))
            {
                await this._service.ModifyAttendanc(dto);
                return Ok();
            }
            else return StatusCode(StatusCodes.Status401Unauthorized);

        }
        else
        {
            if (this._service.ConfirmTeacher(claims.First(x => x.Type == "UserName").Value,
                dto.SubjectId, dto.StudentId)) return Problem();

            await this._service.ModifyAttendanc(dto);

            return Ok();
        }
    }
}
