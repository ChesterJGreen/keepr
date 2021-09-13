using System;
using System.Collections.Generic;
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
    public class VaultsController : ControllerBase
    {
    private readonly VaultsService _vs;
    private readonly VaultKeepsService _vkService;
    private readonly KeepsService _ks;

    public VaultsController(VaultsService vs, VaultKeepsService vkService, KeepsService ks)
    {
      _vs = vs;
      _vkService = vkService;
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<List<Vault>> Get()
    {
        try
        {
            List<Vault> vaults = _vs.GetAll();
            return Ok(vaults);
        }
        catch (Exception err)
        {
            
            return BadRequest(err.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> Get(int id)
    {
           try
        {
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            String userId = userInfo?.Id;
            Vault vault = _vs.GetById(id, userId);
            return Ok(vault);
        }
        catch (Exception err)
        {
            
            return BadRequest(err.Message);
        }
    }
    [HttpGet("{id}/keeps")]
    
    public async Task<ActionResult<List<VaultKeepViewModel>>> GetKeepsByVaultId(int id)
    {
        try
        {
             Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
             String userId = userInfo?.Id;
             List<VaultKeepViewModel> keeps = _ks.GetKeepsByVaultId(id, userId);
             return Ok(keeps);
        }
        catch (Exception err)
        {
            
            return  BadRequest(err.Message);
        }
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
    {
        try
        {
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            newVault.CreatorId = userInfo.Id;
            Vault created = _vs.Create(newVault);
            return Ok(created);
        }
        catch (Exception err)
        {
            
            return BadRequest(err.Message);
        }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault editedVault)
    {
        try
        {
            Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
            editedVault.Id = id;
            Vault edited = _vs.Edit(editedVault, userInfo.Id);
            return Ok(edited);
        }
        catch (Exception err)
        {
            
            return BadRequest(err.Message);
        }
    }
    [HttpDelete("{id}")]
    [Authorize]
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