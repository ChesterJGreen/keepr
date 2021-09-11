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

    internal Vault GetById(int id)
    {
        Vault vault = _repo.GetById(id);
        if(vault == null || vault.IsPrivate == true)
        {
            throw new Exception("Invalid Id");
        }
      return vault;
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

    internal Vault Edit(Vault editedVault)
    {
      Vault original = GetById(editedVault.Id);
      if (original.CreatorId != editedVault.CreatorId)
      {
          throw new Exception("Invalid Access");
      }
      original.Name = editedVault.Name ?? original.Name;
      original.Description = editedVault.Description ?? original.Description;
      original.IsPrivate = editedVault.IsPrivate !=null ? editedVault.IsPrivate : original.IsPrivate;
      return _repo.Edit(editedVault);
    }

    internal void Delete(int vaultId, string userId)
    {
      Vault vaultToDelete = GetById(vaultId);
      if(vaultToDelete.CreatorId != userId)
      {
        throw new Exception("You do not have access");
      }
      _repo.Delete(vaultId);
    }
  }
}