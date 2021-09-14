using System;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace keepr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly VaultsService _vaultService;

    public AccountController(AccountService accountService, VaultsService vaultService)
    {
      _accountService = accountService;
      _vaultService = vaultService;
    }

    [HttpGet]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }
        [HttpGet("vaults")]
        public async Task<ActionResult<List<Vault>>> GetVaultsByCreatorId(string id)
        {
try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                String userId = userInfo.Id;
                List<Vault> vaults = _vaultService.GetVaultsByCreator(userId);
                return Ok(vaults);
            }
            catch (Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
    }


}