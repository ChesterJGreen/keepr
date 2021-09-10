using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [ApiController]
    [Route("/api/[controller]")]
    public class KeepsController : ControllerBase
    {
    private readonly KeepsService _ks;

    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<List<Keep>> Get()
    {
    try
    {
        List<Keep> keeps = _ks.Get();
        return Ok(keeps);
    }
    catch (Exception err)
    {
        
        return BadRequest(err.Message);
    }
    }
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
        try
        {
            Keep keep = _ks.GetById(id);
            return Ok(keep);
        }
        catch (Exception err)
        {
            
            return BadRequest(err.Message);
        }
    }
    [HttpPost]
    // [Authorize]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
        try
        {
             Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
             newKeep.CreatorId = userInfo.Id;
             Keep created = _ks.Create(newKeep);
             return Ok(created);
        }
        catch (Exception err)
        {
            
            return BadRequest(err.Message);
        }
    }
  }
}