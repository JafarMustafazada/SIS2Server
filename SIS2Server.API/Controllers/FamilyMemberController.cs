using Microsoft.AspNetCore.Mvc;
using SIS2Server.BLL.DTO.FamilyMmemberDTO;
using SIS2Server.BLL.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIS2Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FamilyMemberController : ControllerBase
{
    IFamilyService _service {  get; }

    public FamilyMemberController(IFamilyService service)
    {
        this._service = service;
    }

    // //
    // GET: api/<FamilyMemberController>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(this._service.GetAll());
    }

    // GET: api/<FamilyMemberController>
    [HttpGet("Relations")]
    public IActionResult Relations()
    {
        return Ok(this._service.GetAllRelations());
    }

    // GET api/<FamilyMemberController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(this._service.GetById(id));
    }

    // POST api/<FamilyMemberController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FamilyMemberCreateDto dto)
    {
        await this._service.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<FamilyMemberController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] FamilyMemberCreateDto dto)
    {
        await this._service.UpdateAsync(id, dto);
        return StatusCode(StatusCodes.Status201Created);
    }

    // DELETE api/<FamilyMemberController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, bool soft)
    {
        await _service.RemoveAsync(id, soft);
        return Ok();
    }
}
