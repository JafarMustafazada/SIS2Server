using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS2Server.BLL.DTO.GroupDTO;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Constants;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIS2Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    IGroupService _service { get; }

    public GroupController(IGroupService service)
    {
        this._service = service;
    }

    // GET: api/<GroupController>
    [HttpGet]
    [Authorize(Roles = ConstRoles.AccessLevel3)]
    public IActionResult Get()
    {
        return Ok(this._service.GetAll());
    }

    // GET api/<GroupController>/5
    [HttpGet("{id}")]
    [Authorize(Roles = ConstRoles.AccessLevel3)]
    public IActionResult Get(int id)
    {
        return Ok(this._service.GetById(id));
    }

    // POST api/<GroupController>
    [HttpPost]
    [Authorize(Roles = ConstRoles.AccessLevel1)]
    public async Task<IActionResult> Post([FromBody] GroupCreateDto dto)
    {
        await this._service.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<GroupController>/5
    [HttpPut("{id}")]
    [Authorize(Roles = ConstRoles.AccessLevel1)]
    public async Task<IActionResult> Put(int id, [FromBody] GroupCreateDto dto)
    {
        await this._service.UpdateAsync(id, dto);
        return Ok();
    }

    // PUT api/<GroupController>/5/ModifyTeacher
    [HttpPut("{id}/ModifyTeacher")]
    [Authorize(Roles = ConstRoles.AccessLevel1)]
    public async Task<IActionResult> Put(int id, int teacherId, bool remove = false)
    {
        await this._service.AddTeacherAsync(teacherId, id, remove);
        return Ok();
    }

    // DELETE api/<GroupController>/5
    [HttpDelete("{id}")]
    [Authorize(Roles = ConstRoles.AccessLevel1)]
    public async Task<IActionResult> Delete(int id, bool soft)
    {
        await this._service.RemoveAsync(id, soft);
        return Ok();
    }
}
