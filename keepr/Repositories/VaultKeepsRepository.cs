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
        SELECT LAST_INSERT_ID();
        ";
        newVK.Id = _db.ExecuteScalar<int>(sql, newVK);
        return GetByVkId(newVK.Id);
    }

    internal List<VaultKeep> GetByVaultId(int id)
    {
      string sql = "SELECT * FROM vaultKeeps WHERE vaultId = @id;";
      List<VaultKeep> vaultKeeps = _db.Query<VaultKeep>(sql, new { id }).ToList();
      return vaultKeeps;
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