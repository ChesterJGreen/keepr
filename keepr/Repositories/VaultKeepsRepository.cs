using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
      private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<VaultKeep> GetAll()
    {
      throw new NotImplementedException();
    }

    internal VaultKeep Create(VaultKeep newVK)
    {
        string sql = @"
        INSERT INTO vaultKeeps
        (keepId, VaultId, creatorId)
        VALUES
        (@KeepId, @VaultId, @CreatorId);
        SELECT LAST_INSERT_INTO();
        ";
        newVK.Id = _db.ExecuteScalar<int>(sql, newVK);
        return GetByVkId(newVK.Id);
    }

    internal List<VaultKeep> GetByKeepId(int id)
    {
      string sql = "SELECT * FROM vaultKeeps WHERE keepId = @id;";
      return _db.Query<VaultKeep>(sql, new { id }).ToList();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }

    internal VaultKeep GetByVkId(int id)
    {
      string sql = @"
      SELECT
      a.*,
      vk.*
      FROM vaultKeeps vk
      JOIN accounts a ON a.id = vk.creatorId
      WHERE vk.id = @id;";
    
      return _db.Query<Profile, VaultKeep, VaultKeep>(sql, (prof, vk) =>
      {
          vk.Creator = prof;
          return vk;
      }, new { id }, splitOn: "id").FirstOrDefault();
    }
  }
}