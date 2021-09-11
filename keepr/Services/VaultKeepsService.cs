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
    internal VaultKeep GetById(int id)
    {
        VaultKeep found = _repo.GetById(id);
        if (found == null)
        {
            throw new Exception("Invalid Id");
        }
        return found;
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