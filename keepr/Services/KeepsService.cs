using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class KeepsService 
  {
      private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    internal List<Keep> Get()
    {
      return _repo.GetAll();
    }

    internal Keep GetById(int id)
    {
        Keep keep = _repo.GetById(id);
        if (keep == null)
        {
            throw new Exception("Invalid Id");
        }
      return keep;
    }
    internal List<Keep> GetKeepsByProfileId(string id)
    {
      return _repo.GetByProfileId(id);
    }

    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }


    internal Keep Edit(Keep editedKeep)
    {
        Keep original = GetById(editedKeep.Id);
        if (original.CreatorId != editedKeep.CreatorId)
        {
            throw new Exception("You do not have access");
        }
        original.Name = editedKeep.Name ?? original.Name;  
        original.Description = editedKeep.Description ?? original.Description;
        original.Img = original.Img ?? original.Img;
        _repo.Edit(original);
        return original;
    }


    internal void Delete(int keepId, string userId)
    {
      Keep keepToDelete = GetById(keepId);
      if(keepToDelete.CreatorId != userId)
      {
          throw new Exception("You do not have access");
      }
      _repo.Delete(keepId);
      
    }
  }
}