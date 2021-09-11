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
    // [Authorize]
    public class VaultKeepsController : ControllerBase
    {
    private readonly VaultKeepsService _vs;

    public VaultKeepsController(VaultKeepsService vs)
    {
      _vs = vs;
    }
    [HttpGet]
    public ActionResult<List<VaultKeep>> Get()
    {
        try
        {
            List<VaultKeep> vaultKeeps = _vs.GetAll();
            return Ok(vaultKeeps);
        }
        catch (Exception err)
        {
            
            return BadRequest(err.Message);
        }
    }
    [HttpPost]
        public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newVK)
    {
        try
        {
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            newVK.CreatorId = userInfo.Id;
            VaultKeep vaultKeep = _vs.Create(newVK);
            return Ok(vaultKeep); 
        }
         catch (Exception err)
        {
            
            return BadRequest(err.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<String>> Delete(int id)
    {
          try
        {
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            _vs.Delete(id, userInfo.Id);
            return Ok("Deleted Successfully"); 
        }
         catch (Exception err)
        {
            
            return BadRequest(err.Message);
        }
    }
  }
}