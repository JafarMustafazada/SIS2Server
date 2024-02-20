using Microsoft.AspNetCore.Mvc;
using SIS2Server.BLL.DTO.TeacherDTO;
using SIS2Server.BLL.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIS2Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    ITeacherService _service { get; }

    public TeacherController(ITeacherService service)
    {
        this._service = service;
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
}
