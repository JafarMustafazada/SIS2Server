using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS2Server.BLL.DTO.StudentDTO;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Constants;

namespace SIS2Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    IStudentService _service {  get; }

    public StudentController(IStudentService service)
    {
        this._service = service;
    }

    // //
    // GET: api/<StudentController>
    [HttpGet]
    [Authorize(Roles = ConstRoles.AccessLevel3)]
    public IActionResult Get(string groupName = "-")
    {
        return Ok(this._service.GetAll(groupName));
    }

    // GET api/<StudentController>/5
    [HttpGet("{id}")]
    [Authorize(Roles = ConstRoles.AccessLevel2)]
    public IActionResult Get(int id)
    {
        return Ok(this._service.GetById(id));
    }

    // GET api/<StudentController>/5/Score
    [HttpGet("{id}/Score")]
    [Authorize(Roles = ConstRoles.AccessLevel3)]
    public IActionResult Score(int id)
    {
        return Ok(this._service.GetAllScore(id));
    }

    // GET api/<StudentController>/5/Attendance
    [HttpGet("{id}/Attendance")]
    [Authorize(Roles = ConstRoles.AccessLevel3)]
    public IActionResult Attendance(int id)
    {
        return Ok(this._service.GetAllAttendance(id));
    }

    // POST api/<StudentController>
    [HttpPost]
    [Authorize(Roles = ConstRoles.AccessLevel1)]
    public async Task<IActionResult> Post([FromBody] StudentCreateDto dto)
    {
        await this._service.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<StudentController>/5
    [HttpPut("{id}")]
    [Authorize(Roles = ConstRoles.AccessLevel1)]
    public async Task<IActionResult> Put(int id, [FromBody] StudentCreateDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return Ok();
    }

    // DELETE api/<StudentController>/5
    [HttpDelete("{id}")]
    [Authorize(Roles = ConstRoles.AccessLevel1)]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.RemoveAsync(id);
        return Ok();
    }
}
