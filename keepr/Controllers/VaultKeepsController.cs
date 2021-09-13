using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class VaultKeepsController : ControllerBase
    {
    private readonly VaultKeepsService _vs;

    public VaultKeepsController(VaultKeepsService vs)
    {
      _vs = vs;
    }
    
    [HttpPost]
    [Authorize]
        public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newVK)
    {
        try
        {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            newVK.CreatorId = userInfo.Id;
            VaultKeep created = _vs.Create(newVK);
            return Ok(created); 
        }
         catch (Exception err)
        {
            
            return BadRequest(err.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Delete(int id)
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