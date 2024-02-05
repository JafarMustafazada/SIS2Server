using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIS2Server.Core.Constants;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIS2Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    // GET: api/<StudentController>
    [HttpGet]
    //[Authorize(Roles = Roles.AccessLevel2)]
    public IEnumerable<string> Get(string group = "-", string sort = "asc")
    {
        return new string[] { group, sort };
    }

    // GET api/<StudentController>/5
    [HttpGet("{id}")]
    [Authorize(Roles = Roles.AccessLevel1)]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<StudentController>
    [HttpPost]
    [Authorize(Roles = Roles.AccessLevel3)]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<StudentController>/5
    [HttpPut("{id}")]
    [Authorize(Roles = Roles.AccessLevel2)]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<StudentController>/5
    [HttpDelete("{id}")]
    [Authorize(Roles = Roles.AccessLevel3)]
    public void Delete(int id)
    {
    }
}
