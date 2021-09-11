using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly AccountService _acctService;
        private readonly KeepsService _keepsService;
        private readonly VaultsService _vaultsService;

    public ProfilesController(AccountService acctService, KeepsService keepsService, VaultsService vaultsService)
    {
      _acctService = acctService;
      _keepsService = keepsService;
      _vaultsService = vaultsService;
    }

    [HttpGet("{id}")]
        public ActionResult<Profile> GetProfileById(String id)
        {
            try
            {
                Profile profile = _acctService.GetProfileById(id);
                return Ok(profile);
            }
            catch (Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}/keeps")]
        public ActionResult<List<Keep>> GetKeepsByProfileId(String id)
        {
try
            {
                List<Keep> keeps = _keepsService.GetKeepsByProfileId(id);
                return Ok(keeps);
            }
            catch (Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}/vaults")]
        public ActionResult<List<Vault>> GetVaultsByProfileId(String id)
        {
try
            {
                List<Vault> vaults = _vaultsService.GetVaultsByProfileId(id);
                return Ok(vaults);
            }
            catch (Exception err)
            {
                
                return BadRequest(err.Message);
            }
        }
  }
}