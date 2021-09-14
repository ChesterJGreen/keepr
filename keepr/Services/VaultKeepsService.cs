using System;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
      private readonly VaultKeepsRepository _repo;
      private readonly VaultsRepository _vaultRepo;
      private readonly KeepsRepository _keepRepo;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsRepository vaultRepo, KeepsRepository keepRepo)
    {
      _repo = repo;
      _vaultRepo = vaultRepo;
      _keepRepo = keepRepo;
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
      Keep toEdit = _keepRepo.GetById(vKToDelete.KeepId);
      toEdit.Keeps--;
      _keepRepo.KeepsChange(toEdit);
      
      _repo.Delete(id);
    }

  
  }
}