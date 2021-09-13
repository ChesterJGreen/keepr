using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal List<Vault> GetAll()
    {
        List<Vault> vaults = _repo.GetAll();
        return vaults.FindAll(v => v.IsPrivate == false);

    }

    internal Vault GetById(int id, String userId)
    {

        Vault found = _repo.GetById(id);
        if(found == null)
        {
          throw new Exception("Invalid Id");
        }
        if(found.CreatorId != userId && found.IsPrivate == true)
          {
            throw new Exception("No access");
          }
          
          return found;
        }
        
      
    
    internal List<Vault> GetVaultsByProfileId(String id)
    {
      return _repo.GetVaultsByProfileId(id);
    }
     internal List<Vault> GetVaultsByCreator(string creatorId, bool isPrivate= false)
    {
      List<Vault> vaults = _repo.GetAll(creatorId);
      if (isPrivate)
      {
        vaults = vaults.FindAll(b => b.IsPrivate == true);
      }
      return vaults;
    }

    internal Vault Create(Vault newVault)
    {
       return _repo.Create(newVault);
    }

    internal Vault Edit(Vault editedVault, String userId)
    {
      Vault original = GetById(editedVault.Id, userId);
      original.Name = editedVault.Name ?? original.Name;
      original.Description = editedVault.Description ?? original.Description;
      original.IsPrivate = editedVault.IsPrivate !=null ? editedVault.IsPrivate : original.IsPrivate;
      return _repo.Edit(editedVault);
    }

    internal void Delete(int vaultId, string userId)
    {
      Vault vaultToDelete = GetById(vaultId, userId);
      if(vaultToDelete.CreatorId != userId)
      {
        throw new Exception("You do not have access");
      }
      _repo.Delete(vaultId);
    }

  }
}