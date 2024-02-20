using Microsoft.AspNetCore.Mvc;
using SIS2Server.BLL.DTO.GroupDTO;
using SIS2Server.BLL.Services.Interfaces;

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
    public IActionResult Get()
    {
        return Ok(this._service.GetAll());
    }

    // GET api/<GroupController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(this._service.GetById(id));
    }

    // POST api/<GroupController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GroupCreateDto dto)
    {
        await this._service.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<GroupController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] GroupCreateDto dto)
    {
        await this._service.UpdateAsync(id, dto);
        return Ok();
    }

    // DELETE api/<GroupController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, bool soft)
    {
        await this._service.RemoveAsync(id, soft);
        return Ok();
    }
}
