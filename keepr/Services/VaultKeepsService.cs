using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
      private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    internal List<VaultKeep> GetAll()
    {
      return _repo.GetAll();
    }
    internal List<VaultKeep> GetByVaultId(int id, string userId)
    {
        List<VaultKeep> foundVK = _repo.GetByVaultId(id);
        if (foundVK == null)
        {
            throw new Exception("Invalid Id");
        }
        return foundVK;
    }
      internal VaultKeep GetByVKId(int id)
    {
      return _repo.GetByVkId(id);
    }

    internal VaultKeep Create(VaultKeep newVK)
    {
      
        return _repo.Create(newVK);
    }

    internal void Delete(int id, string accountId)
    {
      VaultKeep vKToDelete = GetByVKId(id);
      if (vKToDelete.CreatorId != accountId)
      {
          throw new Exception("Invalid Access");
      }
      _repo.Delete(id);
    }

  
  }
}