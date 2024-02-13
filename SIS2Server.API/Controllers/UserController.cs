﻿using Microsoft.AspNetCore.Mvc;
using SIS2Server.BLL.DTO.UserRelatedDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIS2Server.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    // GET: api/<UserController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<UserController>/Register
    [HttpPost("Register")]
    public IActionResult Post([FromBody] RegisterDto dto)
    {
        return Ok(dto);
    }

    // POST api/<UserController>/Register
    [HttpGet("ConfirmRegistration")]
    public IActionResult Get(string token)
    {
        return Ok();
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
