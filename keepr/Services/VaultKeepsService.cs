using System;
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
    internal VaultKeep GetById(int id)
    {
      return _repo.GetByVkId(id);
    }

    
    internal VaultKeep Create(VaultKeep newVK)
    {
      
        return _repo.Create(newVK);
    }

    internal void Delete(int id, string accountId)
    {
      VaultKeep vKToDelete = GetById(id);
      if (vKToDelete.CreatorId != accountId)
      {
          throw new Exception("Invalid Access");
      }
      _repo.Delete(id);
    }

  
  }
}