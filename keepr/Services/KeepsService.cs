using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class KeepsService 
  {
      private readonly KeepsRepository _repo;
      private readonly VaultsRepository _vaultRepo;

    public KeepsService(KeepsRepository repo, VaultsRepository vaultRepo)
    {
      _repo = repo;
      _vaultRepo = vaultRepo;
    }

    internal List<Keep> Get()
    {
      return _repo.GetAll();
    }

    internal Keep GetById(int id, string userId)
    {
      Keep keep = _repo.GetById(id);
      if (keep == null)
      {
          throw new Exception("Invalid Id");
      }
      if (keep.CreatorId != userId)
      {
        keep.Views++;
        _repo.Edit(keep);
      }

      return keep;
    }
    
    internal List<VaultKeepViewModel> GetKeepsByVaultId(int id, string userId)
    {
      Vault vaultCheck = _vaultRepo.GetById(id);
      if (vaultCheck.IsPrivate != false)
      {
        if(vaultCheck.CreatorId != userId){
          throw new Exception("You do not have access");
        }
      } 
      return _repo.GetKeepsByVaultId(id);

    }
    internal List<Keep> GetKeepsByProfileId(string id)
    {
      return _repo.GetByProfileId(id);
    }
    internal List<Keep> GetKeeps(int vaultId)
    {
      return _repo.GetAll(vaultId);
    }

    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }


    internal Keep Edit(Keep editedKeep)
    {
        Keep original = GetById(editedKeep.Id, editedKeep.CreatorId);
        if (original.CreatorId != editedKeep.CreatorId)
        {
            throw new Exception("You do not have access");
        }
        original.Name = editedKeep.Name ?? original.Name;  
        original.Description = editedKeep.Description ?? original.Description;
        original.Img = editedKeep.Img ?? original.Img;
        _repo.Edit(original);
        return original;
    }


    internal void Delete(int keepId, string userId)
    {
      Keep keepToDelete = GetById(keepId, userId);
      if(keepToDelete.CreatorId != userId)
      {
          throw new Exception("You do not have access");
      }
      _repo.Delete(keepId);
      
    }

  }
}