using Microsoft.AspNetCore.Mvc;
using SIS2Server.BLL.DTO.FacultyDTO;
using SIS2Server.BLL.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIS2Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacultyController : ControllerBase
{
    IFacultyService _service {  get; }

    public FacultyController(IFacultyService service)
    {
        this._service = service;
    }

    // GET: api/<FacultyController>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(this._service.GetAll());
    }

    // GET api/<FacultyController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(this._service.GetById(id));
    }

    // POST api/<FacultyController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FacultyCreateDto dto)
    {
        await this._service.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<FacultyController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] FacultyCreateDto dto)
    {
        await this._service.UpdateAsync(id, dto);
        return Ok();
    }

    // PUT api/<FacultyController>/AddSubject/5
    [HttpPut("AddSubject/{id}")]
    public async Task<IActionResult> Put(int id, int subjectId, bool remove = false, int semester = 1)
    {
        await this._service.AddSubject(id, subjectId, remove, semester);
        return Ok();
    }

    // DELETE api/<FacultyController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, bool soft)
    {
        await this._service.RemoveAsync(id, soft);
        return Ok();
    }
}
