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

    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }
  }
}