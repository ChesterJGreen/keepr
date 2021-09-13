using System;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
      private readonly VaultKeepsRepository _repo;
      private readonly VaultsRepository _vaultRepo;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsRepository vaultRepo)
    {
      _repo = repo;
      _vaultRepo = vaultRepo;
    }

    internal VaultKeep GetById(int id)
    {
      return _repo.GetByVkId(id);
    }

    
    internal VaultKeep Create(VaultKeep newVK)
    {
        Vault check = _vaultRepo.GetById(newVK.VaultId);
        if (check.CreatorId != newVK.CreatorId){
          throw new Exception("You do not have access");
        }

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